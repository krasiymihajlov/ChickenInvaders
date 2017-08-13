namespace Space_Invaders.Utilities.ObserverPattern
{
    using System;
    using System.Collections.Generic;

    public class Subject : IObservable
    {
        private List<IObserver> observers;
        private bool isActivated;

        public Subject()
        {
            this.observers = new List<IObserver>();
        }

        public void Attach(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void Update()
        {
            foreach (var observer in this.observers)
            {
                observer.Notify(this.isActivated);
            }
        }
    }
}
