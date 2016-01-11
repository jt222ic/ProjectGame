using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.View
{
    class BulletSystem
    {

        public  List<Bullet> particles = new List<Bullet>();
        private const int maxParticles = 0;
        Random test = new Random();
        public BulletSystem(Texture2D sprites) // skicka in i ny position
        {
            particles.Add(new Bullet(sprites, test));
        }
        public void Update(float totalSeconds)
        {
            foreach(Bullet bulletrain in particles)
            {
                bulletrain.Update(totalSeconds);
            }
        }
        public void Draw(Texture2D spark, Camera camera, SpriteBatch spriteBatch)
        {

            foreach(Bullet bulletrain in particles)
            {
                bulletrain.Draw(spark, camera, spriteBatch);
            }
        }
    }
}
