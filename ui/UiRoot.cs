using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace com.playspal.core.ui
{
	public class UiRoot
	{
        public static float DefinedScreenWidth = 1280f;

        public static RectTransform layer1
        {
            get
            {
                return GameObject.Find("Canvas/layer1").GetComponent<RectTransform>();
            }
        }

        public static RectTransform layer2
        {
            get
            {
                return GameObject.Find("Canvas/layer2").GetComponent<RectTransform>();
            }
        }

        public static RectTransform canvas
        {
            get
            {
                return GameObject.Find("Canvas").GetComponent<RectTransform>();
            }
        }

        public static float ScaleFactor
        {
            get
            {
                return GameObject.Find("Canvas").GetComponent<Canvas>().scaleFactor;
            }
        }

        public static RectTransform GetLayer(int n)
        {
            return GameObject.Find("Canvas/layer" + n).GetComponent<RectTransform>();
        }
	}
}
