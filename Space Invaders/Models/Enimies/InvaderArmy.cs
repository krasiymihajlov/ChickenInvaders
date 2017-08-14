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
    using Space_Invaders.Common.Constants.Graphics;
    using Space_Invaders.Enumerations;

    public class InvaderArmy : EnemyArmy 
    {
        private IInvader[,] troops;
        private Direction[] moveDirections;
        private int directionIndex;

        public InvaderArmy() : base(2 , 4)     //// For fix!!!!!!!!
        {            
            this.troops = new Invader[EnemyConstans.Rows, EnemyConstans.Cols];
            this.FillArmy();
            this.moveDirections = new[]{Direction.RIGHT, Direction.DOWN, Direction.LEFT, Direction.DOWN};
            this.directionIndex = 0;
        }

        private void FillArmy()
        {
            for (int r = 0; r < EnemyConstans.Rows; r++)
            {
                for (int c = 0; c < EnemyConstans.Cols; c++)
                {
                    this.troops[r, c] = new Invader(r * (EnemyConstans.Enemy2Width + EnemyConstans.SpaceBetweenEnemies),
                        c * ( EnemyConstans.Enemy2Height + EnemyConstans.SpaceBetweenEnemies));
                }    
            }
        }
        
        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            int xUpdate = 0;
            int yUpdate = 0;
            if (this.BulletIsActivated)
            {
                foreach (var enemy in this.troops)
                {
                    if (enemy.IsAlive && this.BulletRectangle.Intersects(enemy.Rectangle))
                    {
                        this.BulletIsActivated = false;
                        enemy.InvaderisDead();
                    }
                }
            }

            if (this.moveDirections[this.directionIndex] == Direction.RIGHT)
            {
                xUpdate = EnemyConstans.EnemyHorizontalSpeed;
            }
            else if (this.moveDirections[this.directionIndex] == Direction.LEFT)
            {
                xUpdate = -EnemyConstans.EnemyHorizontalSpeed;
            }
            else if (this.moveDirections[this.directionIndex] == Direction.DOWN)
            {
                yUpdate = EnemyConstans.EnemyVerticalSpeed;
            }
            
            for (int i = 0; i < EnemyConstans.Rows; i++)
            {
                for (int j = 0; j < EnemyConstans.Cols; j++)
                {
                    this.troops[i, j].MoveInTroops(xUpdate,yUpdate, EnemyConstans.Cols);
                }
            }

            int currentLeftmostUnitX = this.troops[0, 0].Rectangle.X;

            if (currentLeftmostUnitX + EnemyConstans.Enemy2Width * EnemyConstans.Rows + EnemyConstans.SpaceBetweenEnemies * (EnemyConstans.Rows - 1 )>
                GraphicsConstants.ViewportWidth
                || currentLeftmostUnitX <= 0)
            {
                this.directionIndex++;
            }

            this.directionIndex %= this.moveDirections.Length;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < EnemyConstans.Rows; i++)
            {
                for (int j = 0; j < EnemyConstans.Cols; j++)
                {
					if(this.troops[i, j].IsAlive)
					{
                   		 spriteBatch.Draw(this.troops[i,j].Texture, this.troops[i, j].Rectangle, Color.White);
					}
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
