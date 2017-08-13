namespace Space_Invaders.Models.Enimies
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Space_Invaders.Common.Constants.Enemies;
    using Space_Invaders.Common.Constants.Entities;
    using Space_Invaders.Interfaces.Models.Enemies;
    using Space_Invaders.Models.Entities;

    public abstract class Enemy : Entity, IEnemy
    {
        public Enemy(int x, int y) 
            : base(x, y, EntityConstants.Enemy2Width, EntityConstants.Enemy2Height)
        {
        }

        public Enemy(int x, int y, int width, int height) 
            : base(x, y, width, height)
        {
        }

        public virtual bool IsAlive { get; protected set; }

        public abstract void MoveInTroops(int leftmostUnitX, int rightmostUnitX, int colomns);
    }
}
