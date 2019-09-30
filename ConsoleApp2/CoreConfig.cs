using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess;

namespace ConsoleApp2
{
	[Config(typeof(CoreConfig))]
	public class CoreConfig : ManualConfig
	{
		public CoreConfig()
		{
			//Add(Job.Dry
			//	.With(InProcessToolchain.Instance)
			//	.RunOncePerIteration()
			//	.WithIterationCount(10)
			//	.WithLaunchCount(1));

			Add(Job.Default.With(Runtime.CoreRT).With(Jit.RyuJit).With(Platform.X64));

			//Logging
			Add(DefaultConfig.Instance.GetExporters().ToArray());
			Add(DefaultConfig.Instance.GetLoggers().ToArray());
			Add(DefaultConfig.Instance.GetColumnProviders().ToArray());
		}
	}
}
