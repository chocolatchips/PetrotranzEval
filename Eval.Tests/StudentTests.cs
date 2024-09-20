using Eval.Services;

namespace Eval.Tests
{
    public class StudentTests
    {
        [Fact]
        public void GetWordCount()
        {
            // Given
            var student = new Student();
            string line = "we were all going direct to Heaven,";
            int expected = 7;

            // When
            int res = Student.GetWords(line);

            // Then
            Assert.True(res == expected, "Result and expected word lists do not match");
        }
        
        [Fact]
        public void GetCharacterCount()
        {
            // Given
            var student = new Student();
            string line = "top and be damned to you, for I have had trouble enough to get you to";
            int expected = 69;
            
            // When
            int res = Student.GetCharacters(line);

            // Then
            Assert.True(res == expected, "Result and expected are not equal");
        }


        [Fact]
        public void GetWordCountsFromFileSingleLine()
        {
            // Given
            var student = new Student();
            int wordExpected = 16;
            
            string path = $"{FileManagerTests.GetParentPath()}\\StudentTestOneLine.txt";
            StreamReader stream = FileManager.GetFile(path);

            // When
            student.GetCounts(stream, out int wordCount, out int charCount);
        
            // Then
            Assert.True(wordCount == wordExpected, $"Word count {wordCount} not equal to expected word count");
        }

        [Fact]
        public void GetCharCountFromFileSingleLine()
        {
            // Given
            var student = new Student();
            int charExpected = 69;
            
            string path = $"{FileManagerTests.GetParentPath()}\\StudentTestOneLine.txt";
            StreamReader stream = FileManager.GetFile(path);

            // When
            student.GetCounts(stream, out int wordCount, out int charCount);
        
            // Then
            Assert.True(charCount == charExpected, $"Character count {charCount} not equal to expected");
        }

        [Fact]
        public void GetWordCountsFromFileMultiLine()
        {
            // Given
            var student = new Student();
            int wordExpected = 18;
            
            string path = $"{FileManagerTests.GetParentPath()}\\StudentTestMultiLines.txt";
            StreamReader stream = FileManager.GetFile(path);

            // When
            student.GetCounts(stream, out int wordCount, out int charCount);
        
            // Then
            Assert.True(wordCount == wordExpected, $"Word count {wordCount} not equal to expected word count");
        }

        [Fact]
        public void GetCharCountFromFileMultiLine()
        {
            // Given
            var student = new Student();
            int charExpected = 77;
            
            string path = $"{FileManagerTests.GetParentPath()}\\StudentTestMultiLines.txt";
            StreamReader stream = FileManager.GetFile(path);

            // When
            student.GetCounts(stream, out int wordCount, out int charCount);
        
            // Then
            Assert.True(charCount == charExpected, $"Character count {charCount} not equal to expected");
        }

        [Fact]
        public void StudentExampleTestCounts()
        {
            // Given
            var student = new Student();
            string path = $"{FileManagerTests.GetParentPath()}\\A Tale of Two Cities - Charles Dickens.txt";

            int wordExpected = 135834;
            int charExpected = 741484;

            StreamReader stream = FileManager.GetFile(path);
            // When
            student.GetCounts(stream, out int wordCount, out int charCount);

            // Then
            Assert.True(wordCount == wordExpected, $"Word count {wordCount} not equal to expected");
            Assert.True(charCount == charExpected, $"Character count {charCount} not equal to expected");
        }

        
    }
}