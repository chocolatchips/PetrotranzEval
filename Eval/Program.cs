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

        /// <summary>
        /// Function processes args to select persona
        /// </summary>
        /// <param name="args">Args provided</param>
        /// <returns>Result of selected persona actions</returns>
        /// <exception cref="Exception">No arguments provided</exception>
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

        /// <summary>
        /// Function processes the arguments for the librarian persona
        /// </summary>
        /// <param name="args">Arguments provided by user</param>
        /// <returns>Results from librarian persona</returns>
        /// <exception cref="Exception">Invalid number of arguments</exception>
        public static string ProcessLibrarian(string[] args) {
            if (args.Length != 3)
                throw new Exception("Incorrect number of arguments");
            
            return Librarian.GetResults(args[1], args[2]);
        }

        /// <summary>
        /// Function processes the arguments for the student persona
        /// </summary>
        /// <param name="args">Arguments provided by user</param>
        /// <returns>Results of the student persona</returns>
        /// <exception cref="Exception">Incorrect number of arguments</exception>
        public static string ProcessStudent(string[] args) {
            if (args.Length == 2)
                return Student.GetResults(args[1]);

            else if (args.Length == 3)
                return WordSearch.GetResults(args[2], args[1]);
            
            throw new Exception("Incorrect number of arguments");
        }

        /// <summary>
        /// Function processes the arguments for the business analyst persona
        /// </summary>
        /// <param name="args">Arguments provided by user</param>
        /// <returns>Results of the business analyst persona</returns>
        /// <exception cref="Exception">Invalid number of arguments</exception>
        public static string ProcessAnalyst(string[] args) {
            if (args.Length != 2)
                throw new Exception("Incorrect number of arguments");
            
            return Analyst.GetResults(args[1]);
        }
    }
}
