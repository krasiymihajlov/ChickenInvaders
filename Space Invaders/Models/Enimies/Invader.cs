namespace Space_Invaders.Models.Enimies
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Space_Invaders.Common.Constants.Entities;
    using Space_Invaders.Common.Constants.Graphics;
    using Space_Invaders.Interfaces.Models.Enemies;

    public class Invader : Enemy, IInvader
    {
        private bool isAlive;        

        public Invader(int x, int y) 
            : base(x, y)
        {
            this.IsAlive = true;
        }

        //public Invader(int x, int y, int width, int height)
        //   : base(x, y, width, height)
        //{
        //}

        public override bool IsAlive
        {
            get { return this.isAlive; }
            protected set { this.isAlive = value; }
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            this.Rectangle = new Rectangle(this.Rectangle.X + 1, this.Rectangle.Y,this.Rectangle.Width, 
                this.Rectangle.Height);
        }

        public override bool GetWeaponState()
        {
            throw new System.NotImplementedException();
        }

        public override void SendWeaponState(bool isActivated)
        {
            throw new System.NotImplementedException();
        }

        public override void MoveInTroops(int xUpdate, int yUpdate, int colomns)
        {
            this.Rectangle = new Rectangle(this.Rectangle.X + xUpdate, this.Rectangle.Y + yUpdate, this.Rectangle.Width, this.Rectangle.Height);
        }

        public void InvaderisDead()
        {
            this.IsAlive = false;
        }
    }
}
