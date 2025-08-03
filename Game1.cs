using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BiteTheBullet;

public class Game1: Core
{
    public Game1() : base("Here be Dragons", 640, 480){}

    Matrix translation = Matrix.Identity;

    Node Scene;
    Sprite oi;
    Sprite hey;
    Camera cam;

    protected override void Initialize()
    {
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        Scene = new();
        Texture2D tex = Content.Load<Texture2D>("player");
        oi = new(tex);
        Scene.AddChild(oi);
        
        hey = new(Content.Load<Texture2D>("test"));
        hey.Position += new Vector2(20, 0);
        oi.Layer = LayerEnum.Background;
        cam = new();
        Scene.AddChild(hey);
        oi.AddChild(cam);
    }

    protected override void Update(GameTime gameTime)
    {
        Scene.Update(deltaTime);
        base.Update(gameTime);
        translation = cam.Translation;
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        SpriteBatch.Begin(transformMatrix: translation);
        Scene.Draw(deltaTime);
        SpriteBatch.End();
        base.Draw(gameTime);
    }
}
