namespace Asteroids
{
    public sealed class BulletBuilder
    {
        private BulletController bulletController;

        public BulletBuilder(Game gameView)
        {
            BulletModel model = new BulletModel();
            bulletController = new BulletController(model, gameView.CreateView(model.Name));
        }

        public BulletBuilder SetMoveForce(float _moveForce)
        {
            bulletController.model.MoveForce = _moveForce;
            return this;
        }

        public BulletBuilder SetDamage(float _damage)
        {
            bulletController.model.Damage = _damage;
            return this;
        }

        public static implicit operator BulletController(BulletBuilder bulletBuilder)
        {
            return bulletBuilder.bulletController;
        }
    }
}
