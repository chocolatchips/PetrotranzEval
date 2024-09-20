using System.Runtime.InteropServices.Marshalling;
using System.Text.RegularExpressions;

namespace Eval.Services
{
    public class Analyst
    {
        /// <summary>
        /// Function finds the 10 most frequent words that appear in the file
        /// specified in the path
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <returns>String of most frequent words in descending order</returns>
        public static string GetResults(string path)
        {
            StreamReader stream = FileManager.GetFileStreamReader(path);
            
            string result = FormatFreqString(GetWordFrequency(stream));
            stream.Close();
            return result;
        }

        /// <summary>
        /// Function formats a string from a collection of KeyValuePair<string, int>
        /// </summary>
        /// <param name="freq">Collection of KeyValuPair<string, int></param>
        /// <returns>String of keys from collection of KeyValuePairs</returns>
        public static string FormatFreqString(IEnumerable<KeyValuePair<string, int>> freq) {
            List<string> words = [];
            foreach(var pair in freq) {
                words.Add($"\"{pair.Key}\"");
            }
            
            return $"[{string.Join(", ", words)}]";
        }

        /// <summary>
        /// Function finds the frequency of words from a StreamReader
        /// </summary>
        /// <param name="stream">StreamReader connected to file</param>
        /// <returns>IEnumerable<KeyValuePair<string, int>> of <word, frequency></returns>
        public static IEnumerable<KeyValuePair<string, int>> GetWordFrequency(StreamReader stream)
        {
            Dictionary<string, int> frequencies = [];
            ReadLines(ref frequencies, stream);

            return GetMostFrequent(frequencies);
        }

        /// <summary>
        /// Function iterates through the lines of the stream and updates the freq dictionary
        /// to count word appearance frequency
        /// </summary>
        /// <param name="freq">Dictionary containing word frequency counts</param>
        /// <param name="stream">StreamReader connected to file</param>
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

        /// <summary>
        /// Function iterates through each word in a line and updates the appearaance
        /// count for each word
        /// </summary>
        /// <param name="freq">Dicitonary containing frequency counts</param>
        /// <param name="line">Current line read from file</param>
        public static void UpdateFreqForLine(ref Dictionary<string, int> freq, List<string> line)
        {
            foreach(string word in line) {
                if (!freq.TryAdd(word.ToLower(), 1)) {
                    freq[word.ToLower()]++;
                }
            }
        }

        /// <summary>
        /// Function sorts frequency dictionary and returns the 10 most frequent words
        /// in descending order
        /// </summary>
        /// <param name="freq">Dicitonary containing frequency counts</param>
        /// <returns>Collecction of words and frequency counts in descending order</returns>
        public static IEnumerable<KeyValuePair<string, int>> GetMostFrequent(Dictionary<string, int> freq)
        {
            var sorted = freq.OrderByDescending(pair => pair.Value);
            return sorted.Take(10);
        }

    }
}