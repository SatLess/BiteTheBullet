using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiteTheBullet
{
    public class TestScene: Object
    {
       public TestScene()
        {
           AddChild(new Player("player"));
           Sprite spr = new("Elevado");
           spr.position = new(600, 300);
           spr.AddChild(new RectCollider(spr.position, new(spr.texture.Width, spr.texture.Height), Utils.getColliders()));
           AddChild(spr);
        }

        public override void Draw(float deltaTime)
        {
            base.Draw(deltaTime);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
        }

    }
}
