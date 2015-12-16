using FPS.View;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.Model
{
    class Enemy
    {

        public float currentHealth = 7000;

        public float EnemyRadius = 0.5f;
        private float waittime = 40;
        private float cooldown = 1;
        public bool Dead = false;
        public int shootdamage = 4;
        private int enemyHealth = 10;
        Player player;
        private Vector2 position;
        private Vector2 Monstersize;


        public Enemy(Player player, Random rand)
        {
            
            this.player = player;

        }

        public void EnemyHurtsPlayer()
        {
            if (enemyHealth == 0)
            {
                
            }
            else if (waittime > 0 && enemyHealth > 0)
            {
                waittime -= cooldown;

            }
            if (waittime == 0 && enemyHealth > 0)
            {

                player.Health -= shootdamage;
                waittime += 40;
            }
            if (player.Health == 0)
            {
               
            }
        }

        public bool alive()
        {

            return Dead;
        }

        public void inflictDamage(float Damage, Vector2 MousePosition, float cross)
        {

            if (position.X + EnemyRadius >= MousePosition.X - cross &&
                position.X - EnemyRadius <= MousePosition.X + cross &&
                position.Y + EnemyRadius <= MousePosition.Y - cross &&
                position.Y - EnemyRadius >= MousePosition.Y + cross)
            {

            }
            if (enemyHealth <= 0)
            {
                Console.WriteLine("enemy Slain!");
            }
        }
        public Vector2 GetPosition
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        public Vector2 GetSize
        {
            get
            {
                return Monstersize;
            }
            set
            {
                Monstersize = value;
            }
        }
    }

}
    


