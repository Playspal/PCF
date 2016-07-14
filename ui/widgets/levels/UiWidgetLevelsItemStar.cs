using UnityEngine;

namespace com.playspal.core.ui.widgets.levels
{
	public class UiWidgetLevelsItemStar : UiObject
	{
		private GameObject _black;
		private GameObject _white;

		public UiWidgetLevelsItemStar(GameObject screen)
		{
			SetScreen(screen);

			_black = Find("black");
			_white = Find("white");
		}

		public void SetWhiteActive(bool value)
		{
			_white.SetActive(value);
		}
	}
}
