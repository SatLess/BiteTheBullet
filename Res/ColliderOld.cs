////using Microsoft.Xna.Framework;
////using Microsoft.Xna.Framework.Graphics;


////namespace BiteTheBullet
////{
////    public class Collider : Object
////    {
////        public Vector2 size; //Might not be my brightest idea to convert everything to vec2
////        private List<RectCollider> colliders;
////        public Rectangle temp;


////        public RectCollider(Vector2 pos, Vector2 size, List<RectCollider> list)
////        {
////            Point intPos = Utils.vectorToPoint(pos);
////            this.size = size;
////            Utils.addToCollider(this);
////            colliders = list;
////            temp = new(intPos, new Point(120));
////        }

////        public override void Update(float deltaTime)
////        {
////            temp = new(Utils.vectorToPoint(GlobalPosition), Utils.vectorToPoint(size));
////            base.Update(deltaTime);
////        }

////        #region Colloision

////        public bool collisionX(Vector2 velocity)
////        {
////            foreach (var item in colliders)
////            {
////                if (item == this) continue;
////                if (IsTouchingLeft(item, velocity) || IsTouchingRight(item, velocity)) return true;
////            }
////            return false;
////        }

////        public bool collisionY(Vector2 velocity)
////        {
////            foreach (var item in colliders)
////            {
////                if (item == this) continue;
////                if (IsTouchingTop(item, velocity) || IsTouchingBottom(item, velocity)) return true;
////            }
////            return false;
////        }

////        public bool IsTouchingLeft(RectCollider sprite, Vector2 velocity)
////        {
////            return this.temp.Right + velocity.X > sprite.temp.Left &&
////              this.temp.Left < sprite.temp.Left &&
////              this.temp.Bottom > sprite.temp.Top &&
////              this.temp.Top < sprite.temp.Bottom;
////        }

////        public bool IsTouchingRight(RectCollider sprite, Vector2 velocity)
////        {
////            return this.temp.Left + velocity.X < sprite.temp.Right &&
////              this.temp.Right > sprite.temp.Right &&
////              this.temp.Bottom > sprite.temp.Top &&
////              this.temp.Top < sprite.temp.Bottom;
////        }

////        public bool IsTouchingTop(RectCollider sprite, Vector2 velocity)
////        {
////            return this.temp.Bottom + velocity.Y > sprite.temp.Top &&
////              this.temp.Top < sprite.temp.Top &&
////              this.temp.Right > sprite.temp.Left &&
////              this.temp.Left < sprite.temp.Right;
////        }

////        public bool IsTouchingBottom(RectCollider sprite, Vector2 velocity)
////        {
////            return this.temp.Top + velocity.Y < sprite.temp.Bottom &&
////              this.temp.Bottom > sprite.temp.Bottom &&
////              this.temp.Right > sprite.temp.Left &&
////              this.temp.Left < sprite.temp.Right;
////        }

////        #endregion

////    }
////}
