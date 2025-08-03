using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace BiteTheBullet;

public class Player : Node
{
    protected float Speed = 150f;
    public Vector2 Velocity = Vector2.Zero;
    Sprite _spr;

    public override void Draw(float deltaTime)
    {
        base.Draw(deltaTime);
    }

    public override void Update(float deltaTime)
    {

        Vector2 direction = GetMovementDirection();
        Velocity = direction * Speed * deltaTime;
        // if (velocity.X != 0 && a.collisionX(velocity)) velocity.X = 0;
        //  if (velocity.Y != 0 && a.collisionY(velocity)) velocity.Y = 0;

        GlobalPosition += Velocity;

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

    public Player(Texture2D tex, Vector2 GlobalPosition, Vector2 LocalPosition) : base(GlobalPosition)
    { 
        AddChild(new Sprite(tex));
    }
}
