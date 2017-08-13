using Microsoft.Xna.Framework;

namespace Space_Invaders.Interfaces.Models.Enemies
{
    using Space_Invaders.Interfaces.Globals;

    public interface IEnemy : IEntity
    {
       bool IsAlive { get; }

       void MoveInTroops(int leftmostUnitX, int rightmostUnitX, int colomns);
    }
}
