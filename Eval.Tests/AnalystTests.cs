using Eval.Services;

namespace Eval.Tests
{
    public class AnalystTest
    {
        [Fact]
        public void GetWordsInLineTest()
        {
            // Given
            string line = "we were all going direct to Heaven,";
            string[] expected = [
                "we", "were", "all", "going", "direct", "to", "Heaven"
            ];
        
            // When
            string[] res = [.. FileManager.GetWordsInLine(line)];
            // Then
            Assert.True(res.SequenceEqual(expected), "Words not equal");
        }

        [Fact]
        public void StringFormatTest()
        {
            // Given
            List<KeyValuePair<string, int>> words = [
                new KeyValuePair<string, int>("first", 1),
                new KeyValuePair<string, int>("second", 2),
                new KeyValuePair<string, int>("third", 3)
            ];
            string expected = "[\"first\", \"second\", \"third\"]";
            
            // When
            string res = Analyst.FormatFreqString(words);

            // Then
            Assert.True(res.Equals(expected), $"{res}");
        }

        [Fact]
        public void MostFrequentWordsTwoCities()
        {
            // Given
            string path = FileManagerTests.GetPath("A Tale of Two Cities - Charles Dickens.txt");
            string expected = "[\"the\", \"and\", \"of\", \"to\", \"a\", \"in\", \"his\", \"it\", \"i\", \"that\"]";
        
            // When
            string res = Analyst.GetResults(path);

            // Then
            Assert.True(res.Equals(expected), $"{res}");
        }


        [Fact]
        public void FrequencyCountTest()
        {
            // Given
            string path = FileManagerTests.GetPath("A Tale of Two Cities - Charles Dickens.txt");
            Dictionary<string, int> freq = [];
            StreamReader stream = FileManager.GetFileStreamReader(path);

            // When
            Analyst.ReadLines(ref freq, stream);
            var sorted = freq.OrderByDescending(pair => pair.Value).Take(10);

            // Then
            Assert.True(freq.TryGetValue("it", out int value), "\"it\" not found");
        }
    }
}