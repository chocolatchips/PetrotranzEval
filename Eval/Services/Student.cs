using System.Text.RegularExpressions;

namespace Eval.Services
{
    public class Student
    {
        public static string GetResults(string path)
        {
            StreamReader stream = FileManager.GetFileStreamReader(path);

            GetCounts(stream, out int wordCount, out int charCount);

            return $"Total words: {wordCount}; Total characters: {charCount}";
        }

        

        public static void GetCounts(StreamReader stream, out int wordCount, out int charCount)
        {
            if (stream is null)
                throw new Exception("Stream is null");

            bool started = false;
            int words = 0;
            int characters = 0;

            string line;
            while ((line = stream.ReadLine()) != null) {
                if (started) {
                    if (FileManager.IsEndLine(line))
                        break;
                    
                    words += GetWordCount(line);
                    characters += GetCharacters(line);
                    
                }
                
                else
                    started = FileManager.IsStartLine(line);
            }
            
            wordCount = words;
            charCount = characters;
        }


        public static int GetWordCount(string line)
        {
            if (line.Length == 0)
                return 0;
            
            return FileManager.GetWordsInLine(line).Count;
        }

        public static int GetCharacters(string line)
        {
            return line.Length;
        }

    }
}