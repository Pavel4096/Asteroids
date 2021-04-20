using System;
using UnityEngine;

namespace Asteroids
{
    public interface IView
    {
        Rigidbody2D Rigidbody2D { get; }
        event Action<Collision2D> CollidedEvent;
    }
}
