namespace Space_Invaders.Models.Enimies
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Space_Invaders.Common.Constants.Entities;
    using Space_Invaders.Interfaces.Globals;
    using Space_Invaders.Interfaces.Models.Enemies;
    using Space_Invaders.Models.Entities;
    using Space_Invaders.Common.Constants.Enemies;

    public class InvaderArmy : EnemyArmy 
    {
        private bool weaponVisibility;
        private IInvader[,] troops;
        private Rectangle bulletRectangle;

        public InvaderArmy() : base()
        {            
            this.troops = new Invader[EnemyConstans.Rows, EnemyConstans.Cols];
            this.FillArmy();
        }

        private void FillArmy()
        {
            for (int r = 0; r < EnemyConstans.Rows; r++)
            {
                for (int c = 0; c < EnemyConstans.Cols; c++)
                {
                    this.troops[r, c] = new Invader(r * EntityConstants.Enemy2Width, c * EntityConstants.Enemy2Height);
                }    
            }
        }
        
        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            if (this.weaponVisibility)
            {
                foreach (var enemy in this.troops)
                {
                    if (enemy.IsAlive && this.bulletRectangle.Intersects(enemy.Rectangle))
                    {
                        this.weaponVisibility = false;
                        enemy.InvaderisDead();
                    }
                }
            }

            foreach (var enemy in this.troops)
            {
                enemy.MoveInTroops(this.troops[0,0].Rectangle.Location.X, 
                    this.troops[EnemyConstans.Rows - 1, EnemyConstans.Cols - 1].Rectangle.Location.X, EnemyConstans.Cols);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var enemy in this.troops)
            {
                if (enemy.IsAlive)
                {
                    spriteBatch.Draw(enemy.Texture, enemy.Rectangle, Color.White);
                }
            }
        }

        public override void Load(ContentManager content, GraphicsDevice GraphicsDevice, string path)
        {
            foreach (var enemy in this.troops)
            {
                enemy.Load(content, GraphicsDevice, path);
            }
        }

        public override bool CheckForInersection(IEntity entity)
        {
            foreach (var enemy in this.troops)
            {
                if (enemy.Rectangle.Intersects(entity.Rectangle))
                {
                    return true;
                }
            }

            return false;
        }

        public override bool GetWeaponState()
        {
            return this.weaponVisibility;
        }

        public override void SendWeaponState(bool isActivated)
        {
            this.weaponVisibility = isActivated;
        }

        public override void GetBulletRectangle(Rectangle rect)
        {
            this.bulletRectangle = rect;
        }
    }
}
