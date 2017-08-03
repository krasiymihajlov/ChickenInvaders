namespace Space_Invaders
{
    using Space_Invaders.Core;
    using Space_Invaders.Interfaces.Core;
    using System;

#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class StartUp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (IEngine game = new Engine())
                game.Run();
        }
    }
#endif
}
