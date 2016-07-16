using UnityEngine;

using System;
using System.Collections;

namespace com.playspal.core.ui.components
{
    public class UiButton : UiObject
    {
        protected GameObject _hover;
        protected GameObject _normal;

        private float _lastClickTime = 0.0f;
        private float _clickInterval = 1.0f;

        public bool IsEnabled = true;

        public Action OnClick = null;

        public UiButton(GameObject screen)
        {
            SetScreen(screen);

            _normal = Screen.transform.Find("normal").gameObject;
            _hover = Screen.transform.Find("hover").gameObject;

            UiEvents.AddMouseOverListener(Screen, OnMouseOverHandler);
            UiEvents.AddMouseOutListener(Screen, OnMouseOutHandler);
            UiEvents.AddClickListener(Screen, OnClickHandler);

            OnMouseOutHandler();
        }

        public void SetEnabled(bool value)
        {
            OnMouseOutHandler();

            IsEnabled = value;
        }

        public void SetClickInterval(float value)
        {
            _clickInterval = value;
        }

        private void OnMouseOverHandler()
        {
            if (!IsEnabled)
            {
                return;
            }

            _normal.SetActive(false);
            _hover.SetActive(true);
        }

        private void OnMouseOutHandler()
        {
            if (!IsEnabled)
            {
                return;
            }

            _normal.SetActive(true);
            _hover.SetActive(false);
        }

        private void OnClickHandler()
        {
            OnMouseOutHandler();

            if (!IsEnabled)
            {
                return;
            }

            if (Time.realtimeSinceStartup - _lastClickTime < _clickInterval)
            {
                return;
            }

            _lastClickTime = Time.realtimeSinceStartup;

            OnClick.InvokeIfNotNull();
        }
    }
}
