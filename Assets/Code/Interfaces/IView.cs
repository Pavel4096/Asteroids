using System;
using UnityEngine;

namespace Asteroids
{
    public interface IView
    {
        bool IsActive { get; set; }
        Rigidbody2D Rigidbody2D { get; }
        event Action<Collision2D> CollidedEvent;
    }
}
