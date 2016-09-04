using UnityEngine;
using System.Collections;

using com.playspal.core.system.services.deffered;
using com.playspal.core.storage;
using com.playspal.core.utils.sound;

namespace com.playspal.core
{
    public class Core
    {
        public static float DeltaSecondsFixed = 1f / 30f;

        public static Storage Storage;

        static Core()
        {
            Storage = Storage.Load();
            //Storage.Save(Storage);
            //Storage = Storage.Load();
        }

        public static void Update()
        {
            DefferedMethods.Process();
        }
    }
}
