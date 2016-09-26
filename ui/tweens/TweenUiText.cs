using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System;

namespace com.playspal.core.ui.tweens
{
    public class TweenUiText : Tween
    {
        private Text _text;
        private string _message;

        private bool _splitByWords = false;

        public TweenUiText(GameObject screen, string message, bool splitByWords, float time)
        {
            _message = message;
            _splitByWords = splitByWords;

            _text = screen.GetComponent<Text>();
            _text.supportRichText = true;
            
            OnTick = OnTickHandler;

            Run(0, 1, time);
        }

        private void OnTickHandler(float value)
        {
            int index = (int)((float)_message.Length * value);
            int position = _splitByWords ? _message.IndexOf(' ', index) : index;

            string output = "";

            if (value < 1)
            {
                output = "";
                output += _message.Substring(0, position);
                output += "<color=#FFFFFF00>" + _message.Substring(position) + "</color>";
            }

            else
            {
                output = _message;
            }

            _text.text = output;
        }
    }
}
