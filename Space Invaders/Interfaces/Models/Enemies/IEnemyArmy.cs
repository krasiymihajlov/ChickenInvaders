using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_Invaders.Interfaces.Globals;

namespace Space_Invaders.Interfaces.Models.Enemies
{
    public interface IEnemyArmy : IEntity
    {
        //int CurrentCount { get; }

        bool CheckForInersection(IEntity entity);

        void GetBulletRectangle(Rectangle rect);
    }
}
