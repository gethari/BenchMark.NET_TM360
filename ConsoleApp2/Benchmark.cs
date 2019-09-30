using BenchmarkDotNet.Attributes;

namespace ConsoleApp2
{
	[MemoryDiagnoser, InProcess]
	[JsonExporter("benchMarkDotNet",true)]
	public class Benchmark
	{
		private readonly Demo _demo;
		private readonly AdoVsDapper _adoVsDapper;
		public Benchmark()
		{
			_demo = new Demo();
			_adoVsDapper = new AdoVsDapper();
		}
		[Benchmark]
		public void CompareStrings()
		{
			_demo.CompareStrings();
		}
		[Benchmark]
		public void CompareStringsWithToLower()
		{
			_demo.CompareStringsWithToLower();
		}

		[Benchmark]
		public void StringBuilder()
		{
			_demo.StringBuilder();
		}

		[Benchmark]
		public void StringInterpolation()
		{
			_demo.StringInterpolation();
		}

		[Benchmark]
		public void Insert()
		{
			_adoVsDapper.Insert();
		}

		[Benchmark]
		public void InsertWithDapper()
		{
			_adoVsDapper.DapperInsert();
		}

		[Benchmark]
		public void GetData()
		{
			_adoVsDapper.GetData();
		}
		[Benchmark]
		public void GetDataWithDapper()
		{
			_adoVsDapper.GetDataWithDapper();
		}

		[Benchmark]
		public void GetTop1000()
		{
			_adoVsDapper.GetTop1000();
		}

		[Benchmark]
		public void GetTop1000WithDapper()
		{
			_adoVsDapper.GetTop1000WithDapper();
		}

	}
}
