using UnityEngine;
using UnityEngine.UI;

namespace com.playspal.core.ui.components
{
    public class UiButtonCaption : UiButton
    {
        protected Text _caption;

        public UiButtonCaption(GameObject screen) : base(screen)
        {
            _caption = Find("caption").GetComponent<Text>();
        }

        public void SetCaption(string value)
        {
            _caption.text = value.ToUpper();
        }
    }
}
