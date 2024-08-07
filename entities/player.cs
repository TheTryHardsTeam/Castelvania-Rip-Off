using System;
using Microsoft.Xna.Framework;
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
    public override Texture2D sprite { get; set; }
    public override bool ShouldShowBoundingBox { get; set; }
    public override int id { get; }
    public override bool isPlayable { get; }
    public Player(string name, int health, int mana, float x, float y, float width, float height, Texture2D texture, bool isPlayable = true)
    {
        this.name = name;
        this.health = health;
        this.mana = mana;
        this.position = new Vector2(x, y);
        this.width = width;
        this.height = height;
        this.sprite = texture;
        this.isPlayable = isPlayable;
        this.ShouldShowBoundingBox = true;
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
            this.position += this.MoveUp();
        }

        if (currenteState.IsKeyDown(Keys.S))
        {
            this.position += this.MoveDown();
        }

        if (currenteState.IsKeyDown(Keys.A))
        {
            this.position += this.MoveLeft();
        }

        if (currenteState.IsKeyDown(Keys.D))
        {
            this.position += this.MoveRight();
        }
    }

    private Vector2 MoveUp()
    {
        return new Vector2(0, -1);
    }

    private Vector2 MoveDown()
    {
        return new Vector2(0, 1);
    }

    private Vector2 MoveLeft()
    {
        return new Vector2(-1, 0);
    }

    private Vector2 MoveRight()
    {
        return new Vector2(1, 0);
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