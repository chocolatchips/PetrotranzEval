using System.Text.RegularExpressions;

namespace Eval.Services
{
    public class Analyst
    {
        public static string FindMostFrequentWords(string path)
        {
            StreamReader stream = FileManager.GetFileStreamReader(path);
            return FormatFreqString(GetWordFrequency(stream));
        }

        public static string FormatFreqString(IEnumerable<KeyValuePair<string, int>> freq) {
            List<string> words = [];
            foreach(var pair in freq) {
                words.Add($"\"{pair.Key}\"");
            }
            
            return $"[{string.Join(", ", words)}]";
        }

        public static IEnumerable<KeyValuePair<string, int>> GetWordFrequency(StreamReader stream)
        {
            Dictionary<string, int> frequencies = [];
            ReadLines(ref frequencies, stream);

            return GetMostFrequent(frequencies);
        }

        public static void ReadLines(ref Dictionary<string, int> freq, StreamReader stream) {
            bool started = false;
            string line;

            while ((line = stream.ReadLine()) != null) {
                if (started) {
                    if (FileManager.IsEndLine(line))
                        break;
                    Console.WriteLine(line);
                    List<string> words = FileManager.GetWordsInLine(line);
                    UpdateFreqForLine(ref freq, words);
                }
                
                else
                    started = FileManager.IsStartLine(line);
            }
        }

        public static void UpdateFreqForLine(ref Dictionary<string, int> freq, List<string> line)
        {
            foreach(string word in line) {
                if (!freq.TryAdd(word.ToLower(), 1)) {
                    freq[word.ToLower()]++;
                }
            }
        }

        public static IEnumerable<KeyValuePair<string, int>> GetMostFrequent(Dictionary<string, int> freq)
        {
            var sorted = freq.OrderByDescending(pair => pair.Value);
            return sorted.Take(10);
        }

    }
}