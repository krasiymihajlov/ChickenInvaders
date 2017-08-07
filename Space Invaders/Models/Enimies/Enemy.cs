using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_Invaders.Interfaces.Models.Enemies;
using Space_Invaders.Models.Entities;

namespace Space_Invaders.Models.Enimies
{
    public abstract class Enemy : Entity, IEnemy
    {
        public Enemy(int x, int y) : base(x, y)
        {
        }

        public Enemy(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        public virtual bool IsAlive { get; protected set; }
    }
}
