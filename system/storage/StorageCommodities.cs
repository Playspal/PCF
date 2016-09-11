using System;
using System.Collections.Generic;

namespace com.playspal.core.storage
{
    [Serializable]
    public class StorageCommodities
    {
        public List<StorageCommodity> Items = new List<StorageCommodity>();

        public void Setup(string name, float valueDefault, float valueMax, float refillDelay)
        {
            if(GetByName(name) != null)
            {
                return;
            }

            Items.Add
            (
                new StorageCommodity
                {
                    Name = name,

                    Value = valueDefault,
                    ValueMaximum = valueMax,

                    RefillDelay = refillDelay
                }
            );
        }

        public StorageCommodity GetByName(string name)
        {
            foreach(StorageCommodity item in Items)
            {
                if(item.Name == name)
                {
                    return item;
                }
            }

            return null;
        }
    }
}

