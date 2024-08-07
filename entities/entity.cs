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
    // The position of the entity in the game. This will be used to draw the entity in the screen and collision detection.
    public abstract Vector2 position { get; set; }
    public abstract Texture2D sprite { get; set; }
    public abstract bool isPlayable { get; }
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch, Texture2D boundingBoxPixel = null);
    public abstract bool isColliding(Entity entity);
    public abstract bool ShouldShowBoundingBox { get; set; }
}