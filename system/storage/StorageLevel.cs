using UnityEngine;
using System.Collections;
using System;

namespace com.playspal.core.storage
{
    [Serializable]
    public class StorageLevel : StorageObject
    {
        /// <summary>
        /// Index of level
        /// </summary>
        public int Index = 0;

        /// <summary>
        /// Is level completed
        /// </summary>
        public bool Completed = false;

        /// <summary>
        /// Best result
        /// </summary>
        public int ScoreEarned = 0;

        /// <summary>
        /// Stars earned 
        /// </summary>
        public int StarsEarned = 0;

        /// <summary>
        /// Elapsed time on seconds
        /// </summary>
        public int TimeElapsed = 0;
    }
}
