using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BiteTheBullet
{
    public class Sprite: Object
    {
        protected Texture2D texture;


        override public void Draw(float deltaTime)
        {
            Core.SpriteBatch.Draw(texture, pos, Color.White);
        }

        public Sprite(Texture2D sprite)
        {
            texture = sprite;
        }
    }
}
