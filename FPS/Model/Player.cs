using FPS.View;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.Model
{
    class Player
    {
        public int Health = 167;   // encapsulation ?? no .. purpose to be able to change manually on Unity.
        public int ZeroHealth = 0;
        public bool swap = false;
        public int drugs = 30;
        public int Maxused = 3;
        public   const int MaximumHealth = 167;
        Enemy enemy;
        SoundEffect DrinkitUp;
        public Player(Enemy enemy, ContentManager Content)
        {
            this.enemy = enemy;
            DrinkitUp = Content.Load<SoundEffect>("Drink");
        }
        public void SwapWeapon()
        {
            if (swap == false)
            {
                swap = true;
            }
            else if (swap == true)
            {
                swap = false;
           }
        }
        public void Regenerate()
        {
            if(Health < MaximumHealth && Maxused>0)
            {
                DrinkitUp.Play();
                Health = 167;
                Maxused--;
            }
        }

        public bool GameOver()
        {
            return Health <= ZeroHealth;
        }
        
    }
}

