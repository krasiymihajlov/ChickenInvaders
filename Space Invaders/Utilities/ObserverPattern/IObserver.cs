namespace Space_Invaders.Utilities.ObserverPattern
{
    using System.Runtime.Remoting.Messaging;

    public interface IObserver
    {
        void Notify(bool isActivated);
    }
}
