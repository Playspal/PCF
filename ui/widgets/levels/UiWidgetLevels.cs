using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace com.playspal.core.ui.widgets.levels
{
    public class UiWidgetLevels : UiObject
    {
        private List<UiWidgetLevelsItem> _items = new List<UiWidgetLevelsItem>();

        public Action<int> OnClick;
        
        public UiWidgetLevels(GameObject screen)
        {
            SetScreen(screen);

            int i;
            int n = 0;

            GameObject gameObject;
            UiWidgetLevelsItem item;

            for(i = 0; i < 50; i++)
            {
                gameObject = Find("b" + i);

                if(gameObject == null)
                {
                    continue;
                }

                item = new UiWidgetLevelsItem(gameObject);
                item.SetID(n);
                item.OnClick = OnItemClickHandler;

                _items.Add(item);

                n++;
            }
        }

        private void OnItemClickHandler(int n)
        {
            OnClick.InvokeIfNotNull(n);
        }
    }
}
