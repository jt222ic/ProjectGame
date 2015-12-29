using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.View
{
    class Camera
    {
        private float scaleX;
        private float scaleY;
        private float scale;

        private int sizeOfftheField = 250;

        public void ScaleEverything(float Height, float Width)
        {
            scaleX = Height;
            scaleY = Width;


            if (scaleX<scaleY)
            {
                scale = scaleX;
            }
            else if (scaleX>scaleY)
            {
                scale = scaleY;
            }
        }

        public Vector2 GetVisualCoord(float LogicX, float LogicY)
        {
            float VisualX = LogicX * scaleX;
            float VisualY = LogicY * scaleY;

            return new Vector2(VisualX, VisualY);
        }

        public Vector2 getLogicalCord(float x, float y)
        {
            float screenX = x / scaleX;
            float screenY = y / scaleY;
            return new Vector2(x, y);
        }

        public Vector2 getCrossHairVisualcord(float x, float y)
        {
            float VisualX = x * scaleX;
            float VisualY = y * scaleY;

            return new Vector2(VisualX, VisualY);
        }

        public float ScaleObject(float size, float width)
        {
            return scale* size/width;
        }

        public float ScaleBall(float radius, float width)
        {
            return sizeOfftheField * 2 * radius / (float)width;
        }

        public Vector2 CenterMousePosition(Texture2D texture, float width, Vector2 Mouse)
        {

            return new Vector2(Mouse.X - texture.Width / 2 , Mouse.Y - texture.Width / 2 );
        }
    }
}
