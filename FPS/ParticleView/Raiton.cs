using FPS.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaitonParticle
{
    class Raiton
    {
        float elapsed;
        float delay = 140f;
        int frames = 0;
        BossSimulation boss;
        Texture2D Thundah;
        int frameControl;
        
        public Raiton(ContentManager Content, BossSimulation BossSimu)
        {

            Thundah = Content.Load<Texture2D>("Raiton.png");
            boss = BossSimu;
        }
        public void Update(float time)
        {

      
            if (boss.BossAttribute().BossAttack)
            {

                elapsed += time;

                if (elapsed >= delay)
                {
                    if (frames > 5)
                    {
                        frames = 0;
                    }
                    else
                    {
                        frames++;
                    }
                    elapsed = 0;
                }
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
          
            spritebatch.Begin();
            Rectangle Origin = new Rectangle(300, -50, 128, 625);
            Rectangle DoingTheAnimation = new Rectangle(145 * frames, 0, 128, 280);

            if (boss.BossAttribute().BossAttack)
            {
                    spritebatch.Draw(Thundah, Origin, DoingTheAnimation, Color.White);
           
            }
            if(boss.BossAttribute().BossAttack && boss.BossAttribute().BossCloneNoJutsu)
            {

                spritebatch.Draw(Thundah, new Rectangle(50,-50,128,625), DoingTheAnimation, Color.White);
                spritebatch.Draw(Thundah, new Rectangle(500, -50, 128, 625), DoingTheAnimation, Color.White);
            }
         
         
            spritebatch.End();

        }

    }
}
