namespace Space_Invaders.Models.Entities
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Space_Invaders.Interfaces.Globals;

    public abstract class Drawable : IVisability
    {
        protected Drawable()
        {
        }

        protected Drawable(int x, int y, int width, int height)
        {
            this.Rectangle = new Rectangle(x, y, width, height);
        }

        public Texture2D Texture { get; protected set; }

        public Rectangle Rectangle { get; protected set; }

        public virtual void Load(ContentManager content, GraphicsDevice graphicsDevice, string path)
        {
            this.Texture = content.Load<Texture2D>(path);
        }

        public abstract void Update(GameTime gameTime, KeyboardState keyboardState);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
        }
    }
}
