using System.Runtime.CompilerServices;

namespace Eval.Services
{
    public class Librarian
    {
        public static int CalculatePages(int words, int perPage){
            if (words < 0 || perPage < 1)
                return 0;
            int pages = words / perPage;
            return words % perPage == 0 ? pages : pages + 1; 
        }

        public static string GetResults(string words, string perPage) {
            if (!int.TryParse(words, out int wordNum))
                throw new Exception("Word count parse failed");
            
            if (!int.TryParse(perPage, out int perPageNum))
                throw new Exception("PerPage count parse failed");

            return $"Total pages: {CalculatePages(wordNum, perPageNum)}";

        }
    }
}