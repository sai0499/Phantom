using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Phantom
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D idleSpriteSheet;
        private Texture2D runSpriteSheet;

        private Character character;

        private Camera camera;

        private List<Platform> platforms;
        private Texture2D platformTexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            camera = new Camera(480, 480);

            // Initialize the platforms
            platforms = new List<Platform>();
            platforms.Add(new Platform(new Vector2(100, 570), 1000, 20)); // Example platform

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            idleSpriteSheet = Content.Load<Texture2D>("Idle Sarah");
            runSpriteSheet = Content.Load<Texture2D>("Run Sarah");

            // Create character
            character = new Character(idleSpriteSheet, runSpriteSheet, new Vector2(100, 500));

            //load platformTexture

            platformTexture = Content.Load<Texture2D>("Tile_18");

            base.LoadContent();

        }

        protected override void UnloadContent()
        {
            // Unload content if needed
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            character.Update(gameTime);
            bool isCharacterOnPlatform = false;
            foreach (Platform platform in platforms)
            {
                if (platform.IsCharacterOnPlatform(character))
                {
                    isCharacterOnPlatform = true;
                    break;
                }
            }

            // Update the character's state based on platform interaction
            character.SetIsOnPlatform(isCharacterOnPlatform);

            camera.follow(character, GraphicsDevice);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            Matrix cameraTransform = camera.GetTransform();
            _spriteBatch.Begin(transformMatrix: cameraTransform);

            foreach (Platform platform in platforms)
            {
                _spriteBatch.Draw(platformTexture, new Rectangle((int)platform.Position.X, (int)platform.Position.Y, platform.Width, platform.Height), Color.White);
            }


            // Draw character
            character.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}