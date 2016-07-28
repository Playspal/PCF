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

        public static void Play(string name, SoundOptions options = null)
        {
            if(!Enabled)
            {
                return;
            }

            SoundItem item = GetItemOrCreateNew(name);
            item.Play(options);
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
