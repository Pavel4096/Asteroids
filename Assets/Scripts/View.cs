using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class View : MonoBehaviour, IView
    {
        public bool IsActive
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        public Rigidbody2D Rigidbody2D
        {
            get => gameObject.GetComponent<Rigidbody2D>();
        }

        public event Action<Collision2D> CollidedEvent;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            CollidedEvent?.Invoke(collision);
        }
    }
}
