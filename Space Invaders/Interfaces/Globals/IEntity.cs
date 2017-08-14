namespace Space_Invaders.Interfaces.Globals
{
    public interface IEntity : IVisability, IFlexable
    {
        bool BulletIsActivated { get; }
    }
}
