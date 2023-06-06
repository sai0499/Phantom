using Microsoft.Xna.Framework;

namespace Phantom
{
    public class Platform
    {
        public Vector2 Position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Platform(Vector2 position, int width, int height)
        {
            Position = position;
            Width = width;
            Height = height;
        }

        public bool IsCharacterOnPlatform(Character character)
        {
            // Check if the character's feet are within the platform's bounds
            Rectangle characterFeet = character.GetFeetBoundingBox();
            Rectangle platformBounds = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

            return characterFeet.Intersects(platformBounds);
        }
    }
}
