using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace com.playspal.core.utils.sound
{
    public class Sound
    {
        private static GameObject _container;
        private static Transform _containerTransform;

        private static List<SoundItem> _items = new List<SoundItem>();

        public static bool Enabled = true;

        static Sound()
        {
            _container = new GameObject("SoundContainer");
            _containerTransform = _container.transform;
        }

        public static void SetEnabled(bool value)
        {
            Debug.LogError(value);
            Enabled = value;
            SetMuteAll(!value);
        }

        public static void Play(string name, SoundOptions options = null)
        {
            if(!Enabled)
            {
                return;
            }

            SoundItem item = GetItemOrCreateNew(name);
            item.Play(options);
        }

        public static void Stop(string name)
        {
            SoundItem item = GetItem(name);

            if(item != null)
            {
                item.Stop();
            }
        }

        public static void StopAll()
        {
            foreach (SoundItem item in _items)
            {
                item.Stop();
            }
        }

        public static void SetMuteAll(bool value)
        {
            foreach (SoundItem item in _items)
            {
                item.SetMute(value);
            }
        }

        private static SoundItem GetItemOrCreateNew(string name)
        {
            SoundItem output = GetItem(name);
            output = output != null ? output : CreateItem(name);

            return output;
        }

        private static SoundItem GetItem(string name)
        {
            SoundItem output = null;

            foreach(SoundItem item in _items)
            {
                if (item.Name == name && item.IsReadyToPlay)
                {
                    output = item;
                }
            }

            return output;
        }

        private static SoundItem CreateItem(string name)
        {
            SoundItem item = new SoundItem(name);
            item.SetParent(_containerTransform);

            _items.Add(item);

            return item;
        }
    }
}
