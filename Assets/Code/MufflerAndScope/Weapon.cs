using UnityEngine;

namespace MufflerAndScope
{
    public sealed class Weapon : IFire
    {
        private BulletData bulletData;
        private Transform bulletTransform;
        private AudioClip audioClip;
        private AudioSource audioSource;

        public Weapon(BulletData _bulletData, Transform _bulletTransform, AudioClip _audioClip, AudioSource _audioSource)
        {
            bulletData = _bulletData;
            bulletTransform = _bulletTransform;
            audioClip = _audioClip;
            audioSource = _audioSource;
        }

        public AudioClip GetAudioClip()
        {
            return audioClip;
        }

        public void SetAudioClip(AudioClip _audioClip)
        {
            audioClip = _audioClip;
        }

        public void Fire()
        {
            var bullet = Object.Instantiate(bulletData.instance, bulletTransform.position, Quaternion.identity);
            bullet.AddForce(bulletTransform.forward * bulletData.force);
            Object.Destroy(bullet.gameObject, bulletData.timeToDestruct);
            audioSource.PlayOneShot(audioClip);
        }
    }
}
