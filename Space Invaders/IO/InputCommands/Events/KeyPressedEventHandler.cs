namespace Space_Invaders.IO.InputCommands.Events
{
    using Space_Invaders.Interfaces.IO.InputCommands;

    public delegate void KeyPressedEventHandler(IInputCommand sender, KeyPressedEventArgs eventArgs);
}

