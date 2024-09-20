using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Eval.Services
{
    public class WordSearch
    {
        /// <summary>
        /// Function creates string with the count for the the frequency
        /// of a word in specified file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="desiredWord">Word to count frequency in file</param>
        /// <returns></returns>
        public static string GetResults(string path, string desiredWord)
        {
            StreamReader stream = FileManager.GetFileStreamReader(path);
            FindWordCount(stream, desiredWord, out int count);
            stream.Close();
            return $"The word \"{desiredWord}\" appears {count} times.";
        }

        /// <summary>
        /// Function searches file for frequency of desired word
        /// </summary>
        /// <param name="stream">StreamReader for file</param>
        /// <param name="desiredWord">Word to search file for</param>
        /// <param name="count">Frequency count</param>
        /// <exception cref="Exception">StreamReader is null</exception>
        public static void FindWordCount(StreamReader stream, string desiredWord, out int count)
        {
            if (stream is null)
                throw new Exception("Stream is null");

            bool started = false;
            int wordCount = 0;

            string line;
            while ((line = stream.ReadLine()) != null) {
                if (started) {
                    if (FileManager.IsEndLine(line))
                        break;
                    wordCount += CountWordInLine(line, desiredWord);
                    
                }
                
                else
                    started = FileManager.IsStartLine(line);
            }

            count = wordCount;
        }

        /// <summary>
        /// Function searches line for frequency of desired word
        /// </summary>
        /// <param name="line">Current line in file</param>
        /// <param name="word">Desired word</param>
        /// <returns>Frequency of word in line</returns>
        public static int CountWordInLine(string line, string word) {
            return Regex.Matches(line, @$"\b{word}\b", RegexOptions.IgnoreCase).Count;
        }
    }
}