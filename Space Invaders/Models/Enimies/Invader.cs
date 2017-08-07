using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Space_Invaders.Interfaces.Models.Enemies;

namespace Space_Invaders.Models.Enimies
{
    public class Invader : Enemy, IInvader
    {
        public Invader(int x, int y) : base(x, y)
        {
        }

        public Invader(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            this.Rectangle = new Rectangle(this.Rectangle.X + 1, this.Rectangle.Y,this.Rectangle.Width, this.Rectangle.Height);
        }
    }
}
