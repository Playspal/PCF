using UnityEngine;
using System.Collections;

namespace com.playspal.core.ui
{
	public class UiMenu : UiObject
	{
		// Is menu active and visible now
		public bool IsActive = false;

		// If true, menu don't will be autohided
		// Great to headers, backgrounds etc
		public bool IsSticky = false;

		public int LayerID = 0;
		public int LayoutID = 0;

		public virtual void Show()
		{
			
		}

		public virtual void Hide()
		{
			
		}
	}
}
