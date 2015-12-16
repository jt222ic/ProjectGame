using FPS.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.View
{
    class EnemyView
    {
        Texture2D enemy;
        SpriteBatch spritebatch;
        Camera camera;
        Vector2 enemyPosition = new Vector2(200,200);

        public EnemyView(ContentManager Content,SpriteBatch spritebatch, Camera camera)
        {
            enemy = Content.Load<Texture2D>("kaka.png");
            this.spritebatch = spritebatch;
            this.camera = camera;

        }

        public void Draw()
        {
            this.spritebatch.Begin();
            this.spritebatch.Draw(enemy, enemyPosition, Color.White);
            this.spritebatch.End();
            
        }
    }
}
