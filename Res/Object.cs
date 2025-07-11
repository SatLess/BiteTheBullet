using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace BiteTheBullet;

public abstract class Object
{
    
    public Vector2 position { get; set; }
    public Point scale;
  
    protected Dictionary<Type, Object> children;

    virtual public void Draw(float deltaTime) {

        foreach (var child in children.OrderBy(o => o.Value.renderLayer).ToDictionary())
        {
            child.Value.Draw(deltaTime);
        }
    }
    virtual public void Update(float deltaTime)
    {
        foreach (var child in children)
        {
            child.Value.position = position; //Apllying ofsset for now will break the game
            child.Value.Update(deltaTime);
        }
    }

    public void AddChild(Object child)
    {
        children.Add(child.GetType(), child);
    }

    public void RemoveChild(Object child)
    {
        children.Remove(child.GetType());
    }

    public Object(float x = 0f, float y = 0f, int scale = 1)
    {
        this.position = new(x, y);
        this.scale = new(scale);
        children = new();
    }


    public int renderLayer = 0; // will use this as placeholder
    

}
