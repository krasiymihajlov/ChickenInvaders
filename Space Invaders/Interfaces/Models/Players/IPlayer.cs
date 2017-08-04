using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Interfaces.Models.Weapons;

namespace Space_Invaders.Interfaces.Models.Players
{
    using Globals;
    using IO.InputCommands;
    using Space_Invaders.IO.InputCommands.Events;

    public interface IPlayer : IEntity
    {
        string PlayerName { get; }

        int Points { get; }

        void OnKeyPressed(IInputCommand sender, KeyPressedEventArgs eventArgs);

        void LoadWeapon(ContentManager content, GraphicsDevice device, string path);
    }
}
