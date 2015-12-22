using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.View
{
    class WeaponBar
    {

        private Texture2D Health;
        private Texture2D HealthGuage;
        Vector2 position;
        Vector2 redposition;
        private int fullHealth;
        private float currentHealth;
        private float rateOfchange = 40;
        private int rateOfRegen = 11;
        public WeaponBar(ContentManager Content)
        {
            position = new Vector2(30,420);
            redposition = new Vector2(30, 420);
            Health = Content.Load<Texture2D>("Health.png");
            HealthGuage = Content.Load<Texture2D>("HealthGuage.png");
            fullHealth = HealthGuage.Width;
            currentHealth = fullHealth;

        }

        public void Update(float decrease)
        {
            if(currentHealth>=0)
            {
                currentHealth -= rateOfchange * decrease;
            }

        }
        public void UpdateReLoad()
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
            spritebatch.Draw(HealthGuage, redposition, new Rectangle((int)position.X,(int)position.Y,(int)currentHealth,HealthGuage.Height),Color.White);
            spritebatch.End();
        }
    }
}
