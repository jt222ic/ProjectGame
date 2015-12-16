using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.View
{
    class TheOneWhoControl
    {
        
        Texture2D Spark;
        

       
        
        private BulletSystem _splittersystem;
        Camera camera;
        SpriteBatch spriteBatch;
        


        public TheOneWhoControl(ContentManager Content, SpriteBatch spriteBatch, Camera camera)
        {

              // ska sätta in i draw // hade rätt ju
            
            Spark = Content.Load<Texture2D>("AssHole.png");


            //_splittersystem = new SplitterSystem(Spark, startposition);

            _splittersystem = new BulletSystem(Spark);
            this.spriteBatch = spriteBatch;
            this.camera = camera;

        }

       
        public void Updateeverything(float gameTime)
        {
            float timeElapsedSeconds = gameTime;
            
            _splittersystem.Update(timeElapsedSeconds);
        }

        public void DrawEverything()
        {
            
            this.spriteBatch.Begin();

            _splittersystem.Draw(Spark, this.camera, this.spriteBatch);
            this.spriteBatch.End();
        }
    }
}

