using Eval.Services;

namespace Eval.Tests
{
    public class WordSearchTests
    {
        [Fact]
        public void FindWordPass()
        {
            // Given
            string path = Path.Join(FileManagerTests.GetParentPath(), "A Tale of Two Cities - Charles Dickens.txt");
            string word = "the";

            StreamReader stream = FileManager.GetFileStreamReader(path);

            // When
            WordSearch.FindWordCount(stream, word, out int wordCount);
            
            // Then
        }

        [Fact]
        public void FindWordInLine()
        {
            // Given
            string word = "the";
            string line = "Search for a specific word in the book";
        
            // When
            int res = WordSearch.CountWordInLine(line, word);
        
            // Then
            Assert.True(res == 1, "Word not found in line");
        }

        [Fact]
        public void FindNoWordInLine()
        {
            // Given
            string word = "the";
            string line = "Provide basic word and character statistics about a book.";
        
            // When
            int res = WordSearch.CountWordInLine(line, word);
        
            // Then
            Assert.True(res == 0, "Word found in line");
        }

        [Fact]
        public void FindWordCapitalized()
        {
            // Given
            string word = "REVOLUTION";
            string line = "A STORY OF THE FRENCH REVOLUTION";

            // When
            int res = WordSearch.CountWordInLine(line, word);
        
            // Then
            Assert.True(res == 1, $"{res} words found in line.");
        }

        [Fact]
        public void FindWordWhenFragment()
        {
            // Given
            string word = "fun";
            string line = "People often laugh when they find something funny";
        
            // When
            int res = WordSearch.CountWordInLine(line, word);
        
            // Then
            Assert.True(res == 0, "Word fragment found");
        }
        

        [Fact]
        public void FindWordDoubleHyphenated()
        {
            // Given
            string line = "creatures--the";
            string word = "creatures";
        
            // When
            int res = WordSearch.CountWordInLine(line, word);
        
            // Then
            Assert.True(res == 1, "Word not found");
        }

        [Fact]
        public void GetCountForMultiInstanceInLine()
        {
            // Given
            string line = "creatures--the creatures of this chronicle";
            string word = "creatures";
            int expectedCount = 2;

            // When
            int res = WordSearch.CountWordInLine(line, word);
        
            // Then
            Assert.True(res == expectedCount, $"Incorrect number of words counted {res}");
        }

        [Fact]
        public void GetCountForZeroInstanceInLine()
        {
            // Given
            string line = "creatures--the creatures of this chronicle";
            string word = "purple";
            int expectedCount = 0;

            // When
            int res = WordSearch.CountWordInLine(line, word);
        
            // Then
            Assert.True(res == expectedCount, "Incorrect number of words counted");
        }

        [Fact]
        public void FindWordCountInTextShort()
        {
            // Given
            string desiredWord = "revolution";
            int expected = 9;

            string path = Path.Join(FileManagerTests.GetParentPath(), "A Tale of Two Cities - Charles Dickens.txt");
            StreamReader stream = FileManager.GetFileStreamReader(path);

            // When
            WordSearch.FindWordCount(stream, desiredWord, out int res);
        
            // Then
            Assert.True(res == expected, $"{res} instances found");
        }

        [Fact]
        public void GetWordCountResultString()
        {
            // Given
            string desiredWord = "revolution";
            int desiredCount = 9;
            string expectedString = $"The word \"{desiredWord}\" appears {desiredCount} times.";
            string path = Path.Join(FileManagerTests.GetParentPath(), "A Tale of Two Cities - Charles Dickens.txt");

            // When
            string res = WordSearch.GetWordCount(path, desiredWord);
        
            // Then
            Assert.True(res.Equals(expectedString), $"Strings do not match\n{res}");
        }

        [Fact]
        public void ItTest()
        {
            // Given
            string desiredWord = "it";
            int desiredCount = 2067;
            string expectedString = $"The word \"{desiredWord}\" appears {desiredCount} times.";
            string path = Path.Join(FileManagerTests.GetParentPath(), "A Tale of Two Cities - Charles Dickens.txt");

            // When
            string res = WordSearch.GetWordCount(path, desiredWord);
        
            // Then
            Assert.True(res == expectedString, $"{res}");
        }
        
    }
}