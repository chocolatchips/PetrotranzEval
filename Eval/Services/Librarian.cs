using System.Runtime.CompilerServices;

namespace Eval.Services
{
    public class Librarian
    {

        /// <summary>
        /// Function calculates the number of pages required to fit number
        /// of words based on specified words per page
        /// </summary>
        /// <param name="words">Number of words to fit</param>
        /// <param name="perPage">Number of words per page</param>
        /// <returns>Number of pages required to fit words</returns>
        public static int CalculatePages(int words, int perPage){
            if (words < 0 || perPage < 1)
                return 0;
            int pages = words / perPage;
            return words % perPage == 0 ? pages : pages + 1; 
        }

        /// <summary>
        /// Function gets number of pages required to fit number of words
        /// and formats result into string
        /// </summary>
        /// <param name="words">Number of words to fit</param>
        /// <param name="perPage">Number of words per page</param>
        /// <returns>Formated string containing number of pages required</returns>
        /// <exception cref="Exception">Failed to parse string into int</exception>
        public static string GetResults(string words, string perPage) {
            if (!int.TryParse(words, out int wordNum))
                throw new Exception("Word count parse failed");
            
            if (!int.TryParse(perPage, out int perPageNum))
                throw new Exception("PerPage count parse failed");

            return $"Total pages: {CalculatePages(wordNum, perPageNum)}";

        }

        /// <summary>
        /// Function gets number of pages required to fit number of words
        /// and formats result into string
        /// </summary>
        /// <param name="words">Number of words to fit</param>
        /// <param name="perPage">Number of words per page</param>
        /// <returns>Formated string containing number of pages required</returns>
        public static string GetResults(int words, int perPage) {
            return $"Total pages: {CalculatePages(words, perPage)}";

        }
    }
}