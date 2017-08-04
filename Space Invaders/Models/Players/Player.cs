using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Interfaces.Models.Weapons;
using Space_Invaders.Models.Weapons;

namespace Space_Invaders.Models.Players
{
    using Interfaces.Models.Players;
    using Entities;
    using Interfaces.IO.InputCommands;
    using IO.InputCommands.Events;

    public abstract class Player : Entity, IPlayer
    {
        private string playerName;
        private int points;

        protected Player(int x, int y, string playerName)
            : base(x, y)
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

        public void OnKeyPressed(IInputCommand sender, KeyPressedEventArgs eventArgs)
        {
            this.Update(eventArgs.GameTime, eventArgs.KeyboardState);
        }

        public void LoadWeapon(ContentManager content, GraphicsDevice device, string path)
        {
            Weapon.Load(content, device, path);
        }

        public Weapon Weapon { get; set; }
    }
}
