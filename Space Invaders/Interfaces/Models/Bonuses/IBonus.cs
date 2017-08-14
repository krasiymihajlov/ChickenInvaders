namespace Space_Invaders.Interfaces.Models.Bonuses
{
    using Space_Invaders.Interfaces.Globals;

    public interface IBonus : IVisability
    {
        bool IsActivated { get; }

        string SpecialAbility { get; }
    }
}
