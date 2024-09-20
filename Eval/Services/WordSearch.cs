using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Eval.Services
{
    public class WordSearch
    {
        public static string GetResults(string path, string desiredWord)
        {
            StreamReader stream = FileManager.GetFileStreamReader(path);
            FindWordCount(stream, desiredWord, out int count);

            return $"The word \"{desiredWord}\" appears {count} times.";
        }


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

        public static int CountWordInLine(string line, string word) {
            return Regex.Matches(line, @$"\b{word}\b", RegexOptions.IgnoreCase).Count;
        }
    }
}