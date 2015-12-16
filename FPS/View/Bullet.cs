using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.View
{
    class Bullet
    {
        Random rand = new Random();
        

        private Vector2 randomDirection;
        
        private Vector2 velocity;
        private Vector2 acceleration = new Vector2(0,-1);
        private Vector2 position = new Vector2(-1f,-0.5f);
        private float bulletspread = 0.8f;
        MouseState oldstate;
       

        
        Texture2D nowsprites;

        public Bullet(Texture2D newsprites, Random rand)
        {
            nowsprites = newsprites;

            position = new Vector2((float)rand.NextDouble() - bulletspread, (float)rand.NextDouble() - bulletspread);

            oldstate = Mouse.GetState();
        }

        public void Update(float elapsedTime)
        {

            
        }

        public void Draw(Texture2D spark, Camera camera, SpriteBatch spriteBatch)
        {
            Vector2 pose = new Vector2(oldstate.X, oldstate.Y);
            Vector2 vector = camera.GetVisualCoord(position.X, position.Y);
            Vector2 center = camera.CenterMousePosition(spark, spark.Width, pose);
            
            spriteBatch.Draw(spark, center, null, Color.White, 0f, center, 0.1f, SpriteEffects.None, 0); 
           
        }
    }
}
