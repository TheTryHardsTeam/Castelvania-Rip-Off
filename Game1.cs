using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace castelvaniaripoff
{
    class Game1 : Game
    {
        private KeyboardState keyboardState;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        Texture2D playerTexture, pixel;
        Song backgroundMusic;
        GameManager gameManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        override protected void Initialize()
        {

            base.Initialize();
        }

        override protected void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameManager = new GameManager(Content);

            backgroundMusic = Content.Load<Song>("Audio/Music/main_menu");
            MediaPlayer.Play(backgroundMusic);
            MediaPlayer.IsRepeating = true;

            // Doing this just to have to have a pixel to draw the bounding box. XNA is so powerful that it doesn't have a way to draw a simple rectangle.
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });
            base.LoadContent();
        }

        override protected void Update(GameTime gameTime)
        {
            gameManager.UpdateState();
            base.Update(gameTime);
        }

        override protected void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // We need to share the same instance of spriteBatch between the entities. We can say that this is Dependency Injection.
            // And Singleton Pattern too, Taking this as a reference https://stackoverflow.com/questions/13970726/best-practices-efficient-sprite-drawing-in-xna
            spriteBatch.Begin();
            gameManager.DrawState(spriteBatch, pixel);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void ExitGame()
        {
            this.Exit();
        }
    }
}