using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_Invaders.Common;
using Space_Invaders.Common.Constants.Entities;
using Space_Invaders.Common.Constants.Graphics;
using Space_Invaders.Interfaces.Globals;
using Space_Invaders.Interfaces.Models.Enemies;
using Space_Invaders.Models.Entities;

namespace Space_Invaders.Models.Enimies
{
    public class InvaderArmy : EnemyArmy , IInvaderArmy
    {
        private IEnemy[,] troops;
        private Direction[] moveDirections;
        private int directionIndex;

        public InvaderArmy(int rows, int colomns) : base(rows, colomns)
        {
            this.troops = new Invader[this.Rows, this.Colomns];
            this.FillArmy();
            this.moveDirections = new Direction[]{Direction.RIGHT, Direction.DOWN, Direction.LEFT, Direction.DOWN};
            this.directionIndex = 0;
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
            int xUpdate = 0;
            int yUpdate = 0;
            if (moveDirections[directionIndex] == Direction.RIGHT)
            {
                xUpdate = 5;
            }
            else if (moveDirections[directionIndex] == Direction.LEFT)
            {
                xUpdate = -5;
            }else if (moveDirections[directionIndex] == Direction.DOWN)
            {
                yUpdate = 3;
            }



            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Colomns; j++)
                {
                    this.troops[i, j].MoveInTroops(xUpdate,yUpdate,this.Colomns);
                }
            }

            int currentLeftmostUnitX = this.troops[0, this.Colomns - 1].Rectangle.X;

            if (currentLeftmostUnitX + EntityConstants.Enemy2Width * (this.Colomns - 1)>
                GraphicsConstants.ViewportWidth
                || currentLeftmostUnitX <= 0)
            {
                directionIndex++;
            }

            directionIndex %= moveDirections.Length;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Colomns; j++)
                {
                    spriteBatch.Draw(this.troops[i,j].Texture, this.troops[i, j].Rectangle, Color.White);
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
    }
}
