using System.Text.RegularExpressions;

namespace Eval.Services
{
    public class Student
    {
        public string GetResults(string path)
        {
            StreamReader stream = FileManager.GetFile(path);

            GetCounts(stream, out int wordCount, out int charCount);

            return $"Total words: {wordCount}; Total characters: {charCount}";
        }

        

        public void GetCounts(StreamReader stream, out int wordCount, out int charCount)
        {
            if (stream is null)
                throw new Exception("Stream is null");

            bool started = false;
            bool ended = false;
            int words = 0;
            int characters = 0;

            string line;
            while ((line = stream.ReadLine()) != null) {
                if (started) {
                    ended = FileManager.IsEndLine(line);
                    if (ended)
                        break;
                    
                    words += GetWords(line);
                    characters += GetCharacters(line);
                    
                }
                
                else
                    started = FileManager.IsStartLine(line);
            }
            
            wordCount = words;
            charCount = characters;
        }


        public static int GetWords(string line)
        {
            if (line.Length == 0)
                return 0;
            
            int wordCount = 0;

            foreach (string word in line.Split(' ')) {
                if (word.Length == 0)
                    continue;
                if (Regex.IsMatch(word, @"[A-Za-z]"))
                    wordCount++;
                
            }
            
            return wordCount;
        }

        public static int GetCharacters(string line)
        {
            return line.Length;
        }

    }
}