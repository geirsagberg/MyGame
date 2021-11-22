using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ConsoleApp1;

public class MyGame : Game
{
    private readonly GraphicsDeviceManager deviceManager;

    private float x = 10;
    private float y = 10;

    private readonly Random random = new();
    private SpriteBatch spriteBatch = null!;
    private Texture2D texture = null!;
    
    public MyGame()
    {
        deviceManager = new GraphicsDeviceManager(this);
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        texture = new Texture2D(GraphicsDevice, 10, 10);

        x = ViewportWidth / 2f;
        y = ViewportHeight / 2f;
    }

    private int ViewportHeight => GraphicsDevice.Viewport.Height;

    private int ViewportWidth => GraphicsDevice.Viewport.Width;

    private float speedMultiplier = 0.5f;

    protected override void Update(GameTime gameTime)
    {
        x += (float)((random.NextDouble() - 0.5) * gameTime.ElapsedGameTime.TotalMilliseconds * speedMultiplier);
        x = Wrap(x, ViewportWidth);
        
        y += (float)((random.NextDouble() - 0.5) * gameTime.ElapsedGameTime.TotalMilliseconds * speedMultiplier);
        y = Wrap(y, ViewportHeight);
        
        base.Update(gameTime);
    }

    private static float Wrap(float coord, int constraint)
    {
        if (coord >= constraint)
            return coord - constraint;
        else if (coord < 0)
            return coord + constraint;
        return coord;
    }

    protected override void Draw(GameTime gameTime)
    {
        deviceManager.GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();
        spriteBatch.Draw(texture, new Vector2(x, y), Color.White);
        spriteBatch.End();
        
        base.Draw(gameTime);
    }
}