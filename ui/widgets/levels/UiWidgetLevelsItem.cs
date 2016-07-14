using System;
using UnityEngine;

using com.playspal.core.ui.components;

namespace com.playspal.core.ui.widgets.levels
{
    public class UiWidgetLevelsItem : UiObject
    {
        private UiWidgetLevelsItemStars _stars;

        private UiButtonCaption _button;
        private GameObject _lockedIcon;

        private int _itemID;

        public Action<int> OnClick;

        public UiWidgetLevelsItem(GameObject screen)
        {
            if(Find("stars") != null)
            {
                _stars = new UiWidgetLevelsItemStars(Find("stars"));
            }

            _button = new UiButtonCaption(Find("button"));
            _button.OnClick = OnClickHandler;

            _lockedIcon = Find("lockedIcon");
        }

        public void SetID(int value)
        {
            _itemID = value;
        }

        public void SetCaption(string value)
        {
            _button.SetCaption(value);
        }

        public void SetLocked(bool value)
        {
            if(_stars != null)
            {
                _stars.SetActive(!value);   
            }

            _lockedIcon.SetActive(value);
            _button.SetActive(!value);
        }

        public void SetStars(int value)
        {
            if(_stars != null)
            {
                _stars.SetStars(value);   
            }
        }

        private void OnClickHandler()
        {
            OnClick.InvokeIfNotNull(_itemID);
        }
    }
}
