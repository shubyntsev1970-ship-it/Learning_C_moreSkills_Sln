using BenchmarkDotNet.Running;

namespace Console_Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ParseBenchmark>();
        }
    }
}
