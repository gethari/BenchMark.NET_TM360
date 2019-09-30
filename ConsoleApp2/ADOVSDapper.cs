using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Dapper;

namespace ConsoleApp2
{
	public class AdoVsDapper
	{
		private readonly string ConnectionString = "Data Source=.;Initial Catalog=BenchMark;Integrated Security=True";

		private readonly Mock _mock;
		private readonly string InsertQuery = @"INSERT INTO [dbo].[Dummy] ([Id],[Name],[Message])VALUES(@Id,@Name,@Message)";
		private readonly string SelectQuery = @"SELECT [Id],[Name],[Message] FROM [dbo].[Dummy]";
		private readonly string SelectAllQuery = @"SELECT TOP 1000 * FROM [dbo].[Dummy]";
		public AdoVsDapper()
		{
			_mock = new Mock();
		}
		public void Insert()
		{
			var dummy = _mock.GetData();
			using (var connection = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand(InsertQuery, connection);
				command.Parameters.AddWithValue("@Id", dummy.Id);
				command.Parameters.AddWithValue("@Name", dummy.Name);
				command.Parameters.AddWithValue("@Message", dummy.Message);
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
			}
		}

		public void DapperInsert()
		{
			var dummy = _mock.GetData();
			using (var connection = new SqlConnection(ConnectionString))
			{
				var result = connection.Execute(InsertQuery, dummy);
				if (result <= 0)
					throw new Exception("Unable to Insert Data");
			}
		}

		public Dummy GetData()
		{
			var stopWatch = new Stopwatch();
			stopWatch.Start();
			var result = new Dummy();
			using (var connection = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand(SelectQuery, connection);
				connection.Open();
				var reader = command.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						result.Id = reader["Id"].ToString();
						result.Name = (string)reader["Name"];
						result.Message = (string)reader["Message"];
					}
				}
				reader.Close();
			}
			stopWatch.Stop();
			Console.WriteLine($"1 Record Without dapper {stopWatch.ElapsedMilliseconds}");
			return result;
		}

		public Dummy GetDataWithDapper()
		{
			var stopWatch = new Stopwatch();
			stopWatch.Start();
			Dummy result;
			using (var connection = new SqlConnection(ConnectionString))
			{
				result = connection.Query<Dummy>(SelectQuery).FirstOrDefault();
			}
			stopWatch.Stop();
			Console.WriteLine($"1 Record With dapper {stopWatch.ElapsedMilliseconds}");
			return result;
		}

		public List<Dummy> GetTop1000()
		{
			var stopWatch = new Stopwatch();
			stopWatch.Start();
			var dummy = new Dummy();
			var result = new List<Dummy>();
			using (var connection = new SqlConnection(ConnectionString))
			{
				var command = new SqlCommand(SelectQuery, connection);
				connection.Open();
				var reader = command.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						dummy.Id = reader["Id"].ToString();
						dummy.Name = (string)reader["Name"];
						dummy.Message = (string)reader["Message"];
					}
					result.Add(dummy);
				}
				reader.Close();
			}
			stopWatch.Stop();
			Console.WriteLine($"Top 1000 Without dapper {stopWatch.ElapsedMilliseconds}");
			return result;
		}

		public List<Dummy> GetTop1000WithDapper()
		{
			var stopWatch = new Stopwatch();
			stopWatch.Start();
			var result = new List<Dummy>();
			using (var connection = new SqlConnection(ConnectionString))
			{
				result.AddRange(connection.Query<Dummy>(SelectQuery).ToList());
			}
			stopWatch.Stop();
			Console.WriteLine($"Top 1000 With dapper {stopWatch.ElapsedMilliseconds}");
			return result;
		}
	}
}
