namespace Space_Invaders.Models.Players
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Space_Invaders.Common.Constants.Entities;

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
                this.Rectangle = new Rectangle(this.Rectangle.X - EntityConstants.SHIP_SPEED, 
                    this.Rectangle.Y, EntityConstants.SHIP_WIDTH, EntityConstants.SHIP_HEIGHT);
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                this.Rectangle = new Rectangle(this.Rectangle.X + EntityConstants.SHIP_SPEED, 
                    this.Rectangle.Y, EntityConstants.SHIP_WIDTH, EntityConstants.SHIP_HEIGHT);
            }

            //if (keyboardState.IsKeyDown(Keys.Space) && bulletVisible.Equals("NO"))
            //{
            //    bulletVisible = "YES";
            //    rectBullet.X = rectShip.X + (rectShip.Width / 2) - (rectBullet.Width / 2);
            //    rectBullet.Y = rectShip.Y - rectBullet.Height;
            //}
        }
    }
}
