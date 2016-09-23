using System.Collections.Generic;

namespace com.playspal.core.ui
{
    public class UiPopupsManager
    {
        public static List<UiPopup> PopupsShown = new List<UiPopup>();

        public static void HideAll()
        {
            foreach (UiPopup popup in PopupsShown)
            {
                popup.Hide();
            }
        }

        public static void Add(UiPopup target)
        {
            foreach (UiPopup popup in PopupsShown)
            {
                if (popup == target)
                {
                    return;
                }
            }

            PopupsShown.Add(target);
        }

        public static void Remove(UiPopup target)
        {
            PopupsShown.Remove(target);
        }
    }
}
