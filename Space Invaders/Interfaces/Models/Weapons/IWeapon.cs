using Space_Invaders.Interfaces.Globals;

namespace Space_Invaders.Interfaces.Models.Weapons
{
    public interface IWeapon : IEntity
    {
        string IsActivated { get; }
    }
}
