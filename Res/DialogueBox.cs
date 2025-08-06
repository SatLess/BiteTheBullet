using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace BiteTheBullet
{
    public class DialogueBox : Node
    {
        List<string> _lines; //will change to json if needed;
        SpriteFont font;

        public EventHandler Started;
        public EventHandler Finished;

        bool isReleased = true;
        int idx = 0;
        private void advanceDialogue()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && isReleased){
                isReleased = false;
                idx += 1;
            }
            else if (!Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                isReleased = true;
            }
        }

        public void DebugTest()
        {
            if (_lines.Count == 0 || idx >= _lines.Count) return;
            var curLine = _lines[idx];
            Core.SpriteBatch.DrawString(font,curLine, GlobalPosition, Color.White);
        }

        public override void Draw(float deltaTime)
        {
            DebugTest();
            base.Draw(deltaTime);
        }

        public override void Update(float deltaTime)
        {
            advanceDialogue();
            base.Update(deltaTime);
        }

        public DialogueBox(List<string> lines): base()
        {
            this._lines = lines;
            this.font = Core.Content.Load<SpriteFont>("Arial");
        }

    }
}
