using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_Invaders.Interfaces.Globals;
using Space_Invaders.Interfaces.Models.Enemies;

namespace Space_Invaders.Models.Entities
{
    public abstract class EnemyArmy : IEnemyArmy
    {
        protected EnemyArmy(int rows, int colomns)
        {
            this.Rows = rows;
            this.Colomns = colomns;
            this.CurrentCount = rows * colomns;
        }
        public int Rows { get; }
        public int Colomns { get; }
        public int CurrentCount { get; }
        public abstract void Update(GameTime gameTime, KeyboardState keyboardState);

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Load(ContentManager content, GraphicsDevice GraphicsDevice, string path);
        public abstract bool CheckForInersection(IEntity entity);
    }
}
