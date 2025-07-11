using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BiteTheBullet
{
    public class Sprite: Object
    {
        public Texture2D texture { get; protected set; }
        public int layer = 0; //TODO need to create a layer component so children can have multiple layers

        override public void Draw(float deltaTime)
        {
            Core.SpriteBatch.Draw(texture, position, Color.White);
        }

        public Sprite(string textureName, int layer = 0)
        {
            texture = Core.Content.Load<Texture2D>(textureName);
        }

        public void setLayer(int newLayer)
        {
            layer = newLayer;
        }
    }
}
