namespace Parsing
{
    public sealed class InfantryFactory : IUnitFactory
    {
        public bool TryConstruct(UnitModel model, out IUnit unit)
        {
            if(model.type.Equals("infantry"))
            {
                unit = new InfantryUnit(model.health);
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
