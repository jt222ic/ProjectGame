using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.Model
{
    class Serpent
    {
        public Vector2 position = new Vector2(0,200);
        public float legitSize =0.2f;
        float angle;
        public Vector2 enemyMovement = new Vector2(1000, 0);
        public Vector2 centerposition = new Vector2(200, 100);
        public List<Vector2> coord = new List<Vector2>();
        public Serpent()
        {

        }

        public void Crazyness()
        {

            if(position.X>1000 || position.X <0)
            {
                tresextio();
            }
        }
        public void tresextio()
        {
            enemyMovement = -enemyMovement;
        }
        public void Update(float time)
        {
            angle += time;
            position += enemyMovement * time;
            coord.Add((new Vector2((float)Math.Sin(angle), (float)Math.Cos(angle)*500))+ position);
        }
        public Vector2 rotation
        {                                               
            get
            {
                return new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)*100)+ position;  
            }
        }
        public List<Vector2> Curd
        {
            get
            {
                return coord;
            }
        }
        public Rectangle getAllRectangle
        {
            get
            {
                return new Rectangle((int)position.X,(int)position.Y,(int)legitSize,(int)legitSize);
            }
        }
    }
}
