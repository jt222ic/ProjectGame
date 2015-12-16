using FPS.View;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.Model
{
    class Transition
    {
        ShootAnimation trans;
        private List<ReLoadAnimation> jan = new List<ReLoadAnimation>();
        
        MouseState mouse;
        MouseState oldmouse;
       


    public Transition(ShootAnimation animation, ReLoadAnimation reloading)
        {
           
            trans = animation;
            //for (int i = 0; i < turn; i++)
            //{
            //    jan.Add(reloading);
            //}
            ReLoadAnimation banan = reloading;
            NowImReloading(banan);
        }
        public void transition()
        {
            oldmouse = mouse;
            mouse = Mouse.GetState();
            foreach (ReLoadAnimation reload in jan)
            {

                if (mouse.RightButton == ButtonState.Pressed )
                {
                    trans.fade = 0;
                    reload.fade = 1;
                    
                }
                else
                {
                    reload.fade = 0;
                    trans.fade = 1;
                }
            }
        }

        public void NowImReloading(ReLoadAnimation banan)
        {

            jan.Add(banan);
        }
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach (ReLoadAnimation completeanimation in jan)
            {
                completeanimation.Draw(spriteBatch, camera);
            }
        }

        public void Update(float elapsedTime)
        {

            foreach (ReLoadAnimation completeanimation in jan)
            {
                completeanimation.Update((float)elapsedTime);
            }
        }


    }
   


}
        
    


