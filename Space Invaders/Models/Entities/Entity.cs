namespace Space_Invaders.Models.Entities
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Space_Invaders.Interfaces.Globals;
    using Space_Invaders.Common.Constants.Entities;

    public abstract class Entity : IEntity
    {
        private Texture2D texture;
        private Rectangle rectangle;
        
        protected Entity(int x, int y, int width, int height)
        {
            this.Rectangle = new Rectangle(x, y, width, height);
        }

        public Texture2D Texture
        {
            get
            {
                return this.texture;
            }

            private set
            {
                this.texture = value;
            }
        }
        
        public Rectangle Rectangle
        {
            get
            {
                return this.rectangle;
            }

            protected set
            {
                this.rectangle = value;
            }
        }

        public virtual void Load(ContentManager content, GraphicsDevice GraphicsDevice, string path)
        {
            this.Texture = content.Load<Texture2D>(path);
        }

        public abstract void Update(GameTime gameTime, KeyboardState keyboardState);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
        }

        public abstract bool GetWeaponState();

        public abstract void SendWeaponState(bool isActivated);
    }
}
