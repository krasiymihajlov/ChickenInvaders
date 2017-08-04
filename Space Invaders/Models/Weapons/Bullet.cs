using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_Invaders.Interfaces.Models.Weapons;

namespace Space_Invaders.Models.Weapons
{
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

        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            this.Rectangle = new Rectangle(0,0, 20, 20);
            if (this.IsActivated == "NO")
            {
                this.IsActivated = "YES";
                this.Rectangle = new Rectangle(1 + gameTime.ElapsedGameTime.Seconds, 2, 20, 20);
            }
        }
    }
}
