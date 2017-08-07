using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_Invaders.Common.Constants.Entities;
using Space_Invaders.Interfaces.Globals;
using Space_Invaders.Interfaces.Models.Enemies;
using Space_Invaders.Models.Entities;

namespace Space_Invaders.Models.Enimies
{
    public class InvaderArmy : EnemyArmy , IInvaderArmy
    {
        private IEnemy[,] troops;

        public InvaderArmy(int rows, int colomns) : base(rows, colomns)
        {
            this.troops = new Invader[this.Rows, this.Colomns];
            this.FillArmy();
        }

        private void FillArmy()
        {
            for (int r = 0; r < this.Rows; r++)
            {
                for (int c = 0; c < this.Colomns; c++)
                {
                    this.troops[r, c] = new Invader(
                        r * EntityConstants.Enemy2Width,
                        c * EntityConstants.Enemy2Height,
                        EntityConstants.Enemy2Width, 
                        EntityConstants.Enemy2Height);
                }    
            }
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            foreach (var enemy in this.troops)
            {
                enemy.MoveInTroops(this.troops[0,0].Rectangle.Location.X, this.troops[this.Rows - 1,this.Colomns - 1].Rectangle.Location.X, this.Colomns);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var enemy in this.troops)
            {
                spriteBatch.Draw(enemy.Texture, enemy.Rectangle,Color.White);
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
    }
}
