using System;

using UnityEngine;
using UnityEngine.UI;

namespace com.playspal.core.ui.components
{
    public class UiButtonCaption : UiButton
    {
        protected Text _caption;

        public UiButtonCaption(GameObject screen, string caption = "", Action onClick = null) : base(screen, onClick)
        {
            _caption = Find("caption").GetComponent<Text>();

            if(!string.IsNullOrEmpty(caption))
            {
                SetCaption(caption);
            }
        }

        public void SetCaption(string value)
        {
            _caption.text = value.ToUpper();
        }
    }
}
