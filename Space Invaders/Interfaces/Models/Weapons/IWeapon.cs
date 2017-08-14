namespace Space_Invaders.Interfaces.Models.Weapons
{
    using Microsoft.Xna.Framework;
    using Space_Invaders.Interfaces.Globals;

    public interface IWeapon : IEntity
    {
        bool IsActivated { get; }

        void GetNewRectangleCoordinates(Rectangle rect);
    }
}
