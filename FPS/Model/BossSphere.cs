using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.Model
{
    class BossSphere
    {
        public float spheresize = 25;
        Vector2 position = new Vector2(130, 300);
        Vector2 enemymoving = new Vector2(20f, 20f);
        Vector2 distancfe = new Vector2(400, 100);
        Vector2 centerPosition = new Vector2(375, 240);
        float angle;
        bool Dead;
        Boss boss;

        public BossSphere()
        {

        }

        public void Update(float time)
        {
            angle += time;
            position += enemymoving * time;
        }
        public Vector2 Rotate
        {
            get
            {
                return new Vector2(position.X, position.Y);
            }
        }

        public Vector2 WorkGodammit
        {
            get
            {
                return new Vector2((float)Math.Cos(angle + 200) * 400, (float)Math.Sin(angle + 250) * 100);  // original dont remove
            }

        }
        public Vector2 Testphase
        {
            get
            {
                return new Vector2(distancfe.X * (float)Math.Cos(angle + 200), distancfe.Y * (float)Math.Sin(angle + 250)) + centerPosition;
            }
        }
        public Rectangle WorkEverythi7ng
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)spheresize, (int)spheresize);
            }
        }

        public Rectangle GetAllSize
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)spheresize, (int)spheresize);
            }
        }
        public bool IsDead
        {
            get
            {
                return Dead;
            }
            set
            {
                Dead = value;
            }
        }
    }
}
