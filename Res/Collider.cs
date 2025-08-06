using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BiteTheBullet
{
    public class Collider : Node
    {
        public Vector2 Size = Vector2.Zero;
        public float Top => GlobalPosition.Y;
        public float Bottom => GlobalPosition.Y + Size.Y;
        public float Left => GlobalPosition.X;
        public float Right => GlobalPosition.X + Size.X;

        public Texture2D DebugTexture = null;
        public new CollisionLayers Layer = CollisionLayers.Default;
        public new CollisionLayers Mask = CollisionLayers.Default;

        //private List<Collider> _colliders;

        static public List<Collider> SceneColliders = new(); //May move this in the future TODO
        static public List<Collider> RemovedColliders = new();


        public Collider(Vector2 size, List<Collider> list, Texture2D debug = null): base()
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
            foreach (var item in RemovedColliders)
            {
                SceneColliders.Remove(item);
            }

            base.Update(deltaTime);
        }

        #region Colloision

        public bool isTouchingX(Vector2 offset)
        {
            foreach (var item in SceneColliders)
            {
                if (item == this || !Mask.HasFlag(item.Layer)) continue;
                if (IsTouchingLeft(item, offset) || IsTouchingRight(item, offset)) return true;
            }
            return false;
        }

        public bool isTouchingY(Vector2 offset)
        {
            foreach (var item in SceneColliders)
            {
                if (item == this || !Mask.HasFlag(item.Layer)) continue;
                if (IsTouchingTop(item, offset) || IsTouchingBottom(item, offset)) return true;
            }
            return false;
        }

        public bool IsTouchingLeft(Collider col, Vector2 offset)
        {
            return this.Right + offset.X > col.Left &&
              this.Left < col.Left &&
              this.Bottom > col.Top &&
              this.Top < col.Bottom;
        }

        public bool IsTouchingRight(Collider col, Vector2 offset)
        {
            return this.Left + offset.X < col.Right &&
              this.Right > col.Right &&
              this.Bottom > col.Top &&
              this.Top < col.Bottom;
        }

        public bool IsTouchingTop(Collider col, Vector2 offset)
        {
            return this.Bottom + offset.Y > col.Top &&
              this.Top < col.Top &&
              this.Right > col.Left &&
              this.Left < col.Right;
        }

        public bool IsTouchingBottom(Collider col, Vector2 offset)
        {
            return this.Top + offset.Y < col.Bottom &&
              this.Bottom > col.Bottom &&
              this.Right > col.Left &&
              this.Left < col.Right;
        }

        #endregion

    }
}
