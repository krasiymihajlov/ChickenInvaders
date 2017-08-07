using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Space_Invaders.Common.Constants.Entities;
using Space_Invaders.Common.Constants.Graphics;
using Space_Invaders.Interfaces.Models.Enemies;

namespace Space_Invaders.Models.Enimies
{
    public class Invader : Enemy, IInvader
    {
        private string direction;
        private bool isAlive;

        public Invader(int x, int y) : base(x, y)
        {
            this.IsAlive = true;
        }

        public override bool IsAlive
        {
            get { return this.isAlive; }
            protected set { this.isAlive = value; }
        }

        public Invader(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            this.Rectangle = new Rectangle(this.Rectangle.X + 1, this.Rectangle.Y,this.Rectangle.Width, this.Rectangle.Height);
        }

        public override void MoveInTroops(int leftmostUnitX, int rightmostUnitX, int colomns)
        {
            if (direction == null)
            {
                direction = "RIGHT";
            }

            if (leftmostUnitX > 0 && direction == "LEFT")
            {
                this.Rectangle = new Rectangle(this.Rectangle.X -  5, this.Rectangle.Y,this.Rectangle.Width, this.Rectangle.Height);
            }
            else if ( rightmostUnitX + this.Texture.Width  < GraphicsConstants.ViewportWidth  && direction == "RIGHT")
            {
                this.Rectangle = new Rectangle(this.Rectangle.X + 5, this.Rectangle.Y,this.Rectangle.Width, this.Rectangle.Height);
            }
            else
            {
                if (direction =="LEFT")
                {
                    direction = "RIGHT";
                }
                else
                {
                    direction = "LEFT";
                }
            }
        }
    }
}
