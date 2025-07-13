using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BiteTheBullet
{
    public class Sprite : Node
    {
        protected Texture2D Texture;
        public Vector2 size;


        override public void Draw(float deltatime)
        {
            Core.SpriteBatch.Draw(Texture, GlobalPosition, Color.White);
            base.Draw(deltatime);
        }

        public Sprite(Texture2D texture, Node parent = null) : base(parent)
        {
           this.Texture = texture;
           this.size = new(texture.Width, texture.Height);
        }
    }
}
