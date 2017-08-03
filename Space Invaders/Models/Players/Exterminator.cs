namespace Space_Invaders.Models.Players
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Common.Constants.Entities;
    using Common.Constants.Graphics;

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
                TryMoveLeft();
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                TryMoveRight();
            }

            //if (keyboardState.IsKeyDown(Keys.Space) && bulletVisible.Equals("NO"))
            //{
            //    bulletVisible = "YES";
            //    rectBullet.X = rectShip.X + (rectShip.Width / 2) - (rectBullet.Width / 2);
            //    rectBullet.Y = rectShip.Y - rectBullet.Height;
            //}
        }

        private void TryMoveLeft()
        {
            if (this.Rectangle.Left >= 0)
            {
                this.Rectangle = new Rectangle(this.Rectangle.X - EntityConstants.SHIP_SPEED,
                    this.Rectangle.Y, EntityConstants.SHIP_WIDTH, EntityConstants.SHIP_HEIGHT);
            }
        }

        private void TryMoveRight()
        {
            if (this.Rectangle.Right <= GraphicsConstants.ViewportWidth)
            {
                this.Rectangle = new Rectangle(this.Rectangle.X + EntityConstants.SHIP_SPEED,
                    this.Rectangle.Y, EntityConstants.SHIP_WIDTH, EntityConstants.SHIP_HEIGHT);
            }
        }
    }
}
