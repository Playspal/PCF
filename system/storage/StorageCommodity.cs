using UnityEngine;

using System;

using com.playspal.core.utils.helpers;

namespace com.playspal.core.storage
{
    [Serializable]
    public class StorageCommodity
    {
        /// <summary>
        /// Unique commodity name
        /// </summary>
        public string Name = "Commodity";

        /// <summary>
        /// Current value
        /// </summary>
        public float Value = 0;

        /// <summary>
        /// Maximum value
        /// </summary>
        public float ValueMaximum = 10;

        /// <summary>
        /// Time in seconds required to refill one value
        /// Refill timer disavled if sets to zero
        /// </summary>
        public int RefillDelay = 0;

        /// <summary>
        /// Start time in seconds to calculate refills
        /// Time overwrites when commodity spend
        /// </summary>
        public int RefillTime = 0;

        public bool IsRefillEnabled
        {
            get
            {
                return RefillDelay != 0;
            }
        }

        public int RefillTimeLeft
        {
            get
            {
                return RefillTime + RefillDelay - TimeHelper.GetUnixTimestamp();
            }
        }

        public void Increment(int value = 1)
        {
            Value += value;
            Value = Value > ValueMaximum ? ValueMaximum : Value;

            Core.Storage.Save();
        }

        public void Decrement(int value = 1)
        {
            if(Value <= 0)
            {
                return;
            }

            Value -= value;
            Value = Value < 0 ? 0 : Value;

            if(RefillDelay > 0)
            {
                RefillTime = TimeHelper.GetUnixTimestamp();
            }

            Core.Storage.Save();
        }

        public void Refill()
        {
            if (RefillDelay == 0 || RefillTime == 0)
            {
                return;
            }

            float count = Mathf.Abs((float)RefillTimeLeft / (float)RefillDelay);
            float i;

            if (RefillTimeLeft <= 0)
            {
                for (i = 0; i < count; i++)
                {
                    Increment();

                    if (Value >= ValueMaximum)
                    {
                        RefillTime = 0;
                        break;
                    }

                    else
                    {
                        RefillTime += RefillDelay;
                    }
                }
            }
        }
    }
}
