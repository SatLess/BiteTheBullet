using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BiteTheBullet
{
    public class RectCollider : Object
    {
        public Vector2 size; //Might not be my brightest idea to convert everything to vec2
        private List<RectCollider> colliders;

        float left => position.X;
        float top => position.Y;
        float right => position.X + size.X;
        float bottom => position.Y + size.Y;


        public RectCollider(Vector2 position, Vector2 size, List<RectCollider> list)
        {
            this.size = size;
            Utils.addToCollider(this);
            colliders = list;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }

        #region Collision

        public bool collisionX(Vector2 velocity)
        {
            foreach (var item in colliders)
            {
                if (item == this) continue;
                if (IsTouchingLeft(item, velocity) || IsTouchingRight(item, velocity)) return true;
            }
            return false;
        }

        public bool collisionY(Vector2 velocity)
        {
            foreach (var item in colliders)
            {
                if (item == this) continue;
                if (IsTouchingTop(item, velocity) || IsTouchingBottom(item, velocity)) return true;
            }
            return false;
        }

        public bool IsTouchingLeft(RectCollider sprite, Vector2 velocity)
        {
            return this.right + velocity.X > sprite.left &&
              this.left < sprite.left &&
              this.bottom > sprite.top &&
              this.top < sprite.bottom;
        }

        public bool IsTouchingRight(RectCollider sprite, Vector2 velocity)
        {
            return this.left + velocity.X < sprite.right &&
              this.right > sprite.right &&
              this.bottom > sprite.top &&
              this.top < sprite.bottom;
        }

        public bool IsTouchingTop(RectCollider sprite, Vector2 velocity)
        {
            return this.bottom + velocity.Y > sprite.top &&
              this.top < sprite.top &&
              this.right > sprite.left &&
              this.left < sprite.right;
        }

        public bool IsTouchingBottom(RectCollider sprite, Vector2 velocity)
        {
            return this.top + velocity.Y < sprite.bottom &&
              this.bottom > sprite.bottom &&
              this.right > sprite.left &&
              this.left < sprite.right;
        }

        #endregion

    }
}
