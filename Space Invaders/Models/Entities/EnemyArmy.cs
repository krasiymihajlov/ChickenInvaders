namespace Space_Invaders.Models.Entities
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Space_Invaders.Common.Constants.Enemies;
    using Space_Invaders.Common.Constants.Entities;
    using Space_Invaders.Interfaces.Globals;
    using Space_Invaders.Interfaces.Models.Enemies;

    public abstract class EnemyArmy : Entity, IEnemyArmy
    {
        protected EnemyArmy(int x, int y)
            : base(x, y, EnemyConstans.Enemy2Width, EnemyConstans.Enemy2Height)
        {
            this.CurrentCount = EnemyConstans.Rows * EnemyConstans.Cols;
        }
        public int CurrentCount { get; private set; }

        public bool WeaponVisibility { get; protected set; }

        public Rectangle BulletRectangle { get; protected set; }

        public abstract bool CheckForInersection(IEntity entity);

        public void GetBulletRectangle(Rectangle rect)
        {
            this.BulletRectangle = rect;
        }
    }
}
