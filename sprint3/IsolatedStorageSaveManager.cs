using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CSE3902_CSE3902_Project
{

    public class IsolatedStorageSaveManager : SaveManager
    {

        public IsolatedStorageSaveManager(string folderName, string fileName)
            : base(folderName, fileName)
        { }

        public override void Load()
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
            {

                if (!isf.DirectoryExists(folderName))
                    return;

                string filePath = Path.Combine(folderName, fileName);
                if (!isf.FileExists(filePath))
                    return;

                using (IsolatedStorageFileStream stream = isf.OpenFile(filePath, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
                    Data = (SaveData)serializer.Deserialize(stream);
                }
            }
        }

        public override void Save()
        {
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null))
            {
                // Create directory if it doesn't exist.
                if (!isf.DirectoryExists(folderName))
                    isf.CreateDirectory(folderName);

                string filePath = Path.Combine(folderName, fileName);
                try
                {
                    using (IsolatedStorageFileStream stream = isf.CreateFile(filePath))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
                        serializer.Serialize(stream, Data);
                    }
                }
                catch (Exception e)
                {
                    
                }
            }
        }
    }
}
