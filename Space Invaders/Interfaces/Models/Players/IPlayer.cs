﻿namespace Space_Invaders.Interfaces.Models.Players
{
    using Globals;
    using IO.InputCommands;
    using Microsoft.Xna.Framework;
    using Space_Invaders.IO.InputCommands.Events;

    public interface IPlayer : IEntity, IFlexable 
    {
        string PlayerName { get; }

        int Points { get; }

        void OnKeyPressed(IInputCommand sender, KeyPressedEventArgs eventArgs);

        Rectangle GetWeaponStartCoordinates();
    }
}
