using FPS.Model;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaitonParticle
{
    class particleSystem
    {
        //public splitterParticle[] particles;
        List<splitterParticle> particleList = new List<splitterParticle>();
        private const int maxParticles = 50;
        Random test = new Random();
        BossSimulation Bosssimu;
        Texture2D spark;
        public particleSystem(ContentManager Content, BossSimulation Bosssimu) // skicka in i ny position
        {
            this.Bosssimu = Bosssimu;
            spark = Content.Load<Texture2D>("Electricity.png");
            //particles = new splitterParticle[maxParticles];

           
                for (int i = 0; i < maxParticles; i++)
                {
                    particleList.Add(new splitterParticle(spark, test, Bosssimu));  // ingen argument ännu en skickar 100 gånger
                }
        }

        public void Update(float totalSeconds)
        {
            if (this.Bosssimu.BossAttribute().regen1time == false)
            {
                    for (int i = 0; i < maxParticles; i++)
                    {
                        particleList[i].Update(totalSeconds);
                    }
                
            }
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.Bosssimu.BossAttribute().regen1time == false)
            {
                for (int i = 0; i < maxParticles; i++)
                {
                    particleList[i].Draw(spark, spriteBatch);
                }
            }
            
        }

    }
}
