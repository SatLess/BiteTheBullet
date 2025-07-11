using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace BiteTheBullet;

public class Player : Object
{
    protected float speed = 150f;
    public Vector2 velocity = Vector2.Zero;
    RectCollider collider;

    public override void Draw(float deltaTime)
    {
        base.Draw(deltaTime);
    }

    public override void Update(float deltaTime)
    {
        
        Vector2 direction = GetMovementDirection();
        velocity = direction * speed * deltaTime;
        if (velocity.X != 0 && collider.collisionX(velocity)) velocity.X = 0;
        if (velocity.Y != 0 && collider.collisionY(velocity)) velocity.Y = 0;

        position += velocity;

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

    public Player(string textureName, float x = 0f, float y = 0f, int scale = 1) : base(x, y, scale)
    {
        renderLayer = 1;
        AddChild(new Sprite(textureName));
        collider = new RectCollider(position, new Vector2(120f,120f), Utils.getColliders());
        AddChild(collider);
        AddChild(new Camera());
    }
}
