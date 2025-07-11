using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiteTheBullet.Res
{
    public class Camera: Object
    {
        Vector2 origin = Vector2.Zero;
        public Matrix translation { get; private set; }
        public bool current = false;
        public void setOrigin(Vector2 newOrigin) => origin = newOrigin;

        public override void Update(float deltaTime)
        {
            float dx = pos.X - 640 / 2;
            float dy = pos.Y - 480 / 2;
            translation = Matrix.CreateTranslation(-dx, -dy, 0f);
            base.Update(deltaTime);
        }

        public Camera()
        {
            Utils.setCurrentCamera(this);
        }

    }
}
