namespace Space_Invaders.Interfaces.Globals
{
    public interface IFlexable
    {
        bool GetWeaponState();

        void SendWeaponState(bool isActivated);
    }
}
