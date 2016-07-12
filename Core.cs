using UnityEngine;
using System.Collections;

using com.playspal.core.system.services.deffered;

namespace com.playspal.core
{
    public class Core
    {
        public static float DeltaSecondsFixed = 1f / 30f;

        public static void Update()
        {
            DefferedMethods.Process();
        }
    }
}
