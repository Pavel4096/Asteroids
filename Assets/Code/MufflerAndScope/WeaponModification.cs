namespace MufflerAndScope
{
    public abstract class WeaponModification : IFire
    {
        private Weapon weapon;

        protected abstract Weapon AddModification(Weapon weapon);
        protected abstract Weapon RemoveModification(Weapon weapon);

        public void ApplyModification(Weapon _weapon)
        {
            weapon = AddModification(_weapon);
        }

        public void Fire()
        {
            weapon.Fire();
        }
    }
}
