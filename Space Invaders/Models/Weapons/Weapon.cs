using System;
using System.Collections.Generic;
namespace Space_Invaders.Models.Weapons
{
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Space_Invaders.Interfaces.Models.Weapons;
    using Space_Invaders.Models.Entities;
    using Space_Invaders.Common.Constants.Weapons;

    public abstract class Weapon : Entity,  IWeapon
    {
        protected Weapon(int x, int y) 
            : base(x, y, WeaponConstants.WeaponWidth, WeaponConstants.WeaponHeight)
        {

        }

        protected Weapon(int x, int y, int width, int height) 
            : base(x, y, width, height)
        {
        }

        public bool IsActivated { get; protected set; }

        public abstract void GetNewRectangleCoordinates(Rectangle rect);
    }
}
