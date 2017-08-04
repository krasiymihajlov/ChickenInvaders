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
using Space_Invaders.Models.Entities;

namespace Space_Invaders.Models.Weapons
{
    public abstract class Weapon : Entity,  IWeapon
    {
        protected Weapon(int x, int y) 
            : base(x, y)
        {
        }

        protected Weapon(int x, int y, int width, int height) 
            : base(x, y, width, height)
        {
        }

        public string IsActivated { get; set; } = "NO";
    }
}
