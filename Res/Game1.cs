using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BiteTheBullet;

public class Game1: Core
{
    public Game1() : base("Here be Dragons", 640, 480){}
    Matrix translation = Matrix.Identity;

    Object parent;
    Object child;

    protected override void Initialize()
    {
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        parent = new(Vector2.Zero,null);
        child = new(new(1,0), parent);
    }

    protected override void Update(GameTime gameTime)
    {

        child.testChildPosition();
        parent.Update(deltaTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        SpriteBatch.Begin(transformMatrix: translation);
        SpriteBatch.End();
        base.Draw(gameTime);
    }
}
