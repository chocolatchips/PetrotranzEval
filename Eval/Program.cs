using System.Reflection.Metadata;
using Eval.Services;

namespace Eval
{
    public class Program
    {
            static readonly string LIBRARIAN = "librarian";
            static readonly string STUDENT = "student";
            static readonly string ANALYST = "analyst";

        public static void Main(string[] args){
            Console.WriteLine(ProcessSelection(args));
        }

        public static string ProcessSelection(string[] args) {
            if (args.Length == 0)
                throw new Exception("Incorrect number of arguments");

            string persona = args[0];
            
            if (persona.Equals(LIBRARIAN, StringComparison.InvariantCultureIgnoreCase))
                return ProcessLibrarian(args);

            else if (persona.Equals(STUDENT, StringComparison.InvariantCultureIgnoreCase))
                return ProcessStudent(args);

            else if (persona.Equals(ANALYST, StringComparison.InvariantCultureIgnoreCase))
                return ProcessAnalyst(args);

            return "Invalid persona";
        }

        public static string ProcessLibrarian(string[] args) {
            if (args.Length != 3)
                throw new Exception("Incorrect number of arguments");
            
            return Librarian.GetResults(args[1], args[2]);
        }

        public static string ProcessStudent(string[] args) {
            if (args.Length == 2)
                return Student.GetResults(args[1]);

            else if (args.Length == 3)
                return WordSearch.GetResults(args[2], args[1]);
            
            throw new Exception("Incorrect number of arguments");
        }

        public static string ProcessAnalyst(string[] args) {
            if (args.Length != 2)
                throw new Exception("Incorrect number of arguments");
            
            return Analyst.GetResults(args[1]);
        }
    }
}
