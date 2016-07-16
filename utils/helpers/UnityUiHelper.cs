using UnityEngine;
using UnityEngine.UI;

namespace com.playspal.core.utils.helpers
{
    public class UnityUiHelper
    {
        public static RectTransform CreateEmpty(string name = "empty")
        {
            GameObject container = new GameObject(name);

            container.AddComponent<RectTransform>();
            container.AddComponent<CanvasRenderer>();

            return container.GetComponent<RectTransform>();
        }

        public static GameObject Instantiate(string path)
        {
            GameObject prefabSrc = Resources.Load(path) as GameObject;
            GameObject prefab = Object.Instantiate(prefabSrc) as GameObject;

            RectTransform prefabTransform = prefab.GetComponent<RectTransform>();

            prefabTransform.SetParent(null);
            prefabTransform.localScale = new Vector3(1, 1, 1);
            prefabTransform.anchoredPosition = new Vector3(0, 0, 0);
            prefabTransform.offsetMin = Vector2.zero;
            prefabTransform.offsetMax = Vector2.zero;

            return prefab;
        }
    }
}
