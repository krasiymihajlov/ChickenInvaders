namespace Space_Invaders.Interfaces.Globals
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public interface ILocationable
    {
        Texture2D Texture { get; }

        Rectangle Rectangle { get; }
    }
}
