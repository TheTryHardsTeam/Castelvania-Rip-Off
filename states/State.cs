using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public abstract class State
{
    public abstract void LoadState(ContentManager content);
    public abstract void UpdateState(GameTime gameTime);
    public abstract void DrawState(SpriteBatch spriteBatch, Texture2D boundingBoxPixel = null);
    public abstract void UnloadState();
}