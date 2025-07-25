using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace BiteTheBullet;

public class Node
{
    private Node _dad = null;
    private Vector2 _globalPosition;
    private Vector2 _position;

    private List<Node> _children;
    private List<Node> _removedChildren;
    private List<Node> _addedChildren;

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
    public LayerEnum Layer = LayerEnum.Default; //could refactor so only sprites have layers

    public Node (Node father = null, bool addAfterCreation = true)
    {
        _children = new();
        _removedChildren = new();
        _addedChildren = new();
        this._dad = father;
        this.GlobalPosition = Vector2.Zero;
        Load(); // WARNING Should children have priority?
        if (_dad != null && addAfterCreation) _dad.AddChild(this);
    }

    public Node(Vector2 globalPosition, Node father = null, bool addAfterCreation = true)
    {
        _children = new();
        _removedChildren = new();
        _addedChildren = new();
        this._dad = father;
        this.GlobalPosition = _globalPosition;
        if (_dad != null && addAfterCreation) _dad.AddChild(this);
    }

    protected void SortByPriority()
    {
        if (_children.Count == 0)
        {
            return;
        }
        _children.Sort((a, b) => a.Layer.CompareTo(b.Layer));
    }

    protected void AddChild(Node child)
    {
        _addedChildren.Add(child);
    }

    protected void RemoveChild(Node child)
    {
        _removedChildren.Add(child);
    }
    public virtual void Load() { }
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

        foreach (var child in _removedChildren)
        {
            _children.Remove(child);
        }
        if(_removedChildren.Count != 0) _removedChildren.Clear();

        foreach (var child in _addedChildren)
        {
            _children.Add(child);
        }

        if (_addedChildren.Count != 0)
        {
            _addedChildren.Clear();
            SortByPriority();
        }
    }

    public void testGlobalPosition(float deltaTime)
    {
        KeyboardState keyState = Keyboard.GetState();
        Vector2 direction = Vector2.Zero;
        direction.X = Convert.ToInt16(keyState.IsKeyDown(Keys.D)) - Convert.ToInt16(keyState.IsKeyDown(Keys.A));
        direction.Y = Convert.ToInt16(keyState.IsKeyDown(Keys.S)) - Convert.ToInt16(keyState.IsKeyDown(Keys.W));

        GlobalPosition += direction * 10;
        Debug.Write("Global " + GlobalPosition);
        Debug.Write("\n");
        Update(deltaTime);
    }

}
