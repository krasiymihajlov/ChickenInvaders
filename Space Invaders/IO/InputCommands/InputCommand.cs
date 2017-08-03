namespace Space_Invaders.IO.InputCommands
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Space_Invaders.Interfaces.IO.InputCommands;
    using Space_Invaders.IO.InputCommands.Events;

    public class InputCommand : IInputCommand
    {
        public event KeyPressedEventHandler KeyPressed;

        public void GetKeyboardState(KeyboardState keyboardState, GameTime gameTime)
        {
            this.OnKeyPressed(new KeyPressedEventArgs(keyboardState, gameTime));
        }

        protected virtual void OnKeyPressed(KeyPressedEventArgs eventArgs)
        {
            this.KeyPressed?.Invoke(this, eventArgs);
        }
    }
}
