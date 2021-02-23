using System.IO;
using Xunit;
using TemporaryDirectory;
using System;

namespace TemporaryDirectory.Tests
{
    public class TemporaryDirectoryTest
    {
        public TemporaryDirectoryTest()
        {
            this.DeleteDirectory(Directory.GetCurrentDirectory() + "/temp_folder");
            this.DeleteDirectory(Path.GetTempPath() + "/testing_folder");
            this.DeleteDirectory(Path.GetTempPath() + "/testing_folder_1");
        }

        [Fact]
        public void CanCreateTemporaryDirectory()
        {
            TemporaryDirectoryHandler directory = new TemporaryDirectoryHandler().Create();
            Assert.True(Directory.Exists(directory.GetPath()));
        }

        [Fact]
        public void CanCreateTemporaryDirectoryWithName()
        {
            TemporaryDirectoryHandler directory = new TemporaryDirectoryHandler().SetName("testing_folder").Create();
            Assert.True(Directory.Exists(directory.GetPath()));
        }

        [Fact]
        public void CanForceCreateTemporaryDirectoryWithName()
        {
            TemporaryDirectoryHandler directory = new TemporaryDirectoryHandler().SetName("testing_folder_1").Create();
            directory = new TemporaryDirectoryHandler().SetForce(true).SetName("testing_folder_1").Create();
            Assert.True(Directory.Exists(directory.GetPath()));
        }

        [Fact]
        public void CanCreateTemporaryDirectoryInLocation()
        {
            TemporaryDirectoryHandler directory = new TemporaryDirectoryHandler(Directory.GetCurrentDirectory() + "/temp_folder").Create();
            Assert.True(Directory.Exists(directory.GetPath()));
        }

        [Fact]
        public void CanDeleteDirectoryWithContent()
        {
            TemporaryDirectoryHandler directory = new TemporaryDirectoryHandler().Create();

            string fileName = directory.GetPath("test.txt");
            File.WriteAllText(fileName, String.Empty);

            Assert.True(directory.Delete());
        }

        [Fact]
        public void CanDeleteEmptyDirectory()
        {
            TemporaryDirectoryHandler directory = new TemporaryDirectoryHandler().Create();
            Assert.True(directory.Delete());
        }

        [Fact]
        public void CanEmptyADirectory()
        {
            TemporaryDirectoryHandler directory = new TemporaryDirectoryHandler().Create();

            string fileName = directory.GetPath("test.txt");
            File.WriteAllText(fileName, String.Empty);

            directory.Empty();

            string[] fileEntries = Directory.GetFiles(directory.GetPath());
            Console.WriteLine(fileEntries);
            Assert.True(fileEntries.Length == 0);
        }


        /// <summary>
        /// Method to delete directory
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool DeleteDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                return true;
            }

            Directory.Delete(path, true);

            return true;
        }
    }
}
