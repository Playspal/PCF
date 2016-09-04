using UnityEngine;
using System.Collections;

using com.playspal.core.ui.tweens;

namespace com.playspal.core.ui
{
	public class UiMenu : UiObject
	{
		// Is menu active and visible now
		public bool IsActive = false;

		// If true, menu don't will be autohided
		// Great to headers, backgrounds etc
		public bool IsSticky = false;

		public int LayerID = 0;
		public int LayoutID = 0;

        public virtual void Show()
        {
            IsActive = true;

            Screen.SetActive(true);

            TweenUiAlpha tween = new TweenUiAlpha(Screen, 0, 1, 0.25f);
        }

        public virtual void Hide()
        {
            if (!IsActive)
            {
                return;
            }

            TweenUiAlpha tween = new TweenUiAlpha(Screen, 1, 0, 0.25f);

            tween.OnComplete = (float value) =>
            {
                HideDirect();
            };
        }

        public virtual void HideDirect()
        {
            IsActive = false;

            Screen.SetActive(false);
        }

        public virtual void Update()
        {
        }
	}
}
