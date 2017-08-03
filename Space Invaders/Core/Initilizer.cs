namespace Space_Invaders.Core
{
    using System;
    using Microsoft.Xna.Framework;
    using Space_Invaders.Interfaces.Core;

    public class Initilizer : IInitializer
    {
        public void SetGameMouse(Game game, bool isMouseVisible)
        {
            game.IsMouseVisible = isMouseVisible;
        }

        public void SetGraphicsWindowSize(GraphicsDeviceManager graphics, int preferredBufferWidth, int preferredBufferHeight)
        {
            graphics.PreferredBackBufferWidth = preferredBufferWidth;
            graphics.PreferredBackBufferHeight = preferredBufferHeight;
            graphics.ApplyChanges();
        }
    }
}
