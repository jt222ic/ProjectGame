using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.View
{
    class Background
    {
        Texture2D stage1;
        Texture2D stage2;
        SpriteBatch spritebatch;

        public Background(ContentManager Content, SpriteBatch spritebatch)
        {
            stage1 = Content.Load<Texture2D>("background.jpg");
            stage2 = Content.Load<Texture2D>("Eclipse.jpg");
            this.spritebatch = spritebatch;
        }

        public void DrawStage1()
        {
            this.spritebatch.Begin();
            this.spritebatch.Draw(stage1,new Vector2(0,0),Color.White);
            this.spritebatch.End();
        }

        public void DrawStage2()
        {
            this.spritebatch.Begin();
            this.spritebatch.Draw(stage2,new Vector2(0,0),Color.White);
            this.spritebatch.End();
        }

        public void DrawStage3()
        {

        }
    }
}
