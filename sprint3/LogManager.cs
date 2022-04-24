using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSE3902_CSE3902_Project
{

    public abstract class LogManager
    {
        protected string folderName, fileName;

        public SaveLog Data { get; set; }

        public LogManager(string folderName, string fileName)
        {
            this.folderName = folderName;
            this.fileName = fileName;
            this.Data = new SaveLog();
        }

        public abstract void Load();


        public abstract void Save();
    }
}
