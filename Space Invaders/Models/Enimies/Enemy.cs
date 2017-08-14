using Space_Invaders.Common.Constants.Enemies;

namespace Space_Invaders.Models.Enimies
{
    using Space_Invaders.Common.Constants.Enemies;
    using Space_Invaders.Common.Constants.Entities;
    using Space_Invaders.Interfaces.Models.Enemies;
    using Space_Invaders.Models.Entities;

    public abstract class Enemy : Drawable, IEnemy
    {
        protected Enemy(int x, int y) 
            : base(x, y, EnemyConstans.Enemy2Width, EnemyConstans.Enemy2Height)
        {
        }

        protected Enemy(int x, int y, int width, int height) 
            : base(x, y, width, height)
        {
        }

        public bool IsAlive { get; protected set; }

        public abstract void MoveInTroops(int leftmostUnitX, int rightmostUnitX, int colomns);
    }
}
