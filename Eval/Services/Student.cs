using System.Text.RegularExpressions;

namespace Eval.Services
{
    public class Student
    {
        /// <summary>
        /// Function returns formatted string that contains the number of words
        /// and characters in the file specified by the path
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <returns>String containing word and character counts</returns>
        public static string GetResults(string path)
        {
            StreamReader stream = FileManager.GetFileStreamReader(path);

            GetCounts(stream, out int wordCount, out int charCount);
            stream.Close();
            return $"Total words: {wordCount}; Total characters: {charCount}";
        }

        
        /// <summary>
        /// Function gets the word and character counts from a StreamReader
        /// </summary>
        /// <param name="stream">Stream open to file</param>
        /// <param name="wordCount">Word count in file</param>
        /// <param name="charCount">Character count in file</param>
        /// <exception cref="Exception">Stream is null</exception>
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

        /// <summary>
        /// Function gets the word count in a line
        /// </summary>
        /// <param name="line">Current line in file</param>
        /// <returns>Word count in line</returns>
        public static int GetWordCount(string line)
        {
            if (line.Length == 0)
                return 0;
            
            return FileManager.GetWordsInLine(line).Count;
        }

        /// <summary>
        /// Function counts the number of characters in line including white space
        /// </summary>
        /// <param name="line">Current line in file</param>
        /// <returns>Character count</returns>
        public static int GetCharacters(string line)
        {
            return line.Length;
        }

    }
}