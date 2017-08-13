namespace Space_Invaders.Utilities.ObserverPattern
{
    public interface IObservable
    {
        void Attach(IObserver observer);

        void Detach(IObserver observer);

        void Update();
    }
}
