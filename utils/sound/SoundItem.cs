﻿using UnityEngine;
using System.Collections;

namespace com.playspal.core.utils.sound
{
    public class SoundItem
    {
        public string Name = "";

        public AudioClip AudioClip;
        public AudioSource AudioSource;

        public SoundOptions SoundOptions;

        public bool IsMusic = false;

        public bool IsReadyToPlay
        {
            get
            {
                return !AudioSource.isPlaying;
            }
        }

        private GameObject _container;
        private Transform _containerTransform;

        public SoundItem(string name)
        {
            Name = name;

            _container = new GameObject("SoundItem");
            _containerTransform = _container.transform;

            AudioClip = Resources.Load(name) as AudioClip;
            AudioSource = _container.AddComponent<AudioSource>();
            AudioSource.clip = AudioClip;
        }

        public void SetParent(Transform parent)
        {
            _containerTransform.SetParent(parent);
        }

        public void SetMute(bool value)
        {
            AudioSource.mute = value;
        }

        public void Play(SoundOptions options = null)
        {
            if (options != null)
            {
                AudioSource.volume = options.Volume;
                AudioSource.pitch = options.Pitch;
                AudioSource.loop = options.Loop;
            }

            SoundOptions = options;

            AudioSource.Play();
        }

        public void Stop()
        {
            AudioSource.Stop();
        }


    }
}
