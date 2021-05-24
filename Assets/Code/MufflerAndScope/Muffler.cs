using UnityEngine;

namespace MufflerAndScope
{
    public sealed class Muffler
    {
        public AudioClip mufflerAudioClip;
        public Transform mufflerTransform;
        public GameObject instance;

        public Muffler(AudioClip _mufflerAudioClip, Transform _mufflerTransform, GameObject _instance)
        {
            mufflerAudioClip = _mufflerAudioClip;
            mufflerTransform = _mufflerTransform;
            instance = _instance;
        }
    }
}
