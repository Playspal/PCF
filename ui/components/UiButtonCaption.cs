using System;

using UnityEngine;
using UnityEngine.UI;

namespace com.playspal.core.ui.components
{
    public class UiButtonCaption : UiButton
    {
        protected Text _caption;
        protected Text _captionNormal;
        protected Text _captionHover;

        public UiButtonCaption(GameObject screen, string caption = "", Action onClick = null) : base(screen, onClick)
        {
            _caption = FindText("caption");
            _captionNormal = FindText("normal/caption");
            _captionHover = FindText("hover/caption");

            if (!string.IsNullOrEmpty(caption))
            {
                SetCaption(caption);
            }
        }

        public void SetCaption(string value)
        {
            if (_caption != null)
            {
                _caption.text = value;
            }

            if (_captionNormal != null)
            {
                _captionNormal.text = value;
            }

            if (_captionHover != null)
            {
                _captionHover.text = value;
            }
        }
    }
}
