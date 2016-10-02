using UnityEngine;
using System.Collections;

namespace com.playspal.core.ui.tweens
{
    public class TweenUiScale : Tween
    {
        private RectTransform _rectTransform;

        public TweenUiScale(GameObject screen, float current, float target, float time)
        {
            _rectTransform = screen.GetComponent<RectTransform>();

            OnTick = OnTickHandler;

            Run(current, target, time);
        }

        private void OnTickHandler(float value)
        {
            if (_rectTransform != null)
            {
                _rectTransform.localScale = new Vector3(value, value, 1);
            }
        }
    }
}
