using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace com.playspal.core.ui.tweens
{
    public class TweenUiAlpha : Tween
    {
        private CanvasGroup _canvasGroup;

        public TweenUiAlpha(GameObject screen, float current, float target, float time)
        {
            _canvasGroup = screen.GetComponent<CanvasGroup>();
            _canvasGroup = _canvasGroup != null ? _canvasGroup : screen.AddComponent<CanvasGroup>();
            _canvasGroup.alpha = current;

            OnTick = OnTickHandler;

            Run(current, target, time);
        }

        private void OnTickHandler(float value)
        {
            _canvasGroup.alpha = value;
        }
    }
}
