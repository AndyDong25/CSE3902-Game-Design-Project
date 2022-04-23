using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSE3902_CSE3902_Project
{

    public abstract class SaveManager
    {
        protected string folderName, fileName;

        public SaveData Data { get; set; }

        public SaveManager(string folderName, string fileName)
        {
            this.folderName = folderName;
            this.fileName = fileName;
            this.Data = new SaveData();
        }

        public abstract void Load();


        public abstract void Save();
    }
}
