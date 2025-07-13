using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

#nullable enable

namespace BiteTheBullet;

public class Object
{
    private Object? _dad;
    private Vector2 _globalPosition;
    private Vector2 _position;
    private Dictionary<Type, Object> _children;

    public Vector2 GlobalPosition
    {
        get {
            return (_dad == null) ? _globalPosition : _dad.GlobalPosition + _position;
        }

        set
        {
            _globalPosition = value;
            if (_dad == null)
            { 
                _position = value;
            }
        }
    }
    public Vector2 Position
    {
        get
        {
            return (_dad != null)? _globalPosition - _dad.GlobalPosition : _position;
        }

        set
        {
            _position = new(10,0);

            if (_dad == null)
            {
                _globalPosition = value;
            }
        }

    }

    protected void AddChild(Object child)
    {
        _children.Add(child.GetType(), child);
    }

    public virtual void Draw(float deltaTime)
    {
        foreach (var item in _children.Values)
        {
            item.Draw(deltaTime);
        }
    }
    public virtual void Update(float deltaTime)
    {
        foreach (var item in _children.Values)
        {
            item.Update(deltaTime);
        }
    }

    public Object(Vector2 globalPosition, Object? father)
    {
        _children = new();
        if (father != null) _dad = father;
        //Update initial position values
        this.GlobalPosition = globalPosition;
        this.Position = globalPosition; //Just so it sets the ofsset correctly
        
    }

    public void testGlobalPosition(float deltaTime)
    {
        KeyboardState keyState = Keyboard.GetState();
        Vector2 direction = Vector2.Zero;
        direction.X = Convert.ToInt16(keyState.IsKeyDown(Keys.D)) - Convert.ToInt16(keyState.IsKeyDown(Keys.A));
        direction.Y = Convert.ToInt16(keyState.IsKeyDown(Keys.S)) - Convert.ToInt16(keyState.IsKeyDown(Keys.W));

        GlobalPosition += direction;
        Debug.Write("Global " + GlobalPosition);
        Debug.Write("\n");
        Debug.Write("Local " + Position);
        Debug.Write("\n");
        Update(deltaTime);
    }

    public void testPosition(float deltaTime)
    {
        KeyboardState keyState = Keyboard.GetState();
        Vector2 direction = Vector2.Zero;
        direction.X = Convert.ToInt16(keyState.IsKeyDown(Keys.D)) - Convert.ToInt16(keyState.IsKeyDown(Keys.A));
        direction.Y = Convert.ToInt16(keyState.IsKeyDown(Keys.S)) - Convert.ToInt16(keyState.IsKeyDown(Keys.W));

        Position += direction;
        Debug.Write("Global " + GlobalPosition);
        Debug.Write("\nLocal " + Position);
    }

    public void testChildPosition()
    {
        KeyboardState keyState = Keyboard.GetState();
        Vector2 direction = Vector2.Zero;
        direction.X = Convert.ToInt16(keyState.IsKeyDown(Keys.D)) - Convert.ToInt16(keyState.IsKeyDown(Keys.A));
        direction.Y = Convert.ToInt16(keyState.IsKeyDown(Keys.S)) - Convert.ToInt16(keyState.IsKeyDown(Keys.W));

        Position += direction;
        Debug.Write("Global " + GlobalPosition);
        Debug.Write("\n");
        Debug.Write("Local " + Position);
        Debug.Write("\n");
    }

}
