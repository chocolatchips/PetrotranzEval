using Eval.Services;

namespace Eval
{
    class Program
    {
        public static string GetParentPath() {
            string workingDir = Environment.CurrentDirectory;
            string parentDir = Directory.GetParent(workingDir).Parent.Parent.Parent.FullName;
            return parentDir;
        }

        public static void Main(string[] args){
            
        }
    }
}
