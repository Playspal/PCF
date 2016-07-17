using UnityEngine;
using System.Collections.Generic;

namespace com.playspal.core.ui.widgets.paginator
{
    public class UiWidgetPaginator : UiObject
    {
        private List<UiWidgetPaginatorItem> _items = new List<UiWidgetPaginatorItem>();

        public UiWidgetPaginator(GameObject screen, string path = "")
        {
            SetScreen(screen);

            int i;
            int n = 0;

            GameObject gameObject;
            UiWidgetPaginatorItem item;

            for (i = 0; i < 50; i++)
            {
                gameObject = Find(path + "p" + i);

                if (gameObject == null)
                {
                    continue;
                }

                item = new UiWidgetPaginatorItem(gameObject);

                _items.Add(item);

                n++;
            }

            SetLength(0);
            SetPage(0);
        }

        public void SetPage(int value)
        {
            int n = 0;

            foreach (UiWidgetPaginatorItem item in _items)
            {
                item.SetSelected(n == value);
                n++;
            }
        }

        public void SetLength(int value)
        {
            int n = 0;

            foreach (UiWidgetPaginatorItem item in _items)
            {
                item.SetActive(n < value && value > 1);
                n++;
            }

            // Adjust to center of screen
            ScreenTransform.anchoredPosition = new Vector2(UiRoot.DefinedScreenWidth / 2f - value * 90 * 0.5f, ScreenTransform.anchoredPosition.y);
        }
    }
}