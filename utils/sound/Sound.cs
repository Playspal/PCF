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

        public static bool IsEnabledSound = true;
        public static bool IsEnabledMusic = true;

        static Sound()
        {
            _container = new GameObject("SoundContainer");
            _containerTransform = _container.transform;
        }

        public static void SetSoundEnabled(bool value)
        {
            IsEnabledSound = value;
            SetMuteSound(!value);
        }

        public static void SetMusicEnabled(bool value)
        {
            IsEnabledMusic = value;
            SetMuteMusic(!value);
        }

        public static void Play(string name, SoundOptions options = null)
        {
            if(!IsEnabledSound)
            {
                return;
            }

            SoundItem item = GetItemOrCreateNew(name, false);
            item.Play(options);
        }

        public static void PlayMusic(string name, SoundOptions options = null)
        {
            if (!IsEnabledMusic)
            {
                return;
            }

            SoundItem item = GetItemOrCreateNew(name, true);
            item.Play(options);
        }

        public static void Stop(string name)
        {
            SoundItem item = GetItemDirect(name);

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

        public static void SetMuteSound(bool value)
        {
            SetMute(value, null);
        }

        public static void SetMuteMusic(bool value)
        {
            SetMute(null, value);
        }

        private static void SetMute(bool? sound, bool? music)
        {
            foreach (SoundItem item in _items)
            {
                if (item.IsMusic && music != null)
                {
                    item.SetMute((bool)music);
                }

                if (!item.IsMusic && sound != null)
                {
                    item.SetMute((bool)sound);
                }
            }
        }

        private static SoundItem GetItemOrCreateNew(string name, bool isMusic)
        {
            SoundItem output = GetItemFromPool(name);

            output = output != null ? output : CreateItem(name, isMusic);

            return output;
        }

        private static SoundItem GetItemFromPool(string name)
        {
            return _items.Find(x => x.Name == name && x.IsReadyToPlay);
        }

        private static SoundItem GetItemDirect(string name)
        {
            return _items.Find(x => x.Name == name);
        }

        private static SoundItem CreateItem(string name, bool isMusic)
        {
            SoundItem item = new SoundItem(name);

            item.SetParent(_containerTransform);
            item.IsMusic = isMusic;

            _items.Add(item);

            return item;
        }
    }
}
