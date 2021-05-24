using System;
using UnityEngine;

namespace Asteroids
{
    public sealed class View : MonoBehaviour, IView
    {
        private Transform viewTransform;
        private Rigidbody2D viewRigidbody;

        public bool IsActive
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        public Transform Transform
        {
            get
            {
                if(viewTransform == null)
                    viewTransform = gameObject.GetComponent<Transform>();

                return viewTransform;
            }
        }

        public Rigidbody2D Rigidbody2D
        {
            get
            {
                if(viewRigidbody == null)
                    viewRigidbody = gameObject.GetComponent<Rigidbody2D>();

                return viewRigidbody;
            }
        }

        public event Action<Collision2D> CollidedEvent;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            CollidedEvent?.Invoke(collision);
        }
    }
}
