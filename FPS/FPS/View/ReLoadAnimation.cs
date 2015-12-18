using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.View
{
    class ReLoadAnimation
    {

        int NumbersOfFrame = 12;
        float maxTime = 1f;
        public float timeElapsed;
        int frameX;
        float frameY;
        int numberFrameX = 3;
        int numberFrameY = 4;
        private Texture2D Shoot;
        public int frame;
        Vector2 scale = new Vector2(20f, 50f);
        public float fade =1;


        public ReLoadAnimation(Texture2D Reloading)
        {


            Shoot = Reloading;
            frameX = Shoot.Width / numberFrameX;                
            frameY = Shoot.Height / numberFrameY;
        }

        public bool REALOADING()
        {
            return true;
        }
        public bool Shooting()
        {
            return true;
        }

        public void Draw(SpriteBatch spritebatch, Camera camera)
        {
            Color transition = new Color(fade, fade, fade, fade);
            spritebatch.Begin();
            frameX = frame % numberFrameX;   //teachc0de
            frameY = frame / numberFrameX;
            Rectangle test = new Rectangle(frameX * 128, (int)frameY * 128, Shoot.Width / numberFrameX, Shoot.Height / numberFrameY);
            //Vector2 scale = camera.ScaleObject(TrueFlame.Width / numberFrameX, TrueFlame.Height / numberFrameY);// skalar TExture2d width and height dela med numbersof frames
            spritebatch.Draw(Shoot, new Vector2(704, 340), test, transition);
            spritebatch.End();

        }

        public bool Reload()
        {
            return true;
        }

        public void Update(float Elapsedtime)
        {


            timeElapsed += Elapsedtime;
            float percentAnimated = timeElapsed / maxTime;
            frame = (int)(percentAnimated * NumbersOfFrame);

            if (timeElapsed > maxTime)
            {
                if (frame > 3)
                {
                    frame = 0;
                }
                else
                {
                    frame++;
                }

                timeElapsed = 0;                          // restart timer after the animation time-out
            }                                           // väljer bildrutorna i PNG // CHOSING THE PICTURE BOX OUT OF PNG FILE

        }
    }
}

