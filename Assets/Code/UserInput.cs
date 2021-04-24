namespace Asteroids
{
    public struct UserInput
    {
        public float Vertical { get; }
        public float Horizontal { get; }
        public bool Fire { get; }

        public UserInput(float vertical_, float horizontal_, bool fire_)
        {
            Vertical = vertical_;
            Horizontal = horizontal_;
            Fire = fire_;
        }
    }
}
