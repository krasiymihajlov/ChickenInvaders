using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_Invaders.Interfaces.Models.Enemies;

namespace Space_Invaders.Models.Enimies
{
    public abstract class Enemy : IEnemy
    {
        public Texture2D Texture { get; }
        public Rectangle Rectangle { get; }
        public void Load(ContentManager content, GraphicsDevice GraphicsDevice, string path)
        {
            throw new System.NotImplementedException();
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            throw new System.NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }

        public bool IsAlive { get; }
    }
}
