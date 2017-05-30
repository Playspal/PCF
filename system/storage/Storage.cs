using UnityEngine;

using System;
using System.IO;
using System.Collections;

using com.playspal.core.utils;
using com.playspal.core.utils.helpers;

namespace com.playspal.core.storage
{
    [Serializable]
    public class Storage
    {
        public const string STORAGE_FILE_NAME = "storage.dat";

        public int Score = 0;
        public StorageLevels Levels;
        public StorageCommodities Commodities;

        public Storage()
        {
            Levels = new StorageLevels();
            Commodities = new StorageCommodities();
        }

        public void Save()
        {
            Save(this);
        }

        public static void Save(Storage storage)
        {
            string xml = Serialization.ObjectToXML(storage);
            string filepath = UnityFileSystemHelper.RootDirectory + STORAGE_FILE_NAME;

            File.WriteAllText(filepath, xml);
        }

        public static Storage Load()
        {
            string filepath = UnityFileSystemHelper.RootDirectory + STORAGE_FILE_NAME;

            if (File.Exists(filepath))
            {
                string xml = File.ReadAllText(filepath);
                return Serialization.XMLToObject(xml, typeof(Storage)) as Storage;
            }

            return new Storage();
        }
    }
}
