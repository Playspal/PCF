using UnityEngine;

namespace com.playspal.core.ui.widgets.levels
{
	public class UiWidgetLevelsItemStars : UiObject
	{
		private UiWidgetLevelsItemStar _star1;
		private UiWidgetLevelsItemStar _star2;
		private UiWidgetLevelsItemStar _star3;

		public UiWidgetLevelsItemStars(GameObject screen)
		{
			SetScreen(screen);

			_star1 = new UiWidgetLevelsItemStar(Find("star1"));
			_star2 = new UiWidgetLevelsItemStar(Find("star2"));
			_star3 = new UiWidgetLevelsItemStar(Find("star3"));

            SetStars(0);
		}

		public void SetStars(int value)
		{
			_star1.SetWhiteActive(value >= 1);
			_star2.SetWhiteActive(value >= 2);
			_star3.SetWhiteActive(value >= 3);
		}
	}
}
