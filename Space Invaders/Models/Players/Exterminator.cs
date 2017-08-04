using Microsoft.Xna.Framework.Graphics;

namespace Space_Invaders.Models.Players
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Common.Constants.Entities;
    using Common.Constants.Graphics;

    public class Exterminator : Player
    {
        private Rectangle bullet;
        private bool bulletVisible;
        public Exterminator(int x, int y, string playerName)
            : base(x, y, playerName)
        {

        }
        
        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                TryMoveLeft();
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                TryMoveRight();
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                TryMoveUp();
            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                TryMoveDown();
            }

            if (keyboardState.IsKeyDown(Keys.Space) && !this.bulletVisible)
            {
                this.bulletVisible = true;
                this.bullet.X = this.Rectangle.X + (this.Rectangle.Width / 2) - (this.bullet.Width / 2);
                this.bullet.Y = this.Rectangle.Y - this.bullet.Height;
            }
        }

        private void TryMoveLeft()
        {
            if (this.Rectangle.Left > 0)
            {
                this.Rectangle = new Rectangle(this.Rectangle.X - EntityConstants.ShipSpeed,
                    this.Rectangle.Y, EntityConstants.ShipWidth, EntityConstants.ShipHeight);
            }
        }

        private void TryMoveUp()
        {
            if (this.Rectangle.Top > 0)
            {
                this.Rectangle = new Rectangle(this.Rectangle.X, this.Rectangle.Y - EntityConstants.ShipSpeed, 
                    EntityConstants.ShipWidth, EntityConstants.ShipHeight);
            }
        }

        private void TryMoveDown()
        {
            if (this.Rectangle.Bottom < EntityConstants.ShipYStartCoordinates + EntityConstants.ShipHeight)
            {
                this.Rectangle = new Rectangle(this.Rectangle.X,this.Rectangle.Y + EntityConstants.ShipSpeed, 
                    EntityConstants.ShipWidth, EntityConstants.ShipHeight);
            }
        }

        private void TryMoveRight()
        {
            if (this.Rectangle.Right < GraphicsConstants.ViewportWidth)
            {
                this.Rectangle = new Rectangle(this.Rectangle.X + EntityConstants.ShipSpeed,
                    this.Rectangle.Y, EntityConstants.ShipWidth, EntityConstants.ShipHeight);
            }
        }
    }
}
