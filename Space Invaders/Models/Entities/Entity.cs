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
        private string name;

        protected Entity(int x, int y)
            :this(x, y, EntityConstants.ShipWidth, EntityConstants.ShipHeight)
        {

        }

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

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value;
            }
        }

        public virtual void Load(ContentManager content, GraphicsDevice GraphicsDevice, string path)
        {
            //this.Texture = content.Load<Texture2D>("ship");
            using (var stream = TitleContainer.OpenStream(path))
            {
                this.Texture = Texture2D.FromStream(GraphicsDevice, stream);
            }
        }

        public abstract void Update(GameTime gameTime, KeyboardState keyboardState);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
        }
    }
}
