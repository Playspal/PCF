using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace com.playspal.core.localization
{
    public class LocalizationComponentText : MonoBehaviour
    {
        public string Key;

        public void Start()
        {
            Localization.OnLanguageChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged()
        {
            GetComponent<Text>().text = Localization.Get(Key);
        }
    }
}