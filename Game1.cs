using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;


namespace BiteTheBullet;

public class Game1: Core
{
    public Game1() : base("Here be Dragons", 640, 480){}
    Matrix translation = Matrix.Identity;
    Sprite spr;
    Player p;


    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        base.Initialize();
    }

    protected override void LoadContent()
    {
        TestScene scene = new();
        addScene(scene);
        spr = new("rpg");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        base.Update(gameTime);
         scenes.First().Update(deltaTime);
        spr.Update(deltaTime);
        if (Utils.getCurrentCamera() != null) translation = Utils.getCurrentCamera().translation;
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        SpriteBatch.Begin(transformMatrix: translation);
        spr.Draw(deltaTime);
        scenes.First().Draw(deltaTime);
       
        SpriteBatch.End();
        base.Draw(gameTime);
    }
}
