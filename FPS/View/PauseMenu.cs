using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.View
{
    class PauseMenu         // the whole code  mostly contain of the youtube clip tutorial 
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;
        MouseState mouse;

        Color color = new Color(255, 255, 255, 255);

        bool down;
        public bool isClicked;

        public PauseMenu()
        {

        }

        public void Load(Texture2D newTexture, Vector2 newPosition)
        {
            position = newPosition;
            texture = newTexture;
        }

        public void Update()
        {

            mouse = Mouse.GetState();
            rectangle = new Rectangle((int)position.X, (int)position.Y, 50, 50);           // size and position of the mouse
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1 );   // rectangle of the mouse 

            if (mouseRectangle.Intersects(rectangle))  // code from Youtube 
            {
                if (color.A == 255)
                {
                    down = false;
                }
                if (color.A == 0)
                {
                    down = true;
                }
                if (down)
                {
                    color.A += 3;
                }
                else color.A -= 3;

                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    
                    isClicked = true;
                }
            }
            else if (color.A < 255)
            {

                color.A += 3;
                isClicked = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, color);
        }

    }
}
