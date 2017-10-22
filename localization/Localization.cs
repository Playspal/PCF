using System;
using System.Collections.Generic;

namespace com.playspal.core.localization
{
    public class Localization
    {
        public static Action OnLanguageChanged;

        private static Dictionary<string, string> _data = new Dictionary<string, string>();

        public static void SetLanguage()
        {
            OnLanguageChanged.InvokeIfNotNull();
        }

        public static string Get(string key)
        {
            if (_data.ContainsKey(key))
            {
                return _data[key];
            }

            return "";
        }
    }
}