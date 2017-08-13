namespace Space_Invaders.Interfaces.Models.Weapons
{
    using Microsoft.Xna.Framework;
    using Space_Invaders.Interfaces.Globals;

    public interface IWeapon : IEntity, IFlexable
    {
        bool IsActivated { get; }

        void GetNewRectangleCoordinates(Rectangle rect);
    }
}
