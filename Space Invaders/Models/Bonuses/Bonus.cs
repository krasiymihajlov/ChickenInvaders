namespace Space_Invaders.Models.Bonuses
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Space_Invaders.Common.Constants.Bonuses;
    using Space_Invaders.Common.Constants.Weapons;
    using Space_Invaders.Interfaces.Models.Bonuses;
    using Space_Invaders.Models.Entities;

    public abstract class Bonus : Drawable, IBonus
    {
        protected Bonus(int x, int y)
            :base (x, y, BonusConstants.BonusWidth, BonusConstants.BonusHeight)
        {
        }

        public abstract bool IsActivated { get; protected set; }

        public abstract string SpecialAbility { get; protected set; }
    }
}
