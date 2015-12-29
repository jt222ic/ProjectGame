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
    class EnemyView
    {
        Texture2D enemy;
        Texture2D enemyattack;
        Texture2D enemyDead;
        SpriteBatch spritebatch;
        Camera camera;
        WhackAMole Enemycontent;
        Color color;
        public float fade = 1;
        
        
        //Texture2D background;

        public EnemyView(ContentManager Content,SpriteBatch spritebatch, Camera camera, WhackAMole EnemyContent)
        {
            //background = Content.Load<Texture2D>("background.jpg");
            enemy = Content.Load<Texture2D>("kaka.png");
            enemyattack = Content.Load<Texture2D>("rawr.gif");
            enemyDead = Content.Load<Texture2D>("DeadBall.gif");
            this.spritebatch = spritebatch;
            this.camera = camera;
            Enemycontent = EnemyContent;
            
        }
        public void FadeAway(float time)
        {
            //foreach (Enemy enemies in Enemycontent.GetPosition())
            //{
            //        if (enemies.Dead)
            //        {
            //        fade -= time * 0.3f;
            //       }
                
            //}
        }
     
        public void Draw()
        {
            this.spritebatch.Begin();
            //this.spritebatch.Draw(background, new Vector2(0, 0), Color.White);
          
            foreach (Enemy enemies in Enemycontent.GetPosition())
            {
                color = new Color(fade, fade, fade, fade);
                Vector2 enemyPosition = new Vector2(enemies.Pose.X - enemies.GetSize, enemies.Pose.Y - enemies.GetSize);
                Vector2 enemyCenter = new Vector2(enemy.Width / 2, enemy.Height / 2);
                Rectangle Destination = new Rectangle((int)enemies.Pose.X, (int)enemies.Pose.Y, enemies.GetAllSize.Height, enemies.GetAllSize.Width);

                float scale = camera.ScaleObject(enemies.GetSize, enemy.Width);
                //this.spritebatch.Draw(enemy, enemyPosition, null, Color.White, 0, enemyCenter, scale, SpriteEffects.None, 0);
                if (enemies.AttackAnimation())
                {
                    this.spritebatch.Draw(enemyattack, Destination, Color.White);
                }
                else if(enemies.Dead)
                {
                    this.spritebatch.Draw(enemyDead, Destination, color);
                }
                else
                {
                    this.spritebatch.Draw(enemy, Destination, Color.White);
                }
            }
            this.spritebatch.End();

        }
    }
}
