using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Text;

namespace FPS.Model
{
    class Level
    {

        private List<Texture2D> tileTextures = new List<Texture2D>();
        private Queue<Vector2> waypoints = new Queue<Vector2>();

        public Level()
        {                                         //http://msdn.microsoft.com/en-us/library/7977ey2c.aspx //
         
            waypoints.Enqueue(new Vector2(2, 0) * 32);
            waypoints.Enqueue(new Vector2(2, 1) * 32);
            waypoints.Enqueue(new Vector2(3, 1) * 32);
            waypoints.Enqueue(new Vector2(3, 2) * 32);
            waypoints.Enqueue(new Vector2(4, 2) * 32);
            waypoints.Enqueue(new Vector2(4, 4) * 32);
            waypoints.Enqueue(new Vector2(3, 4) * 32);
            waypoints.Enqueue(new Vector2(3, 5) * 32);
            waypoints.Enqueue(new Vector2(2, 5) * 32);
            waypoints.Enqueue(new Vector2(2, 7) * 32);
            waypoints.Enqueue(new Vector2(7, 7) * 32);
        }
        int[,] map = new int[,]
        {

    {0,0,1,0,0,0,0,0,},     // med siffror 1 ska banan se ut men ska implementera problemet senare. 
    {0,0,1,1,0,0,0,0,},
    {0,0,0,1,1,0,0,0,},
    {0,0,0,0,1,0,0,0,},
    {0,0,0,1,1,0,0,0,},
    {0,0,1,1,0,0,0,0,},
    {0,0,1,0,0,0,0,0,},
    {0,0,1,1,1,1,1,1,},

        };
        public Queue<Vector2> Waypoints
        {
            get { return waypoints; }
        }
        public void AddTexture(Texture2D texture)     // eftersom vi inte passerar med ContentMAnager, addar in det är bättre.
        {
            tileTextures.Add(texture);
        }
        public int Width                              // returnerar Höjden och bredden 
        {
            get { return map.GetLength(1); }
        }
        public int Height
        {
            get { return map.GetLength(0); }
        }
        public void Draw(SpriteBatch spriteBatch)                         
        {
            for( int x = 0; x<Width; x++)
            {
                for( int y = 0; y<Height; y++)
                {
                    int textureIndex = map[y, x];
                    if (textureIndex == -1)             // om värdet är 1 eller 0 lagrar det in på tileTexture arrayen eller List //
                        continue;
                    spriteBatch.Begin();
                    Texture2D texture = tileTextures[textureIndex];
                    spriteBatch.Draw(texture, new Rectangle(
                        x * 32, y * 32, 32, 32), Color.White);
                    spriteBatch.End();                          // transformera texturer till skärmen med tillämpning av Graphics.
                }

            }
        }
    }
}
