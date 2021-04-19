namespace Asteroids
{
    public struct UserInput
    {
        public float vertical;
        public float horizontal;
        public bool fire;

        public UserInput(float vertical_, float horizontal_, bool fire_)
        {
            vertical = vertical_;
            horizontal = horizontal_;
            fire = fire_;
        }
    }
}
