using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.Model
{
    class BossSimulation
    {
        List<BossSphere> balls = new List<BossSphere>();
        BossSphere spinx;
        Boss Bossen;
        float spawn = 0;
        int ball = 6;
        //float spawn;
        public BossSimulation(Player player)
        {
            spinx = new BossSphere();
            Bossen = new Boss(spinx, player);
        }
        public void summon()
        {
           
                if (spawn >= 1)
                {
                    spawn = 0;

                    if (balls.Count() < 6)
                    {
                        balls.Add(new BossSphere());
                    }
                }
            
        }

        public void Update(float time)
        {
            
            Bossen.Update(time);
            float seconds = time;
            spawn += seconds;

            if (Bossen.SphereShield)
            {
                
                
                summon();

                foreach (BossSphere sphere in balls)
                {
                    sphere.Update(time);
                }
        }
    }
        public List<BossSphere> BallAttribute()
        {
            return balls;
        }
        public Boss BossAttribute()
        {
            return Bossen;
        }

        public void BallGetHit(float MouseposX, float MouseposY, float damage)
        {
            Vector2 MousePosition = new Vector2(MouseposX, MouseposY);
            Rectangle MouseRect = new Rectangle((int)MousePosition.X, (int)MousePosition.Y, 1, 1);

            Rectangle BossTexture = new Rectangle((int)Bossen.PositionBoss.X, (int)Bossen.PositionBoss.Y, (int)Bossen.PositionBoss.Width, (int)Bossen.PositionBoss.Height);
            if (MouseRect.Intersects(BossTexture))
                {
                Bossen.BossHealth -= (int)damage;

                Console.WriteLine("boss get hit {0}", Bossen.BossHealth);
            }
            if (ball == 0)
            {

                for (int i = balls.Count - 1; i >= 0; --i)
                {
                    if (balls[i].IsDead)
                    {
                        balls.RemoveAt(i);
                        Bossen.Sphereshield = false;
                        Bossen.BossHealth -= 5;   // have to hardcode or the if sats will be on 110 boss health
                    }
                }
               
            }
            foreach (BossSphere sphere in balls)
            {
                if (!sphere.IsDead)
                {
                    Rectangle SphereBalls = new Rectangle((int)sphere.Testphase.X, (int)sphere.Testphase.Y, sphere.WorkEverythi7ng.Width, sphere.WorkEverythi7ng.Height);
                    if (MouseRect.Intersects(SphereBalls))
                    {
                        Console.WriteLine("ball hit {0}", ball);
                        sphere.IsDead = true;
                        ball--;

                    }
                }
               
            }
        }
    }
}
