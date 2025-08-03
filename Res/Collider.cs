using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BiteTheBullet
{
    public struct CollisionInfo
    {
        /*  Note: you can check both horz and vert movement with one Data;
         *  000 - No collision info
         *  0X1 - Horizontal from the right
         *  1X1 - Horizontal from the left
         *  01X - Vertical from the right
         *  11X - Vertical from the left
         */
        public uint Data;
        public const uint NONE = 0b_000;
        public const uint DIRECTION = 0b_100;
        public const uint HORIZONTAL = 0b_001;
        public const uint VERTICAL = 0b_010;
    }
    public class Collider : Node
    {
        public Vector2 Size = Vector2.Zero;
        public float Top => GlobalPosition.Y;
        public float Bottom => GlobalPosition.Y + Size.Y;
        public float Left => GlobalPosition.X;
        public float Right => GlobalPosition.X + Size.X;

        public Texture2D DebugTexture = null;

        //private List<Collider> _colliders;
        
        static public List<Collider> SceneColliders = new(); //May move this in the future TODO
        static public List<Collider> RemovedColliders = new();


        public Collider(Vector2 size, List<Collider> list, Texture2D debug = null)
        {
            this.Size = size;
            //this._colliders = list;
            this.DebugTexture = debug;
            SceneColliders.Add(this);
        }

        public override void OnRemove()
        {
            RemovedColliders.Add(this);
            base.OnRemove();
        }

        public override void Draw(float deltaTime)
        {
            if (DebugTexture != null)
            {
                Core.SpriteBatch.Draw(DebugTexture, GlobalPosition, Color.Black);
            }
            base.Draw(deltaTime);
        }

        public override void Update(float deltaTime)
        {
            CollisionInfo a = isTouching();
            foreach (var item in RemovedColliders)
            {
                SceneColliders.Remove(item);
            }

            base.Update(deltaTime);
        }

        public CollisionInfo isTouching()
        {
            CollisionInfo col;
            col.Data = CollisionInfo.NONE;
            foreach (var item in SceneColliders) //TODO optimize that
            {
                if (item == this) break;

                 col.Data = CollisionInfo.NONE;
                 col.Data = (Left < item.Right && Right > item.Left) ? col.Data | CollisionInfo.HORIZONTAL : col.Data;
                 col.Data = (Top < item.Bottom && Bottom > item.Top) ? col.Data | CollisionInfo.VERTICAL : col.Data;
                 col.Data = (Left < item.Left) ? col.Data | CollisionInfo.DIRECTION : col.Data;
             
                 if ((col.Data & 0b_011 | 0b_011) != 0) break;

            }
            return col;
        }

        private bool AABB(Collider col) // TODO could use transform instead?
        {
            if (col == this) return false;
            return Left < col.Right && Right > col.Left
                && Top < col.Bottom && Bottom > col.Top;
        }
    }
}
