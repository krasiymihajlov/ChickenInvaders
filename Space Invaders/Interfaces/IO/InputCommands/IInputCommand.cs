namespace Space_Invaders.Interfaces.IO.InputCommands
{
    using Space_Invaders.IO.InputCommands.Events;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public interface IInputCommand
    {
        event KeyPressedEventHandler KeyPressed;

        void GetKeyboardState(KeyboardState keyboardState, GameTime gameTime);
    }
}
