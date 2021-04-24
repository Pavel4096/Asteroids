using System;

namespace Asteroids
{
    public sealed class NoViewException : Exception
    {
        public NoViewException(string name) : base($"No view in '{name}' object.")
        {
        }
    }
}
