namespace Parsing
{
    public sealed class MagFactory : IUnitFactory
    {
        public bool TryConstruct(UnitModel model, out IUnit unit)
        {
            if(model.type.Equals("mag"))
            {
                unit = new MagUnit(model.health);
                return true;
            }
            else
            {
                unit = null;
                return false;
            }
        }
    }
}
