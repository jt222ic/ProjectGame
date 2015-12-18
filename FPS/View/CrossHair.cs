using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.View
{
    class CrossHair
    {

        private float crosshairSize = 0.1f;
        private Camera camera;
        Vector2 spritePosition;
        Texture2D CrossAim;
        SpriteBatch spritebatch;
        
        

        public void Update(Vector2 MousePosition)
        {
            spritePosition= new Vector2(MousePosition.X, MousePosition.Y);
          
        }
        public CrossHair(ContentManager Content, SpriteBatch spritebatch, Camera camera)
        {
            CrossAim = Content.Load<Texture2D>("Jcross.png");
            this.camera = camera;
            this.spritebatch = spritebatch;
        }

        public void Draw()
        {

            float scale = camera.ScaleObject(crosshairSize, CrossAim.Width);
            this.spritebatch.Begin();
            this.spritebatch.Draw(CrossAim, camera.CenterMousePosition(CrossAim, CrossAim.Width/2, spritePosition), Color.White);
            this.spritebatch.End();
        }

        public float CrossHairsize
        {
            get{
                return crosshairSize;
            }
        }
    }
}
