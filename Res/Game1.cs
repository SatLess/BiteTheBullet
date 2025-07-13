using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BiteTheBullet;

public class Game1: Core
{
    public Game1() : base("Here be Dragons", 640, 480){}
    Matrix translation = Matrix.Identity;

    Sprite oi;
    Sprite hey;

    protected override void Initialize()
    {
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        Texture2D tex = Content.Load<Texture2D>("player");
        oi = new(tex);
        hey = new(Content.Load<Texture2D>("test"), oi);
        hey.Position += new Vector2(20, 0);
    }

    protected override void Update(GameTime gameTime)
    {
        oi.testGlobalPosition(deltaTime);
        oi.Update(deltaTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        SpriteBatch.Begin(transformMatrix: translation);
        oi.Draw(deltaTime);
        SpriteBatch.End();
        base.Draw(gameTime);
    }
}
