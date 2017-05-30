using UnityEngine;
using System.Collections;

namespace com.playspal.core.ui.tweens
{
    public class TweenUiPosition : Tween
    {
        private RectTransform _rectTransform;

        public TweenUiPosition(GameObject screen, float current, float target, float time)
        {
            _rectTransform = screen.GetComponent<RectTransform>();

            OnTick = OnTickHandler;

            Run(current, target, time);
        }

        private void OnTickHandler(float value)
        {
            if (_rectTransform != null)
            {
                _rectTransform.anchoredPosition = new Vector2(value, _rectTransform.anchoredPosition.y);
            }
        }
    }
}
