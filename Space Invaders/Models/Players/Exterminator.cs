namespace Space_Invaders.Models.Players
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Common.Constants.Entities;
    using Common.Constants.Graphics;
    using Space_Invaders.Common.Constants.Weapons;
    using Space_Invaders.Interfaces.Globals;

    public class Exterminator : Player
    {
        public Exterminator(int x, int y, string playerName)
            : base(x, y, playerName)
        {
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                this.TryMoveLeft();
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                this.TryMoveRight();
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                this.TryMoveUp();
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                this.TryMoveDown();
            }

            if (keyboardState.IsKeyDown(Keys.Space) && !this.BulletIsActivated)
            {
                this.BulletIsActivated = true;

                int rectX = this.Rectangle.X + (this.Rectangle.Width / 2) - (WeaponConstants.WeaponWidth / 2);
                int rectY = this.Rectangle.Y - WeaponConstants.WeaponHeight;

                this.WeaponCoordinates = new Rectangle(rectX, rectY, WeaponConstants.WeaponWidth, WeaponConstants.WeaponHeight);
            }
        }

        private void TryMoveLeft()
        {
            if (this.Rectangle.Left > 0)
            {
                this.Rectangle = new Rectangle(this.Rectangle.X - EntityConstants.ShipSpeed,
                    this.Rectangle.Y, this.Rectangle.Width, this.Rectangle.Height);
            }
        }

        private void TryMoveUp()
        {
            if (this.Rectangle.Top > 0)
            {
                this.Rectangle = new Rectangle(this.Rectangle.X, this.Rectangle.Y - EntityConstants.ShipSpeed,
                    this.Rectangle.Width, this.Rectangle.Height);
            }
        }

        private void TryMoveDown()
        {
            if (this.Rectangle.Bottom < EntityConstants.ShipYStartCoordinates + EntityConstants.ShipHeight)
            {
                this.Rectangle = new Rectangle(this.Rectangle.X, this.Rectangle.Y + EntityConstants.ShipSpeed,
                    this.Rectangle.Width, this.Rectangle.Height);
            }
        }

        private void TryMoveRight()
        {
            if (this.Rectangle.Right < GraphicsConstants.ViewportWidth)
            {
                this.Rectangle = new Rectangle(this.Rectangle.X + EntityConstants.ShipSpeed,
                    this.Rectangle.Y, this.Rectangle.Width, this.Rectangle.Height);
            }
        }
    }
}