using System.Text.RegularExpressions;

namespace Eval.Services
{
    public class FileManager
    {
        public static StreamReader GetFileStreamReader(string path)
         {
            if (!File.Exists(path)){
                throw new Exception("File not found");
            }

            return File.OpenText(path);
         }

        public static string GetParentPath() {
            string workingDir = Environment.CurrentDirectory;
            string parentDir = Directory.GetParent(workingDir).FullName;
            return parentDir;
        }

        public static string GetPath(string fileName) {
            return Path.Join(GetParentPath(), fileName);
        }

        public static bool IsStartLine(string line) {
            string pattern = @"^\*\*\* START ";

            return Regex.IsMatch(line, pattern);
        }

        public static bool IsEndLine(string line) {
            string pattern = @"^\*\*\* END";

            return Regex.IsMatch(line, pattern);
        }

        public static List<string> GetFileLines(StreamReader stream) {
            bool started = false;
            List<string> fileLines = [];
            string line;

            while ((line = stream.ReadLine()) != null) {
                if (started) {
                    if (FileManager.IsEndLine(line))
                        break;
                    fileLines.Add(line);
                }
                
                else
                    started = FileManager.IsStartLine(line);
            }

            return fileLines;
        }

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