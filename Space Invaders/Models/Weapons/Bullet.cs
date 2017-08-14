namespace Space_Invaders.Models.Weapons
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Space_Invaders.Common.Constants.Weapons;
    using Space_Invaders.Interfaces.Globals;

    public class Bullet : Weapon
    {
        private Rectangle player;

        public Bullet(int x, int y, Rectangle player) 
            : base(x, y)
        {
            this.player = player;
        }

        public Bullet(int x, int y, int width, int height) 
            : base(x, y, width, height)
        {
        }

        public override void GetNewRectangleCoordinates(Rectangle rect)
        {
            this.Rectangle = rect;
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            if (this.BulletIsActivated)
            {
                this.Rectangle = new Rectangle(this.Rectangle.X,
                    this.Rectangle.Y - WeaponConstants.WeaponSpeed, this.Rectangle.Width, this.Rectangle.Height);
            }

            if (this.Rectangle.Y + this.Rectangle.Height < 0)
            {
                this.BulletIsActivated = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.BulletIsActivated)
            {
                spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
            }
        }
    }
}
