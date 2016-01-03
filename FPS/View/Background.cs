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
        Texture2D stage3;
        SpriteBatch spritebatch;
        Viewport view;
        Camera camera;
        public Background(ContentManager Content, SpriteBatch spritebatch, Camera camera)
        {
            stage1 = Content.Load<Texture2D>("background.jpg");
            stage2 = Content.Load<Texture2D>("Eclipse.jpg");
            stage3 = Content.Load<Texture2D>("Castlevania.jpg");
            this.camera = camera;
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
            //float scale = camera.getGameArea(stage3.Height, stage3.Width);
            this.spritebatch.Begin();
            //this.spritebatch.Draw(stage3,new Vector2(0,0), null, Color.White, 0,Vector2.Zero,scale,SpriteEffects.None,0);
            //float scale = camera.ScaleObject(stage3.Height,stage3.Width);
            //this.spritebatch.Draw(stage3,new Vector2(0,0), null, Color.White,0,new Vector2(0,0),scale, SpriteEffects.None,0);
            Rectangle rectangle = new Rectangle(0, 0, 800, 500);
            this.spritebatch.Draw(stage3, rectangle, Color.White);
            this.spritebatch.End();
        }
    }
}
