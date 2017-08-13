namespace Space_Invaders.Interfaces.Globals
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public interface IEntity : ILocationable, IFlexable
    {
        void Load(ContentManager content, GraphicsDevice GraphicsDevice, string path);

        void Update(GameTime gameTime, KeyboardState keyboardState);

        void Draw(SpriteBatch spriteBatch);
    }
}
