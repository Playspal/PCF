using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace com.playspal.core.ui
{
	public class UiLayout
	{
		public UiMenu CurrentMenu = null;
		public List<UiMenu> Childs = new List<UiMenu>();

		public void AddChild(UiMenu menu)
		{
			Childs.Add(menu);
		}

		public void RemoveChild(UiMenu menu)
		{
			Childs.Remove(menu);
		}

		public void ActivateChild(UiMenu menu)
		{
			if(CurrentMenu == menu && menu.IsActive)
			{
				return;
			}

			HideCurrent();

			CurrentMenu = menu;
			CurrentMenu.Show();
		}

		public void HideCurrent()
		{
			if(CurrentMenu != null)
			{
				CurrentMenu.Hide();
			}
		}

		public void HideAll()
		{
			foreach (UiMenu menu in Childs)
			{
				if(menu.IsSticky)
				{
					continue;
				}

				menu.Hide();
			}
		}
	}
}
