using NuGet.Frameworks;
using Xunit.Abstractions;

namespace Eval.Tests
{
    public class ProgramTests
    {
        static readonly string LIBRARIAN = "librarian";
        static readonly string STUDENT = "student";
        static readonly string ANALYST = "analyst";

        static readonly string TWO_CITIES = "A Tale of Two Cities - Charles Dickens.txt";
        static readonly string ALICES = "Alices Adventures in Wonderland - Lewis Carroll.txt";
        private readonly ITestOutputHelper output;

        public ProgramTests(ITestOutputHelper output) {
            this.output = output;
        }


        [Fact]
        public void ProcessStudentIncorrectArgs()
        {
            // Given
            string[] args = [
                STUDENT
            ];        
            // Then
            Assert.ThrowsAny<Exception>(() => Program.ProcessSelection(args));
        }

        [Fact]
        public void InvalidPersona()
        {
            // Given
            string[] args = [
                "stud"
            ];
            string expected = "Invalid persona";
        
            // When
            string result = Program.ProcessSelection(args);
        
            // Then
            Assert.True(result.Equals(expected), "Incorrect message returned");
        }


        [Fact]
        public void ProcessLibrarianExample()
        {
            // Given
            string[] args = [
                LIBRARIAN,
                "50000",
                "250"
            ];
            string expected = "Total pages: 200";

            // When
            string result = Program.ProcessSelection(args);
        
            // Then
            output.WriteLine($"Result: {result}");
            Assert.True(result.Equals(expected), "Librarian result not as expected");
        }

        [Fact]
        public void ProcessStudentCountTwoCities()
        {
            // Given
            string[] args = [
                STUDENT,
                FileManagerTests.GetPath(TWO_CITIES)
            ];

            int wordExpected = 136580;
            int charExpected = 741484;
            string expected = $"Total words: {wordExpected}; Total characters: {charExpected}";

            // When
            string result = Program.ProcessSelection(args);
        
            // Then
            output.WriteLine($"Result: {result}");
            Assert.True(result.Equals(expected), "Student result not as expected");
        }

        [Fact]
        public void ProcessStudentSearchTwoCities()
        {
            // Given
            string desiredWord = "revolution";
            int expCount = 9;
            string expected = $"The word \"{desiredWord}\" appears {expCount} times.";
            
            string[] args = [
                STUDENT,
                desiredWord,
                FileManagerTests.GetPath(TWO_CITIES)
            ];

            // When
            string result = Program.ProcessSelection(args);
        
            // Then
            output.WriteLine($"Result: {result}");
            Assert.True(result.Equals(expected), "Search result not as expected");
        }

        [Fact]
        public void ProcessAnalystTwoCities()
        {
            // Given
            string expected = "[\"the\", \"and\", \"of\", \"to\", \"a\", \"in\", \"his\", \"it\", \"i\", \"that\"]";
            
            string[] args = [
                ANALYST,
                FileManagerTests.GetPath(TWO_CITIES)
            ];

            // When
            string result = Program.ProcessSelection(args);
        
            // Then
            output.WriteLine($"Result: {result}");
            Assert.True(result.Equals(expected), "Search result not as expected");
        }
    }
}