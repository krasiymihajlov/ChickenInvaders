namespace Space_Invaders.Models.Entities
{
    using Space_Invaders.Interfaces.Globals;

    public abstract class Entity : Drawable, IEntity
    {
        protected Entity()
        {
        }

        protected Entity(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
        }

        public bool BulletIsActivated { get; protected set; }

        public bool GetWeaponState()
        {
            return this.BulletIsActivated;
        }

        public void SendWeaponState(bool isActivated)
        {
            this.BulletIsActivated = isActivated;
        }
    }
}
