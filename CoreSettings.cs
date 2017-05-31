using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace com.playspal.core
{
    public class CoreSettings : MonoBehaviour
    {
        public RectTransform Canvas;
        public List<RectTransform> CanvasLayers = new List<RectTransform>();

        public static CoreSettings Instance
        {
            get
            {
                return FindObjectOfType(typeof(CoreSettings)) as CoreSettings;
            }
        }
    }
}