using System.Text.RegularExpressions;

namespace Eval.Services
{
    public class FileManager
    {
        public static StreamReader GetFile(string path)
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

        public static bool IsStartLine(string line) {
            string pattern = @"^\*\*\* START ";

            return Regex.IsMatch(line, pattern);
        }

        public static bool IsEndLine(string line) {
            string pattern = @"^\*\*\* END";

            return Regex.IsMatch(line, pattern);
        }
    }
    
}