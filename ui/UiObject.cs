using UnityEngine;
using System.Collections;

namespace com.playspal.core.ui
{
	public class UiObject
	{
        public GameObject Screen;
        public RectTransform ScreenTransform;

        public bool IsDestroyed = false;

        public void Destroy()
        {
            IsDestroyed = true;

            Object.Destroy(Screen);
        }

        public void SetScreen(GameObject target)
        {
            Screen = target;
            ScreenTransform = Screen.GetComponent<RectTransform>();
        }

        public void LoadScreenSimple(string path)
        {
            GameObject screenSrc = Resources.Load(path) as GameObject;

            Screen = Object.Instantiate(screenSrc) as GameObject;
            ScreenTransform = Screen.GetComponent<RectTransform>();
        }

        public void LoadScreen(string path, int layer = 1)
        {
            GameObject screenSrc = Resources.Load(path) as GameObject;

            Screen = Object.Instantiate(screenSrc) as GameObject;
            ScreenTransform = Screen.GetComponent<RectTransform>();
            ScreenTransform.SetParent(UiRoot.GetLayer(layer));
            ScreenTransform.localScale = new Vector3(1, 1, 1);
            ScreenTransform.anchoredPosition = new Vector3(0, 0, 0);
            ScreenTransform.offsetMin = Vector2.zero;
            ScreenTransform.offsetMax = Vector2.zero;
        }

        public void SetRotation(float value)
        {
            Quaternion rotation = ScreenTransform.localRotation;
            Vector3 euler = rotation.eulerAngles;

            euler.z = value;

            rotation.eulerAngles = euler;
            ScreenTransform.localRotation = rotation;
        }

        public void SetSize(float x, float y)
        {
            ScreenTransform.sizeDelta = new Vector2(x, y);
        }

        public void SetScale(float x, float y)
        {
            ScreenTransform.localScale = new Vector2(x, y);
        }

        public void SetScale(float value)
        {
            SetScale(value, value);
        }

        public void SetParent(RectTransform parent)
        {
            ScreenTransform.SetParent(parent);
            
            SetScale(1, 1);
            SetPosition(0, 0);
        }

        public void SetPosition(float x, float y)
        {
            ScreenTransform.anchoredPosition = new Vector3(x, y, 0);
        }

        public void SetActive(bool value)
        {
            Screen.SetActive(value);
        }

        public GameObject Find(string name)
        {
            return ScreenTransform.Find(name).gameObject;
        }
	}
}
