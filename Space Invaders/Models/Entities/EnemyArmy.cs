namespace Space_Invaders.Models.Entities
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Space_Invaders.Common.Constants.Enemies;
    using Space_Invaders.Interfaces.Globals;
    using Space_Invaders.Interfaces.Models.Enemies;

    public abstract class EnemyArmy : IEnemyArmy
    {
        protected EnemyArmy()
        {
            this.CurrentCount = EnemyConstans.Rows * EnemyConstans.Cols;
        }
        public int CurrentCount { get; private set; }

        public Texture2D Texture => throw new NotImplementedException();

        public Rectangle Rectangle => throw new NotImplementedException();

        public abstract void Update(GameTime gameTime, KeyboardState keyboardState);

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Load(ContentManager content, GraphicsDevice GraphicsDevice, string path);

        public abstract bool CheckForInersection(IEntity entity);

        public abstract void GetBulletRectangle(Rectangle rect);

        public abstract bool GetWeaponState();

        public abstract void SendWeaponState(bool isActivated);
    }
}
