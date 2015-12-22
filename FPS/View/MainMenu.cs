using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.View
{
    class MainMenu
    {

        Texture2D MainScreen;
        Texture2D ButtonPlay;
        Rectangle rectangle;
        MouseState press;
        public bool isClicked = false;
        Vector2 size;
        Vector2 position = new Vector2(0f,0f);
        public MainMenu(Viewport graphics,ContentManager Content)
        {
            
            MainScreen = Content.Load<Texture2D>("MainMenu.jpg");
            ButtonPlay = Content.Load<Texture2D>("play.png");
             size = new Vector2(350,300);
        }

        public void Update()
        {
           
            press = Mouse.GetState();
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X,(int)size.Y);
           

            if (rectangle.Contains(press.X,press.Y))
            {
                if (press.LeftButton == ButtonState.Pressed)
                {
                    isClicked = true;
                }
                
            }
           
        }

        public void Draw(SpriteBatch spritebatch)
        {
          
            spritebatch.Begin();
            spritebatch.Draw(MainScreen, new Vector2(0, 0), Color.White);
            spritebatch.Draw(ButtonPlay, rectangle, Color.White);
            spritebatch.End();

        }
    }
}
