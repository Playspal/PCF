using UnityEngine;
using System.Collections;

using com.playspal.core.system.services.deffered;
using com.playspal.core.storage;

namespace com.playspal.core
{
    public class Core
    {
        public static float DeltaTime
        {
            get
            {
                return Mathf.Min(Time.deltaTime, 0.02f);
            }
        }

        public static float Fps
        {
            get
            {
                return CoreFps.Value;
            }
        }

        public static Storage Storage;

        static Core()
        {
        }

        public static void Initialization()
        { 
            Storage = Storage.Load();
        }

        public static void Update()
        {
            DefferedMethods.Process();
            CoreFps.Update();

            Storage.Commodities.Refill();
        }
    }
}
