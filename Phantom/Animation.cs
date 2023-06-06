using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Phantom
{
    internal class Animation
    {
        private Texture2D spriteSheet;
        private int frameCount;
        private int currentFrame;
        private int frameWidth;
        private int frameHeight;
        private float frameDuration;
        private float timer;
        private bool isLooping;

        public Texture2D SpriteSheet => spriteSheet;
        public Rectangle CurrentFrameRectangle => new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);


        public Animation(Texture2D sheet, int count, float duration, bool looping)
        {
            spriteSheet = sheet;
            frameCount = count;
            frameDuration = duration;
            frameWidth = spriteSheet.Width / frameCount;
            frameHeight = spriteSheet.Height;
            isLooping = looping;
            timer = 0f;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            // Advance to the next frame if the duration has passed
            if (timer >= frameDuration)
            {
                currentFrame++;
                timer = 0f;

                // Reset to the first frame if the animation is looping
                if (currentFrame >= frameCount)
                {
                    if (isLooping)
                        currentFrame = 0;
                    else
                        currentFrame = frameCount - 1;
                }
            }
        }
    }
}
