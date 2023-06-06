using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Phantom
{
    public class Character
    {
        private Texture2D idleSpriteSheet;
        private Texture2D runSpriteSheet;
        private Animation idleAnimation;
        private Animation runAnimation;
        private Animation currentAnimation;
        private Vector2 position;
        private bool isFlipped = false;
        private bool isOnPlatform = false;
        private const float movementSpeed = 4f;

        public Character(Texture2D idleSheet, Texture2D runSheet, Vector2 startPos)
        {
            idleSpriteSheet = idleSheet;
            runSpriteSheet = runSheet;
            position = startPos;

            // Create idle animation
            idleAnimation = new Animation(idleSpriteSheet, 5, 125, true);

            // Create run animation
            runAnimation = new Animation(runSpriteSheet, 6, 75, true);

            // Set initial animation to idle
            currentAnimation = idleAnimation;
        }

        public void SetIsOnPlatform(bool value)
        {
            isOnPlatform = value;
        }

        public Rectangle GetFeetBoundingBox()
        {
            // Return a rectangle representing the character's feet
            int feetWidth = 30;  // Example feet width
            int feetHeight = 20; // Example feet height

            return new Rectangle((int)position.X, (int)position.Y + (idleSpriteSheet.Height - feetHeight), feetWidth, feetHeight);
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public void Update(GameTime gameTime)
        {
            // Check keyboard input for movement
            // Update input manager
            InputManager.Update();

            float deltaX = 0f;

            if (InputManager.IsKeyDown(Keys.A)||InputManager.IsKeyDown(Keys.Left))
            {
                deltaX -= movementSpeed;
                isFlipped = true;
            }

            if (InputManager.IsKeyDown(Keys.D)||InputManager.IsKeyDown(Keys.Right))
            {
                deltaX += movementSpeed;
                isFlipped = false;
            }
            // Update character position based on movement
            position.X += deltaX;

            // Set current animation based on movement
            if (deltaX != 0f)
                currentAnimation = runAnimation;
            else
                currentAnimation = idleAnimation;

            // Update the current animation
            currentAnimation.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin = isFlipped ? new Vector2(currentAnimation.CurrentFrameRectangle.Width, 0) : Vector2.Zero;

            // Draw the current frame of the animation
            spriteBatch.Draw(
                currentAnimation.SpriteSheet,
                position,
                currentAnimation.CurrentFrameRectangle,
                Color.White,
                0f,
                origin,
                1f,
                isFlipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                0f
            );
        }

    }
}
