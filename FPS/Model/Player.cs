using FPS.View;
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
        Enemy enemy;
        

        public Player(Enemy enemy)
        {
            this.enemy = enemy;
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

        public bool GameOver()
        {
            return Health <= ZeroHealth;
        }
        
    }
}

