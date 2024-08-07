using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// Class <c>Player</c> represents any player in the game.
/// </summary>
class Player : Entity
{
    private KeyboardState currenteState;
    private string name { get; set; }
    private int health { get; set; }
    private int mana { get; set; }
    public override Vector2 position { get; set; }
    public override float width { get; }
    public override float height { get; }
    public override bool ShouldShowBoundingBox { get; set; }
    public override int id { get; }
    public override bool isPlayable { get; }

    public Player(string name, float x, float y, float width, float height, string spritePath, ContentManager content) : base(content, spritePath)
    {
        this.name = name;
        this.position = new Vector2(x, y);
        this.width = width;
        this.height = height;
        this.sprite = sprite;
        this.ShouldShowBoundingBox = false;
        this.id = 0;
        this.isPlayable = true;
    }

    /// <summary>
    /// Moves the player in a given direction.
    /// </summary>
    /// <param name="direction">The direction to move the player.</param>
    /// <returns>void</returns>
    public void Move()
    {
        if (!this.isPlayable) return;

        currenteState = Keyboard.GetState();

        if (currenteState.IsKeyDown(Keys.W))
        {
            this.position += new Vector2(0, -1);
        }

        if (currenteState.IsKeyDown(Keys.S))
        {
            this.position += new Vector2(0, 1);
        }

        if (currenteState.IsKeyDown(Keys.A))
        {
            this.position += new Vector2(-1, 0);
        }

        if (currenteState.IsKeyDown(Keys.D))
        {
            this.position += new Vector2(1, 0);
        }
    }

    override public void Update(GameTime gameTime)
    {
        this.Move();
    }

    override public void Draw(SpriteBatch spriteBatch, Texture2D boundingBoxPixel = null)
    {
        spriteBatch.Draw(this.sprite, this.position, Color.White);
        if (this.ShouldShowBoundingBox && boundingBoxPixel != null)
        {
            this.drawBoundingBox(spriteBatch, boundingBoxPixel);
        }
    }

    private void drawBoundingBox(SpriteBatch spriteBatch, Texture2D boundingBoxPixel)
    {
        int x = (int)this.position.X;
        int y = (int)this.position.Y;
        int width = (int)this.width;
        int height = (int)this.height;

        // Top border
        spriteBatch.Draw(boundingBoxPixel, new Rectangle(x, y, width, 1), Color.Red);
        // Bottom border
        spriteBatch.Draw(boundingBoxPixel, new Rectangle(x, y + height, width, 1), Color.Red);
        // Left border
        spriteBatch.Draw(boundingBoxPixel, new Rectangle(x, y, 1, height), Color.Red);
        // Right border
        spriteBatch.Draw(boundingBoxPixel, new Rectangle(x + width, y, 1, height), Color.Red);
    }

    // <summary>
    // Checks if the player is colliding with another entity. Using the AABB collision detection.
    // </summary>
    // <param name="entity">The entity to check if is colliding with the player.</param>
    // <returns>bool</returns>
    override public bool isColliding(Entity entity)
    {
        bool isCollidingFromLeft = this.position.X < entity.position.X + entity.width;
        bool isCollidingFromRight = this.position.X + this.width > entity.position.X;
        bool isCollidingFromTop = this.position.Y < entity.position.Y + entity.height;
        bool isCollidingFromBottom = this.position.Y + this.height > entity.position.Y;

        return isCollidingFromLeft && isCollidingFromRight && isCollidingFromTop && isCollidingFromBottom;
    }
}