using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

class PlayingState : State
{
    private Player player;

    public override void LoadState(ContentManager content)
    {
        player = new Player("Player", 50, 50, 24, 24, "Graphics/Characters/main", content);
    }

    public override void UpdateState()
    {
        // Update the main menu
    }

    public override void DrawState(SpriteBatch spriteBatch, Texture2D boundingBoxPixel = null)
    {
        player.Draw(spriteBatch, boundingBoxPixel);
    }

    public override void UnloadState()
    {
        // Unload the main menu
    }
}