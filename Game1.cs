using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace BiteTheBullet;

public class Game1: Core
{
    public Game1() : base("Here be Dragons", 640, 480){}
    Player player;
    Sprite test;
    Sprite ass;
    Matrix translation = Matrix.Identity;

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        base.Initialize();
    }

    protected override void LoadContent()
    {
        Texture2D tex = Content.Load<Texture2D>("rpg");
        player = new(Content.Load<Texture2D>("player"));
        ass = new(Content.Load<Texture2D>("player"));
        ass.pos = new Vector2(0/2, 0/2);
        test = new(tex);
        test.pos = new Vector2(0 / 2, 0 / 2);
        player.pos = new(240 / 2, 240 / 2);
        //test.AddChild(new RectCollider(test.pos, new Vector2(tex.Width, tex.Height),Utils.getColliders()));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        base.Update(gameTime);
        player.Update(deltaTime);
        test.Update(deltaTime);
        if (Utils.getCurrentCamera() != null) translation = Utils.getCurrentCamera().translation;
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        SpriteBatch.Begin(transformMatrix: translation);
        
        test.Draw(deltaTime);
        ass.Draw(deltaTime);
        player.Draw(deltaTime);
        SpriteBatch.End();
        base.Draw(gameTime);
    }
}
