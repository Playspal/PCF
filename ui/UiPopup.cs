using UnityEngine;
using System.Collections;

using com.playspal.core.ui.tweens;
using com.playspal.core.utils.sound;

namespace com.playspal.core.ui
{
    public class UiPopup : UiObject
    {
        public GameObject Content;
        public RectTransform ContentTransform;

        private string _popupSoundName;

        public void SetContent(GameObject target)
        {
            Content = target;
            ContentTransform = Content.GetComponent<RectTransform>();
        }

        public void SetPopupSound(string value)
        {
            _popupSoundName = value;
        }

        public void Show()
        {
            UiPopupsManager.Add(this);

            TweenUiAlpha tweenAlpha = new TweenUiAlpha(Screen, 0, 1, 0.25f);
            TweenUiScale tweenScale = new TweenUiScale(Content, 0.95f, 1.0f, 0.25f);

            if (!string.IsNullOrEmpty(_popupSoundName))
            {
                Sound.Play(_popupSoundName);
            }

            else if (!string.IsNullOrEmpty(UiSettings.DefaultPopupSound))
            {
                Sound.Play(UiSettings.DefaultPopupSound);
            }
        }

        public void Hide()
        {
            TweenUiAlpha tweenAlpha = new TweenUiAlpha(Screen, 1, 0, 0.25f);
            TweenUiScale tweenScale = new TweenUiScale(Content, 1.0f, 0.95f, 0.25f);

            tweenAlpha.OnComplete = delegate(float value)
            {
                UiPopupsManager.Remove(this);
                Destroy();
            };
        }
    }
}
