using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace BiteTheBullet;

public class Player : Node
{
    protected float Speed = 150f;
    public Vector2 Velocity = Vector2.Zero;
    Collider pCol;
    Sprite _spr;

    public override void Draw(float deltaTime)
    {
        base.Draw(deltaTime);
    }

    public override void Update(float deltaTime)
    {

        Vector2 direction = GetMovementDirection();
        Velocity = direction * Speed * deltaTime;
        if (Velocity.X != 0 && pCol.isTouchingX(Velocity)) Velocity.X = 0;
        if (Velocity.Y != 0 && pCol.isTouchingY(Velocity)) Velocity.Y = 0;


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
        pCol = new Collider(new(120, 120), null, Core.Content.Load<Texture2D>("test"));
        AddChild(pCol);
    }
}
