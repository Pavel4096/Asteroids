namespace Asteroids
{
    public sealed class FireLock
    {
        public bool IsLocked { get; private set; } = false;

        public void Lock()
        {
            IsLocked = true;
        }

        public void Unlock()
        {
            IsLocked = false;
        }
    }
}
