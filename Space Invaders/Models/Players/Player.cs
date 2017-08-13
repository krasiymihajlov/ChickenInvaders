namespace Space_Invaders.Models.Players
{
    using Interfaces.Models.Players;
    using Entities;
    using Interfaces.IO.InputCommands;
    using IO.InputCommands.Events;
    using Space_Invaders.Common.Constants.Entities;
    using Microsoft.Xna.Framework;

    public abstract class Player : Entity, IPlayer
    {
        private string playerName;
        private int points;

        protected Player(int x, int y, string playerName)
            : base(x, y, EntityConstants.ShipWidth, EntityConstants.ShipHeight)
        {
            this.PlayerName = playerName;
        }

        public string PlayerName
        {
            get => this.playerName;

            private set => this.playerName = value;
        }

        public int Points
        {
            get => this.points;

            private set => this.points = value;
        }

        public abstract Rectangle GetWeaponStartCoordinates();

        public void OnKeyPressed(IInputCommand sender, KeyPressedEventArgs eventArgs)
        {
            this.Update(eventArgs.GameTime, eventArgs.KeyboardState);
        }
    }
}
