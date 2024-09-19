namespace Eval.Services
{
    public class Librarian
    {
        public int CalculatePages(int words, int perPage){
            if (words < 0 || perPage < 1)
                return 0;
            int pages = words / perPage;
            return words % perPage == 0 ? pages : pages + 1; 
        }
    }
}