namespace Asteroids
{
    public sealed class BulletController
    {
        public BulletModel model;
        public IView view;

        public BulletController(BulletModel _model, IView _view)
        {
            model = _model;
            view = _view;
        }
    }
}
