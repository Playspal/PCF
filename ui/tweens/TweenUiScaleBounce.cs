using UnityEngine;
using System.Collections;
using System;

namespace com.playspal.core.ui.tweens
{
    public class TweenUiScaleBounce : Tween
    {
        private RectTransform _rectTransform;

        private float _amplitude = 0.2f;
        private float _frequency = 20;

        public TweenUiScaleBounce(GameObject screen, float time, float amplitude, float frequency)
        {
            _amplitude = amplitude != 0 ? amplitude : 0.05f;
            _frequency = frequency;

            _rectTransform = screen.GetComponent<RectTransform>();

            OnTick = OnTickHandler;

            Run(0, 1, time);
        }

        private void OnTickHandler(float value)
        {
            float e = 2.718281828459045f;
            float scale = -1 * Mathf.Pow(e, -value / _amplitude) * Mathf.Cos(_frequency * value) + 1;

            if (_rectTransform != null)
            {
                _rectTransform.localScale = new Vector3(scale, scale, 1);
            }
        }
    }
}
