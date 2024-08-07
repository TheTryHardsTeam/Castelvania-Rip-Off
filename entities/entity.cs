using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Class <c>Entity</c> represents a generic entity in the game.
/// </summary>
abstract class Entity
{
    public abstract int id { get; }
    public abstract float width { get; }
    public abstract float height { get; }
    public abstract Vector2 position { get; set; }
    public abstract Texture2D sprite { get; set; }
    public abstract bool isPlayable { get; }
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);
}