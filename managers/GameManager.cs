using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
///  Class <c>GameManager</c> represents the game manager. 
///  It is responsible for managing the game state, such as the current level, the player's score, and the game's difficulty.
/// </summary>
class GameManager
{
    State currentState;
    ContentManager content { get; set; }

    public GameManager(ContentManager content)
    {
        this.content = content;
        this.currentState = new PlayingState();
        this.currentState.LoadState(this.content);
    }

    public void UpdateState()
    {
        this.currentState.UpdateState();
    }

    public void DrawState(SpriteBatch spriteBatch, Texture2D boundingBoxPixel = null)
    {
        this.currentState.DrawState(spriteBatch, boundingBoxPixel);
    }

    public void LoadState()
    {
        this.currentState.LoadState(this.content);
    }

    public void UnloadState()
    {
        this.currentState.UnloadState();
    }

    public void ChangeState(State state)
    {
        if (state == null) return;
        if (this.currentState == state) return;

        if (this.currentState != null)
        {
            this.currentState.UnloadState();
            this.currentState = state;
            this.currentState.LoadState(this.content);
        }
    }
}