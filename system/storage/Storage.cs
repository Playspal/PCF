using UnityEngine;

using System;
using System.IO;
using System.Collections;

using com.playspal.core.utils;
using System.Text;

namespace com.playspal.core.storage
{
    [Serializable]
    public class Storage
    {
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
            string filepath = Application.dataPath + "/storage.dat";
            string xml = Serialization.ObjectToXML(storage);

            File.WriteAllText(filepath, xml);
        }

        public static Storage Load()
        {
            string filepath = Application.dataPath + "/storage.dat";

            if (File.Exists(filepath))
            {
                string xml = File.ReadAllText(filepath);
                return Serialization.XMLToObject(xml, typeof(Storage)) as Storage;
            }

            return new Storage();
        }
    }
}
