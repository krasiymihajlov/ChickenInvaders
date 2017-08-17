namespace Space_Invaders.Models.Enimies
{
    using Microsoft.Xna.Framework;
    using Space_Invaders.Interfaces.Globals;
    using Space_Invaders.Interfaces.Models.Enemies;
    using Space_Invaders.Models.Entities;

    public abstract class EnemyArmy : Entity, IEnemyArmy
    {
        public bool WeaponVisibility { get; protected set; }

        public Rectangle BulletRectangle { get; protected set; }

        public abstract bool CheckForInersection(IEntity entity);

        public void GetBulletRectangle(Rectangle rect)
        {
            this.BulletRectangle = rect;
        }
    }
}
