using FPS.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RaitonParticle
{
    class splitterParticle
    {
        
            // fält//
            Random rand = new Random();
            private Vector2 velocity;
            private Vector2 acceleration = new Vector2(0f, 0f);
            private Vector2 position = new Vector2(350f, 220f);
            public Texture2D nowsprites;
            public Vector2 randomDirection;// = new Vector2(0.4f,0.4f);
        BossSimulation BossSimu;
            public splitterParticle(Texture2D newsprites, Random rand, BossSimulation bossSimu)
            {
            BossSimu = bossSimu;
            
                nowsprites = newsprites;
                randomDirection = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
                randomDirection.Normalize();
                randomDirection = randomDirection * ((float)rand.NextDouble() + 40);
                velocity = randomDirection * 4;
            }// ska tillägga max speed senare
            
            public void Update(float elapsedTime)
            {
                velocity = velocity + acceleration * elapsedTime;
                position = position + velocity * elapsedTime;

            }

            public void Draw(Texture2D spark, SpriteBatch spriteBatch)
            {
            spriteBatch.Begin();
            spriteBatch.Draw(spark, position, null, Color.White, 0f, Vector2.Zero, 0.2f, SpriteEffects.None, 0); 
            spriteBatch.End();
         
        }
        }
}
