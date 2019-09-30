using System;
using BenchmarkDotNet.Running;
using Console = System.Console;

namespace ConsoleApp2
{
	class Program
	{
		static void Main(string[] args)
		{
			//var data = new AdoVsDapper();
			//data.Insert();
			//data.DapperInsert();
			//data.GetData();
			//data.GetDataWithDapper();
			//data.GetTop1000();
			//data.GetTop1000WithDapper();

			var summary = BenchmarkRunner.Run<Benchmark>();
			Console.ReadKey();
		}
	}
}
