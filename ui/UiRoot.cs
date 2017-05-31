using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace com.playspal.core.ui
{
	public class UiRoot
	{
        public static float DefinedScreenWidth = 1280f;

        public static RectTransform canvas
        {
            get
            {
                return CoreSettings.Instance.Canvas;
            }
        }

        public static float ScaleFactor
        {
            get
            {
                return CoreSettings.Instance.Canvas.GetComponent<Canvas>().scaleFactor;
            }
        }

        public static RectTransform GetLayer(int n)
        {
            return CoreSettings.Instance.CanvasLayers[n - 1];
        }
	}
}
