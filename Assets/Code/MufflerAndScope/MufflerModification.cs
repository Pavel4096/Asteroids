using UnityEngine;

namespace MufflerAndScope
{
    public sealed class MufflerModification : WeaponModification
    {
        private Muffler muffler;
        private Transform mufflerTransform;
        
        private GameObject mufflerObject;
        private AudioClip weaponAudioClip;

        public MufflerModification(Muffler _muffler, Transform _mufflerTransform)
        {
            muffler = _muffler;
            mufflerTransform = _mufflerTransform;
        }

        protected override Weapon AddModification(Weapon weapon)
        {
            mufflerObject = Object.Instantiate(muffler.instance, mufflerTransform.position, Quaternion.identity);
            weaponAudioClip = weapon.GetAudioClip();
            weapon.SetAudioClip(muffler.mufflerAudioClip);
            
            return weapon;
        }

        protected override Weapon RemoveModification(Weapon weapon)
        {
            Object.Destroy(mufflerObject);
            weapon.SetAudioClip(weaponAudioClip);

            return weapon;
        }
    }
}
