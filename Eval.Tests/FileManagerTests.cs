using Eval.Services;

namespace Eval.Tests
{
    public class FileManagerTests
    {
        static string GetParentPath() {
            string workingDir = Environment.CurrentDirectory;
            string parentDir = Directory.GetParent(workingDir).Parent.Parent.Parent.FullName;
            return parentDir;
        }

        [Fact]
        public void GetFileExists()
        {
            // Given
            string parentDir = GetParentPath();
            string path = $"{parentDir}\\A Tale of Two Cities - Charles Dickens.txt";
        
            // When
            var res = FileManager.GetFile(path);

            // Then
            Assert.NotNull(res);
        }

        [Fact]
        public void GetFileNotExist()
        {
            string path = @"A Tale";

            Assert.ThrowsAny<Exception>(() => FileManager.GetFile(path));
        }

        [Fact]
        public void TextStartMatchPass()
        {
            // Given
            string line = "*** START OF THE PROJECT GUTENBERG EBOOK ALICE’S ADVENTURES IN WONDERLAND ***";
            
            // When
            bool res = FileManager.IsStartLine(line);

            // Then
            Assert.True(res, "Pattern not found in line");
        }

         [Fact]
        public void TextStartMatchFail()
        {
            // Given
            string line = "Produced by: Arthur DiBianca and David Widger";
            
            // When
            bool res = FileManager.IsStartLine(line);

            // Then
            Assert.False(res, "Pattern not found in line");
        }

        [Fact]
        public void TextEndMatchPass()
        {
            // Given
            string line = "*** END OF THE PROJECT GUTENBERG EBOOK ALICE’S ADVENTURES IN WONDERLAND ***";
            
            // When
            bool res = FileManager.IsEndLine(line);

            // Then
            Assert.True(res, "Pattern not found in line");
        }

         [Fact]
        public void TextEndMatchFail()
        {
            // Given
            var student = new Student();
            string line = "Produced by: Arthur DiBianca and David Widger";
            
            // When
            bool res = FileManager.IsStartLine(line);

            // Then
            Assert.False(res, "Pattern not found in line");
        }
    }
}