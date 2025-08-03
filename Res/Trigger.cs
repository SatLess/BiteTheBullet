using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace BiteTheBullet
{
    public class Trigger : Node
    {
        private Collider _collider;
        public EventHandler Triggered;

        public override void Update(float deltaTime)
        {
            if(_collider.isTouchingX(Vector2.Zero) && _collider.isTouchingY(Vector2.Zero))
            {
                Triggered?.Invoke(this,EventArgs.Empty);
            }
            base.Update(deltaTime);
        }

        public Trigger(Collider col)
        {
            this._collider = col;
        }
    }
}
