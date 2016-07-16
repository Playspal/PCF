using UnityEngine;
using System.Collections;

namespace com.playspal.core.ui.widgets.paginator
{
    public class UiWidgetPaginatorItem : UiObject
    {
        private GameObject _normal;
        private GameObject _selected;

        public UiWidgetPaginatorItem(GameObject screen)
        {
            SetScreen(screen);

            _normal = Find("normal");
            _selected = Find("selected");
        }

        public void SetSelected(bool value)
        {
            _normal.SetActive(!value);
            _selected.SetActive(value);
        }
    }
}
