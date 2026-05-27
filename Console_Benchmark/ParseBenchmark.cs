using BenchmarkDotNet.Attributes;
using Console_Parser;

namespace Console_Benchmark
{

    // Помимо быстродействия также хотим измерить и потребление
    // памяти, для этого используем атрибут MemoryDiagnoser
    [MemoryDiagnoser]

    // Атрибут RankColumn добавляет столбец с рангом в таблицу результатов,
    // где 1 - самый быстрый метод, 2 - второй по скорости и так далее.
    [RankColumn]

    public class ParseBenchmark
    {
        private const string STRING_TO_PARSE_WITH_ERROR = "qwerty22";
        private const string STRING_TO_PARSE = "54";

        private readonly Parser _Parser = new Parser();

        [Benchmark]
        public void TryCatchParseTestWithError()
        {
            int result = _Parser.TryCatchParse(STRING_TO_PARSE_WITH_ERROR);
        }

        [Benchmark]
        public void TryParseTestWithError()
        {
            int result = _Parser.TryParse(STRING_TO_PARSE_WITH_ERROR);
        }

        [Benchmark]
        public void TryCatchParseTest()
        {
            int result = _Parser.TryCatchParse(STRING_TO_PARSE);
        }

        [Benchmark]
        public void TryParseTest()
        {
            int result = _Parser.TryParse(STRING_TO_PARSE);
        }
    }
}
