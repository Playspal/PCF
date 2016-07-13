using UnityEngine;

using System;
using System.Collections;

namespace com.playspal.core.ui.components
{
    public class UiButton
    {
        internal GameObject _screen;

        internal GameObject _hover;
        internal GameObject _normal;

        private float _lastClickTime = 0.0f;
        private float _clickInterval = 1.0f;

        public bool IsEnabled = true;

        public Action OnClick = null;

        public UiButton(GameObject screen)
        {
            _screen = screen;

            _normal = screen.transform.Find("normal").gameObject;
            _hover = screen.transform.Find("hover").gameObject;

            UiEvents.AddMouseOverListener(screen, OnMouseOverHandler);
            UiEvents.AddMouseOutListener(screen, OnMouseOutHandler);
            UiEvents.AddClickListener(screen, OnClickHandler);

            OnMouseOutHandler();
        }

        public void SetActive(bool value)
        {
            _screen.SetActive(value);
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
