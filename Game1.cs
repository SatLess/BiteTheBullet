using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace BiteTheBullet;

public class Game1: Core
{
    public Game1() : base("Here be Dragons", 640, 480){}

    Matrix translation = Matrix.Identity;

    Node Scene;
    Player pl;
    Sprite hey;
    Camera cam;
    List<string> HelloWorld = new();

    protected override void Initialize()
    {
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        Scene = new();
        //Dialogue Testing
        HelloWorld.Add("hello");
        HelloWorld.Add("World");
        HelloWorld.Add(" I am a gay");

        //Player
        Texture2D tex = Content.Load<Texture2D>("player");
        pl = new(tex, Vector2.Zero, Vector2.Zero);
        Scene.AddChild(pl);

        //Test
        hey = new(tex);
        hey.Position += new Vector2(20, 0);
        Scene.AddChild(hey);

        //Camera
        cam = new();
        pl.AddChild(cam); // TODO need to do this inside player, but since its a quick way ill allow it

        //dialogue
        Scene.AddChild(new DialogueBox(HelloWorld));

        //collider
        Collider col = new Collider(new(120,120), null, Content.Load<Texture2D>("test"));
        Collider playerCol = new Collider(new(120,120), null, Content.Load<Texture2D>("test"));
        pl.AddChild(playerCol);
        hey.AddChild(col);
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
