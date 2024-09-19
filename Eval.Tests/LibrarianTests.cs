using Eval.Services;

namespace Eval.Tests
{
    public class LibrarianTests
    {
        [Fact]
        public void LibrarianExampleTest()
        {
            // Given
            var librarian = new Librarian();
            int words = 50000;
            int perPage = 250;
            int expectedPages = 200;
            // When
            int pages = Librarian.CalculatePages(words, perPage);
            // Then
            Assert.True(pages == expectedPages, $"Pages = {pages} not 200");
        }

        [Fact]
        public void ExtraWords()
        {
            // Given
            var librarian = new Librarian();
            int words = 50001;
            int perPage = 250;
            int expectedPages = 201;
            // When
            int pages = Librarian.CalculatePages(words, perPage);
            // Then
            Assert.True(pages == expectedPages, "Pages does not equal expected pages");
        }

        [Fact]
        public void WordsEqualsPerPage()
        {
            // Given
            var librarian = new Librarian();
            int words = 100;
            int perPage = 100;
            int expectedPages = 1;
            // When
            int pages = Librarian.CalculatePages(words, perPage);
            // Then
            Assert.True(pages == expectedPages, "Pages does not equal expected pages");
        }

        [Fact]
        public void NegativeWords()
        {
            // Given
            var librarian = new Librarian();
            int words = -1000;
            int perPage = 100;
            int expectedPages = 0;
            // When
            int pages = Librarian.CalculatePages(words, perPage);
            // Then
            Assert.True(pages == expectedPages, "Pages does not equal expected pages");
        }

        [Fact]
        public void NegativePerPage()
        {
            // Given
            var librarian = new Librarian();
            int words = 100;
            int perPage = -10;
            int expectedPages = 0;
            // When
            int pages = Librarian.CalculatePages(words, perPage);
            // Then
            Assert.True(pages == expectedPages, "Pages does not equal expected pages");
        }

        [Fact]
        public void ZeroPerPage()
        {
            // Given
            var librarian = new Librarian();
            int words = 1000;
            int perPage = 0;
            int expectedPages = 0;
            // When
            int pages = Librarian.CalculatePages(words, perPage);
            // Then
            Assert.True(pages == expectedPages, "Pages does not equal expected pages");
        }

        [Fact]
        public void LargeWordCount()
        {
            // Given
            var librarian = new Librarian();
            int words = int.MaxValue;
            int perPage = 1000;
            int expectedPages = 2147484;
            // When
            int pages = Librarian.CalculatePages(words, perPage);
            // Then
            Assert.True(pages == expectedPages, "Pages does not equal expected pages");
        }


    }
}

