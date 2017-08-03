namespace Space_Invaders.Interfaces.Models.Players
{
    using Space_Invaders.Interfaces.Globals;
    using Space_Invaders.Interfaces.IO.InputCommands;
    using Space_Invaders.IO.InputCommands.Events;

    public interface IPlayer : IEntity
    {
        string PlayerName { get; }

        int Points { get; }

        void OnKeyPressed(IInputCommand sender, KeyPressedEventArgs eventArgs);
    }
}
