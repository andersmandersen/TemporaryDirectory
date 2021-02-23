using System;
using System.IO;

namespace TemporaryDirectory
{
    public class TemporaryDirectoryHandler
    {
        protected string Location { get; set; }
        protected string Name { get; set; } = "";
        protected bool Force { get; set; } = false;

        public TemporaryDirectoryHandler(string location = "")
        {
            this.Location = location;
        }

        /// <summary>
        /// Method to create Directory
        /// </summary>
        /// <returns></returns>
        public TemporaryDirectoryHandler Create()
        {
            if (this.Location == "")
            {
                this.Location = this.GetSystemTemporaryDirectory();
            }

            if (this.Name == "")
            {
                this.Name = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString();
            }

            if (this.Force && Directory.Exists(this.GetFullPath()))
            {
                this.DeleteDirectory(this.GetFullPath());
            }

            if (Directory.Exists(this.GetFullPath()))
            {
                throw new Exception("Path already exists.");
            }            

            Directory.CreateDirectory(this.GetFullPath());

            return this;
        }

        /// <summary>
        /// Method to empty folder
        /// </summary>
        /// <returns></returns>
        public TemporaryDirectoryHandler Empty()
        {
            this.DeleteDirectory(this.GetFullPath());
            Directory.CreateDirectory(this.GetFullPath());
            return this;
        }

        /// <summary>
        /// Method to delete folder
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            return this.DeleteDirectory(this.GetFullPath());
        }

        /// <summary>
        /// Method to get path or fulld path of a file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string GetPath(string fileName = "")
        {
            if (fileName == "")
            {
                return this.GetFullPath();
            }

            return this.GetFullPath() + "/" + fileName;
        }

        /// <summary>
        /// Method to get full path
        /// </summary>
        /// <returns></returns>
        private string GetFullPath()
        {
            return this.Location + (this.Name != "" ? "/" + this.Name : "");
        }

        /// <summary>
        /// Method to set force
        /// </summary>
        /// <param name="force"></param>
        /// <returns></returns>
        public TemporaryDirectoryHandler SetForce(bool force)
        {
            this.Force = force;
            return this;
        }

        /// <summary>
        /// Method to set name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public TemporaryDirectoryHandler SetName(string name)
        {
            this.Name = name;
            return this;
        }

        /// <summary>
        /// Method to delete directory
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool DeleteDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                return true;
            }

            Directory.Delete(path, true);

            return true;
        }

        /// <summary>
        /// Method to get system temporary directory
        /// </summary>
        /// <returns></returns>
        private string GetSystemTemporaryDirectory()
        {
            return Path.GetTempPath();
        }
    }
}
