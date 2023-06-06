using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Phantom
{
    public class Camera
    {
        private int LevelWidth;
        private int LevelHeight;
        public Matrix Transform { get; private set; }

        public Camera(int levelWidth, int levelHeight)
        {
            LevelHeight = levelHeight;
            LevelWidth = levelWidth;
        }
        public Matrix GetTransform()
        {
            return Transform;
        }
        public void follow(Character character, GraphicsDevice graphicsDevice)
        {
            // Calculate the camera position to center on the character
            float viewportWidth = graphicsDevice.Viewport.Width;
            float viewportHeight = graphicsDevice.Viewport.Height;
            float characterX = character.GetPosition().X;
            float characterY = character.GetPosition().Y;
            float cameraX = characterX - (viewportWidth / 2);
            float cameraY = characterY - (viewportHeight / 2);

            // Keep the camera within the bounds of the game world
            cameraX = MathHelper.Clamp(cameraX, 0, LevelWidth - viewportWidth);
            cameraY = MathHelper.Clamp(cameraY, 0, LevelHeight - viewportHeight);

            // Create the camera transform matrix
            Transform = Matrix.CreateTranslation(-cameraX, -cameraY, 0);
        }
    }
}
