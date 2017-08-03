namespace Space_Invaders.Interfaces.Core
{
    using System;

    public interface IEngine : IDisposable
    {
        void Run();
    }
}
