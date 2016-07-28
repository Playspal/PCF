using UnityEngine;
using System.Collections;

using com.playspal.core.ui.tweens;

namespace com.playspal.core.ui
{
    public class UiPopup : UiObject
    {
        public GameObject Content;
        public RectTransform ContentTransform;

        public void SetContent(GameObject target)
        {
            Content = target;
            ContentTransform = Content.GetComponent<RectTransform>();
        }

        public void Show()
        {
            TweenUiAlpha tweenAlpha = new TweenUiAlpha(Screen, 0, 1, 0.25f);
            TweenUiScale tweenScale = new TweenUiScale(Content, 0.95f, 1.0f, 0.25f);
        }

        public void Hide()
        {
            TweenUiAlpha tweenAlpha = new TweenUiAlpha(Screen, 1, 0, 0.25f);
            TweenUiScale tweenScale = new TweenUiScale(Content, 1.0f, 0.95f, 0.25f);

            tweenAlpha.OnComplete = delegate(float value)
            {
                Destroy();
            };
        }
    }
}
