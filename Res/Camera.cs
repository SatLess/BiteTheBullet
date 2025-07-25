using Microsoft.Xna.Framework;

namespace BiteTheBullet
{
    public class Camera : Node
    {

        private Vector2 _focus = new(640f,480f);

        public bool Current = false;
        public Matrix Translation { get; private set; }
        public Vector2 Focus
        {
            set => _focus = value;
            get => _focus;
        }

        public override void Update(float deltaTime)
        {
            float dx = GlobalPosition.X - _focus.X / 2f;
            float dy = GlobalPosition.Y - _focus.Y / 2f;
            Translation = Matrix.CreateTranslation(-dx, -dy, 0f);
            base.Update(deltaTime);
        }

        public Camera(Node parent) : base(parent)
        {

        }

    }
}
