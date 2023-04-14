using System.IO;

namespace ProjCharGenerator
{
    class Program
    {
        private const int TextLength = (int)1e3;
        private const string RootBasePath = "../../../../";

        static void Main(string[] args)
        {
            var bigrammSequenceGenerator = new BigrammGenerator().SequenceGenerator;
            var wordSequenceGenerator = new WordGenerator().SequenceGenerator;
            var pairWordSequenceGenerator = new PairWordGenerator().SequenceGenerator;

            RunGenerator(bigrammSequenceGenerator, RootBasePath + "bigramm.txt");
            RunGenerator(wordSequenceGenerator, RootBasePath + "words.txt", " ");
            RunGenerator(pairWordSequenceGenerator, RootBasePath + "pairs.txt", " ");
        }

        private static void RunGenerator(SequenceGenerator bigrammSequenceGenerator, string filePath, string sep = "")
        {
            WriteToFile(bigrammSequenceGenerator, TextLength, filePath, sep);
        }

        private static void WriteToFile(SequenceGenerator sequenceGenerator, int sequenceLength, string filePath,
            string sep)
        {
            using var writer = new StreamWriter(filePath, false);
            for (var i = 0; i < sequenceLength - 1; i++)
            {
                writer.Write(sequenceGenerator.GetNextStr());
                writer.Write(sep);
            }

            writer.Write(sequenceGenerator.GetNextStr());
        }
    }
}