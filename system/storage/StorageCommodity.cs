using System;

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
        public float RefillDelay = 0;

        /// <summary>
        /// Start time in seconds to calculate refills
        /// Time overwrites when commodity spend
        /// </summary>
        public float RefillTime = 0;
    }
}
