using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace castelvaniaripoff
{
    class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D pixel;
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

            // TODO Move this to the main manu state once implemented
            backgroundMusic = Content.Load<Song>("Audio/Music/main_menu");
            MediaPlayer.Play(backgroundMusic);
            MediaPlayer.IsRepeating = true;

            // TODO Remove once the dev work is done 
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new[] { Color.White });
            base.LoadContent();
        }

        override protected void Update(GameTime gameTime)
        {
            gameManager.UpdateState(gameTime);
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
    }
}