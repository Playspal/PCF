using UnityEngine;
using System.Collections;

namespace com.playspal.core.ui
{
	public class Ui
	{
        public UiMenu CurrentMenu = null;

        public void SetActiveMenu(UiMenu menu)
        {
            if (CurrentMenu == menu && menu.IsActive)
            {
                return;
            }

            if (CurrentMenu != null)
            {
                CurrentMenu.Hide();
            }

            CurrentMenu = menu;
            CurrentMenu.Show();
        }

        public void HideAll()
        {
            HideCurrent();
        }

        public void HideCurrent()
        {
            if (CurrentMenu != null)
            {
                CurrentMenu.Hide();
                CurrentMenu = null;
            }
        }

        public virtual void Update()
        {
            if (CurrentMenu != null)
            {
                CurrentMenu.Update();
            }
        }
	}
}
