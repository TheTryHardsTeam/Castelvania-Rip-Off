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

    override public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(this.sprite, this.position, Color.White);
    }
}