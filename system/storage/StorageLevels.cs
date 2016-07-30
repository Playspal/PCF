using UnityEngine;

using System.Collections;
using System;

namespace com.playspal.core.storage
{
    [Serializable]
    public class StorageLevels
    {
        public StorageLevel[] Items = new StorageLevel[512];

        public StorageLevels()
        {
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i] = new StorageLevel { Index = i };
            }
        }

        public void SetItem(StorageLevel item)
        {
            Items[item.Index] = item;
        }

        public StorageLevel GetItem(int index)
        {
            if (index < 0 || index >= Items.Length || Items[index] == null)
            {
                return new StorageLevel { Index = index };
            }

            return Items[index];
        }
    }
}
