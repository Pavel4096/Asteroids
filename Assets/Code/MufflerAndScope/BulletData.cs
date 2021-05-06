using UnityEngine;

namespace MufflerAndScope
{
    public sealed class BulletData
    {
        public Rigidbody instance;
        public float force;
        public float timeToDestruct;

        public BulletData(Rigidbody _instance, float _force, float _timeToDestruct)
        {
            instance = _instance;
            force = _force;
            timeToDestruct = _timeToDestruct;
        }
    }
}
