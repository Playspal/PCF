using System;
using System.Collections.Generic;

namespace com.playspal.core.storage
{
    [Serializable]
    public class StorageCommodities
    {
        public List<StorageCommodity> Items = new List<StorageCommodity>();

        public void Setup(string name, float valueDefault, float valueMax, int refillDelay)
        {
            StorageCommodity item = GetByName(name);

            if (item != null)
            {
                item.ValueMaximum = valueMax;
                item.RefillDelay = refillDelay;

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

        public void Refill()
        {
            foreach (StorageCommodity item in Items)
            {
                item.Refill();
            }
        }
    }
}

