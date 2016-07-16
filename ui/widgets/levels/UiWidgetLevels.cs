using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace com.playspal.core.ui.widgets.levels
{
    public class UiWidgetLevels : UiObject
    {
        private List<UiWidgetLevelsItem> _items = new List<UiWidgetLevelsItem>();

        public int Length = 0;
        public int Index = 0;

        public Action<int> OnClick;
        
        public UiWidgetLevels(GameObject screen, string path = "")
        {
            SetScreen(screen);

            int i;
            int n = 0;

            GameObject gameObject;
            UiWidgetLevelsItem item;

            for(i = 0; i < 50; i++)
            {
                gameObject = Find(path + "b" + i);

                if(gameObject == null)
                {
                    continue;
                }

                item = new UiWidgetLevelsItem(gameObject);
                item.OnClick = OnItemClickHandler;

                _items.Add(item);

                n++;
            }

            SetupItems();
        }

        public void SetIndex(int value)
        {
            Index = value;
            SetupItems();
        }

        public void SetLength(int value)
        {
            Length = value;
            SetupItems();
        }

        private void SetupItems()
        {
            int n = 0;
            int offset = _items.Count * Index;

            foreach (UiWidgetLevelsItem item in _items)
            {
                if (n < Length)
                {
                    item.SetActive(true);
                    item.SetIndex(offset + n);
                    item.SetCaption((offset + n + 1).IntToLeadingZerosString(2));
                }

                else
                {
                    item.SetActive(false);
                }

                n++;
            }
        }

        private void OnItemClickHandler(int n)
        {
            OnClick.InvokeIfNotNull(n);
        }
    }
}
