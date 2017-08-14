namespace Space_Invaders.Models.Bonuses
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Space_Invaders.Common.Constants.Bonuses;

    public class LiveBonus : Bonus
    {
        public LiveBonus(int x, int y) 
            : base(x, y)
        {
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            if (this.IsActivated)
            {
                this.Rectangle = new Rectangle(this.Rectangle.X - BonusConstants.ShipSpeed,
                    this.Rectangle.Y, this.Rectangle.Width, this.Rectangle.Height);
            }

            if (this.Rectangle.Y + this.Rectangle.Height > 390) /// Need change to Global constans max Y size;
            {
                this.IsActivated = false;
            }
        }

        public override bool IsActivated { get; protected set; }

        public override string SpecialAbility { get; protected set; }
    }
}
