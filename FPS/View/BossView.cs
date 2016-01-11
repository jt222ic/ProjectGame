using FPS.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.View
{
    class BossView
    {
        Texture2D FinalBoss;
        Texture2D CrystalBall;
        SpriteBatch spritebatch;
        Color color = Color.LightSkyBlue;
        BossSimulation Simu;
        Color colorClone1 = Color.LightGreen;
        Color colorClone2 = Color.IndianRed;
        public BossView(ContentManager Content, SpriteBatch spritebatch, Camera camera, BossSimulation simu)
        {
            FinalBoss = Content.Load<Texture2D>("boss.gif");
            CrystalBall = Content.Load<Texture2D>("Crystal_Ball.png");
            this.Simu = simu;
            this.spritebatch = spritebatch;
        }
        public void Update(float time)
        {
             color.A -= 3;
        }
        public void Draw()
        {
            Rectangle BossPosition = new Rectangle((int)Simu.BossAttribute().PositionBoss.X, (int)Simu.BossAttribute().PositionBoss.Y, (int)Simu.BossAttribute().PositionBoss.Width, Simu.BossAttribute().PositionBoss.Height);
            this.spritebatch.Begin();
            this.spritebatch.Draw(FinalBoss, BossPosition, Color.White);
            
            if (Simu.BossAttribute().SphereShield)
            {
                this.spritebatch.Draw(FinalBoss, BossPosition, color);
            }
            else if(Simu.BossAttribute().BossCloneNoJutsu)
            {

                Vector2 walking = new Vector2((int)Simu.BossAttribute().ClonePosition.X,(int) Simu.BossAttribute().ClonePosition.Y);
                Vector2 walking2 = new Vector2((int)Simu.BossAttribute().ClonePosition2.X, (int)Simu.BossAttribute().ClonePosition2.Y);
                this.spritebatch.Draw(FinalBoss, walking, colorClone1);
                this.spritebatch.Draw(FinalBoss, walking2, colorClone2);
            }
            this.spritebatch.End();
        }

        public void DrawSphere()
        {
            foreach (BossSphere sphere in Simu.BallAttribute())
            {
                //Vector2 SpherePose = new Vector2(sphere.Rotate.X , sphere.Rotate.Y);
                //Vector2 Rotate = new Vector2(sphere.IHope.X, sphere.IHope.Y);
                //Vector2 Work = new Vector2(sphere.WorkGodammit.X, sphere.WorkGodammit.Y);
                //Rectangle Destination = new Rectangle((int)sphere.WorkGodammit.X,(int) sphere.WorkGodammit.Y, sphere.WorkEverythi7ng.Height, sphere.WorkEverythi7ng.Width);
                //spritebatch.Draw(CrystalBall, Destination, Color.White);
                //spritebatch.Draw(CrystalBall, new Vector2(20,20),null, Color.White, 0, new Vector2(FinalBoss.Width/2, FinalBoss.Height/2),0,SpriteEffects.None,0);
                /* spritebatch.Draw(CrystalBall, Work, null, Color.White, 0, new Vector2(-930, -600), 0.4f, SpriteEffects.None, 1);*/ // fullösning om jag hade gjort visuellt skulle jag inte hitta problemet

                Rectangle Hope = new Rectangle((int)sphere.Testphase.X, (int)sphere.Testphase.Y, sphere.WorkEverythi7ng.Height, sphere.WorkEverythi7ng.Width);
                spritebatch.Begin();                                                                                                                             // spritebatch.Draw(CrystalBall, Destination, Color.White);
                spritebatch.Draw(CrystalBall, Hope, Color.White);

                //spritebatch.Draw(CrystalBall, Destination, Color.White);  funkar!

                if (sphere.IsDead)
                {
                    spritebatch.Draw(CrystalBall, Hope, Color.Red);
                }                                                        // fick fixa start punkt från modellen¨å origin

                spritebatch.End();
        }
    }
    }
}
