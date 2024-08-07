using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Class <c>Entity</c> represents a generic entity in the game. We can call it like a GameObject in Unity.
/// </summary>
abstract class Entity
{
    public abstract int id { get; }
    public abstract float width { get; }
    public abstract float height { get; }
    public abstract Vector2 position { get; set; }
    public Texture2D sprite { get; set; }
    public abstract bool isPlayable { get; }
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch, Texture2D boundingBoxPixel = null);
    public abstract bool isColliding(Entity entity);
    public abstract bool ShouldShowBoundingBox { get; set; }

    public Entity(ContentManager content, string spritePath)
    {
        this.sprite = content.Load<Texture2D>(spritePath);
        this.ShouldShowBoundingBox = false;
    }
}