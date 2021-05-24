namespace Parsing
{
    public interface IUnitFactory
    {
        bool TryConstruct(UnitModel model, out IUnit unit);
    }
}
