namespace Space_Invaders.Models.Players
{
    using Space_Invaders.Interfaces.Models.Players;
    using Space_Invaders.Models.Entities;
    using Space_Invaders.Interfaces.IO.InputCommands;
    using Space_Invaders.IO.InputCommands.Events;

    public abstract class Player : Entity, IPlayer
    {
        private string playerName;
        private int points;

        public Player(int x, int y, string playerName)
            : base(x, y)
        {
            this.PlayerName = playerName;
        }

        public string PlayerName
        {
            get
            {
                return this.playerName;
            }

            private set
            {
                this.playerName = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            private set
            {
                this.points = value;
            }
        }

        public void OnKeyPressed(IInputCommand sender, KeyPressedEventArgs eventArgs)
        {
            this.Update(eventArgs.GameTime, eventArgs.KeyboardState);
        }
    }
}
