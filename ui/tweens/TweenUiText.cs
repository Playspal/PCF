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
        private string[] _words;

        public TweenUiText(GameObject screen, string message, bool splitByWords, float time)
        {
            _message = message;
            
            _splitByWords = splitByWords;
            _words = _splitByWords ? message.Split(' ') : null;

            _text = screen.GetComponent<Text>();
            _text.supportRichText = true;

            if(splitByWords)
            {
                OnTick = OnTickHandlerWords;
            }

            else
            {
                OnTick = OnTickHandlerLetters;
            }            

            Run(0, 1, splitByWords ? time * _words.Length : time * _message.Length);
        }

        private void OnTickHandlerLetters(float value)
        {
            string output = "";

            int position = (int)((float)_message.Length * value);

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

            if (_text != null)
            {
                _text.text = output;
            }
        }

        private void OnTickHandlerWords(float value)
        {
            string output = "";

            float position = Mathf.Floor(_words.Length * value);

            for (int i = 0; i < _words.Length; i++)
            {
                output += string.IsNullOrEmpty(output) ? "" : " ";
                output += i <= position ? _words[i] : "<color=#FFFFFF00>" + _words[i] + "</color>";
            }

            if (_text != null)
            {
                _text.text = output;
            }
        }
    }
}
