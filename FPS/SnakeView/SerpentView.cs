using FPS.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.SnakeView
{
    class SerpentView
    {
        Texture2D Snake;
        Texture2D Body;
        List<Texture2D> Tails = new List<Texture2D>();
        Serpent serpent;
        SpriteBatch sprit;
        Texture2D Ninja;
        Ninja classNinja;
        public SerpentView(ContentManager Content, Serpent theclass, Ninja ninja)
        {
            Snake = Content.Load<Texture2D>("shadow.png");
            Body = Content.Load<Texture2D>("Pururu.png");
            Ninja = Content.Load<Texture2D>("Ninja.gif");
            serpent = theclass;
            classNinja = ninja;
        }
        public void NinjaDraw(SpriteBatch spriteBatch)
        {
            Vector2 newPosition = new Vector2(classNinja.returnNewPosition.X, classNinja.returnNewPosition.Y);
            Rectangle newPositions = new Rectangle(classNinja.returnEverything.X, classNinja.returnEverything.Y,classNinja.returnEverything.Width,classNinja.returnEverything.Height);
            spriteBatch.Begin();
            spriteBatch.Draw(Ninja, newPositions, Color.White);
            spriteBatch.End();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
           
            Vector2 movement = new Vector2(serpent.rotation.X, serpent.rotation.Y);
            Vector2 movement2 = new Vector2(serpent.rotation.X - 20, serpent.rotation.Y);
            Vector2 bodymove = new Vector2(serpent.position.X, serpent.position.Y);
            spriteBatch.Begin();
            //spriteBatch.Draw(Snake, movement, Color.White);
            for (int i = 0; i < serpent.coord.Count(); i++)
            {
                spriteBatch.Draw(Snake, serpent.coord[i],Color.White);
            }
            spriteBatch.End();
        }
    }
}
