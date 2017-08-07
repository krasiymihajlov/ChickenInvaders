using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_Invaders.Interfaces.Globals;

namespace Space_Invaders.Interfaces.Models.Enemies
{
    public interface IEnemyArmy
    {
        int Rows { get; }
        int Colomns { get; }
        int CurrentCount { get; }


        void Update(GameTime gameTime, KeyboardState keyboardState);

        void Draw(SpriteBatch spriteBatch);

        void Load(ContentManager content, GraphicsDevice GraphicsDevice, string path);

        bool CheckForInersection(IEntity entity);
    }
}
