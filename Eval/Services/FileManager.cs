using System.Text.RegularExpressions;

namespace Eval.Services
{
    public class FileManager
    {

        /// <summary>
        /// Function creates a StreamReader from the file at the specified path
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <returns>Stream for reading the file</returns>
        /// <exception cref="Exception">Invalid path</exception>
        public static StreamReader GetFileStreamReader(string path)
         {
            if (!File.Exists(path)){
                throw new Exception("File not found");
            }

            return File.OpenText(path);
         }

        /// <summary>
        /// Function gets the current path to the parent directory
        /// </summary>
        /// <returns>Path to parent of current program</returns>
        private static string GetParentPath() {
            string workingDir = Environment.CurrentDirectory;
            string parentDir = Directory.GetParent(workingDir).FullName;
            return parentDir;
        }

        /// <summary>
        /// Function creates a path to a file in the same directory of the current program
        /// </summary>
        /// <param name="fileName">Name of file to append to path</param>
        /// <returns>Path to file</returns>
        public static string GetPath(string fileName) {
            return Path.Join(GetParentPath(), fileName);
        }

        /// <summary>
        /// Function checks for match of starting line for each book text file
        /// </summary>
        /// <param name="line">Current line to test</param>
        /// <returns>If line is start of book</returns>
        public static bool IsStartLine(string line) {
            string pattern = @"^\*\*\* START ";

            return Regex.IsMatch(line, pattern);
        }

        /// <summary>
        /// Function checks for match of ending line for each book text file
        /// </summary>
        /// <param name="line">Current line to test</param>
        /// <returns>If line is end of book</returns>
        public static bool IsEndLine(string line) {
            string pattern = @"^\*\*\* END";

            return Regex.IsMatch(line, pattern);
        }

        /// <summary>
        /// Function splits current line into words and trims non-word characters from the ends
        /// </summary>
        /// <param name="line">Current line to split</param>
        /// <returns>List of words in line</returns>
        public static List<string> GetWordsInLine(string line)
        {
            List<string> words = [];
            string pattern = @"^\W+|\W$+";
            foreach (var word in line.Split([" ", "--"], StringSplitOptions.RemoveEmptyEntries)) {
                words.Add(Regex.Replace(word, pattern, ""));
            }

            return words;
        }
    }
    
}