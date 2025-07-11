using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace BiteTheBullet;

public abstract class Object
{
    public Vector2 pos { get; set; }
    public Point scale;
    protected Dictionary<String, Object> children;

    virtual public void Draw(float deltaTime) {

        foreach (var child in children)
        {
            child.Value.Draw(deltaTime);
        }
    }
    virtual public void Update(float deltaTime)
    {
        foreach (var child in children)
        {
            child.Value.pos = pos; //Apply changes in pos, unable to make offset for now
            child.Value.Update(deltaTime);
        }
    }

    public void AddChild(Object child)
    {
        children.Add(child.GetType().Name, child);
    }

    public void RemoveChild(Object child)
    {
        children.Remove(child.GetType().Name);
    }

    public Object(float x = 0f, float y = 0f, int scale = 1)
    {
        this.pos = new(x, y);
        this.scale = new(scale);
        children = new();
    }


}
