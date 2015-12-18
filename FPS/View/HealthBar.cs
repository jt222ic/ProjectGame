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
    class HealthBar
    {
        private Texture2D Health;
        private Texture2D HealthGuage;
        Vector2 position;
        Vector2 redposition;
        private int fullHealth;
        private int currentHealth;
        private Color colour;
        private int rateOfRegen = 11;
        Player playerCondition;
        Enemy enemy;
       

        public HealthBar(ContentManager Content, Player player, Enemy enemy)
        {
            position = new Vector2(30, 360);
            redposition = new Vector2(30, 360);
            Health = Content.Load<Texture2D>("YellowGuage.png");
            HealthGuage = Content.Load<Texture2D>("PlayerHealth.png");
            fullHealth = HealthGuage.Width;
            //currentHealth = fullHealth;
            this.enemy = enemy;
            playerCondition = player;
          

        }

        public void Update()
        {
            HealthColor();
            currentHealth = playerCondition.Health;
        }
        public void Healthpack()                
        {
            if (currentHealth < fullHealth)
            {
                currentHealth += rateOfRegen;
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {

            spritebatch.Begin();
            spritebatch.Draw(Health, position, Color.White);
            spritebatch.Draw(HealthGuage, redposition, new Rectangle((int)position.X, (int)position.Y, currentHealth *2, HealthGuage.Height), colour);
            spritebatch.End();
        }
        public void HealthColor()
        {
            if(currentHealth >= fullHealth * 0.75)
            {
                colour = Color.Red;
            }
            else if (currentHealth >= fullHealth * 0.25)
            {
                colour = Color.Yellow;
            }
            else
            {
                colour = Color.Red;
            }


        }
    }
}

