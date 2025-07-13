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

    private List<Object> _children;
    private List<Object> _abortedChildren;

    public Vector2 GlobalPosition
    {
        get {
            return (_dad == null) ? _globalPosition : _dad.GlobalPosition + _position; //global pos
        }

        set
        {
            _globalPosition = value;
            _position = (_dad == null) ? value : _globalPosition - _dad.GlobalPosition; //ofsset
        }
    }
    public Vector2 Position
    {
        get
        {
            return (_dad != null)? GlobalPosition - _dad.GlobalPosition : _position; //offset
        }

        set
        {
            _position = value;
            _globalPosition = (_dad == null) ? value : _dad.GlobalPosition + _position; //global pos
        }

    }


    protected void AddChild(Object child)
    {
        _children.Add(child);
    }

    protected void RemoveChild(Object child)
    {
        _abortedChildren.Add(child);
    }

    public virtual void Draw(float deltaTime)
    {
        foreach (var item in _children)
        {
            item.Draw(deltaTime);
        }
    }
    public virtual void Update(float deltaTime)
    {
        foreach (var item in _children)
        {
            item.Update(deltaTime);
        }

        foreach (var child in _abortedChildren)
        {
            _children.Remove(child);
        }

    }

    public Object(Vector2 globalPosition, Object? father)
    {
        _children = new();
        _abortedChildren = new();
        if (father != null) _dad = father;
        this.GlobalPosition = globalPosition;
        
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
        Update(deltaTime);
    }

    public void childGlobal()
    {
        Debug.Write("Child " + GlobalPosition);
        Debug.Write("\n");
    }

}
