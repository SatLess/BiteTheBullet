using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using BiteTheBullet.Res;

namespace BiteTheBullet;

public class Player : Object
{
    protected float speed = 150f;
    public Vector2 velocity = Vector2.Zero;
    RectCollider a;

    public override void Draw(float deltaTime)
    {
        base.Draw(deltaTime);
    }

    public override void Update(float deltaTime)
    {
        
        Vector2 direction = GetMovementDirection();
        velocity = direction * speed * deltaTime;
        if (velocity.X != 0 && a.collisionX(velocity)) velocity.X = 0;
        if (velocity.Y != 0 && a.collisionY(velocity)) velocity.Y = 0;

        pos += velocity;

        base.Update(deltaTime);

    }


    private Vector2 GetMovementDirection()
    {
        KeyboardState keyState = Keyboard.GetState();
        Vector2 direction = Vector2.Zero;
        direction.X = Convert.ToInt16(keyState.IsKeyDown(Keys.D)) - Convert.ToInt16(keyState.IsKeyDown(Keys.A));
        direction.Y = Convert.ToInt16(keyState.IsKeyDown(Keys.S)) - Convert.ToInt16(keyState.IsKeyDown(Keys.W));
        return (direction.Length() == 0) ? direction : Vector2.Normalize(direction);
    }

    public Player(Texture2D tex, float x = 0f, float y = 0f, int scale = 1) : base(x, y, scale)
    {
        AddChild(new Sprite(tex));
        //rect = new((int)x, (int)y, tex.Width, tex.Height);
        a = new RectCollider(pos, new Vector2(tex.Width,tex.Height), Utils.getColliders());
        AddChild(a);
        AddChild(new Camera());
    }
}
