using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace castelvaniaripoff
{
    class Game1 : Game
    {
        private KeyboardState keyboardState;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        Texture2D playerTexture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        override protected void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO Possibly I need a better way to load the textures for the player, for now I will just load it here.
            playerTexture = Content.Load<Texture2D>("Graphics/Characters/main");
            // TODO I need to create a better way to load the player, for now I will just create it here, possible a PlayerManager?.
            player = new Player("Player", 100, 100, 50, 50, 50, 50, playerTexture);
            base.Initialize();
        }

        override protected void LoadContent()
        {
            base.LoadContent();
        }

        override protected void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                ExitGame();
            }

            base.Update(gameTime);
            player.Update(gameTime);
        }

        override protected void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // We need to share the same instance of spriteBatch between the entities. We can say that this is Dependency Injection.
            // And Singleton Pattern too, Taking this as a reference https://stackoverflow.com/questions/13970726/best-practices-efficient-sprite-drawing-in-xna
            spriteBatch.Begin();
            player.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void ExitGame()
        {
            this.Exit();
        }
    }
}