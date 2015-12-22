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
        private float waittime = 80;
        private float cooldown = 1;
        public bool Dead = false;
        private int Deadcondition = 0;
        public int shootdamage = 4;
        public float enemyHealth = 4;
        Player player;
        private Vector2 position = new Vector2(0.5f,0.5f);
        private float Monstersize = 100;
        private Vector2 enemymovement = new Vector2(0.5f, 0.5f);
        private Vector2 RandomPosition;
        
        public Enemy(Player player, Random rand)
        {
            
            this.player = player;
           RandomPosition = new Vector2(position.X *40, (float)rand.NextDouble() );
            RandomPosition.Normalize();
            RandomPosition = RandomPosition * ((float)rand.NextDouble() + 200);
            enemymovement = RandomPosition;
           // destiny = new Rectangle((int)position.X, (int)position.Y, (int)Monstersize, (int)Monstersize);
        }

        public void EnemyHurtsPlayer()
        {
            if (enemyHealth <=0)
            {
                Dead = true;
                //Console.WriteLine("enemy dead");
            }
            else if (waittime > 0 && enemyHealth > Deadcondition)
            {
                waittime -= cooldown;
            }
            if (waittime == 0 && enemyHealth > Deadcondition)
            {
                player.Health -= shootdamage;
                waittime += 80;
            }
        }

        public void Move(float time)
        {
            position += enemymovement * time;
            
        }
        public bool alive
        {
            get{ return Dead; }
            set
            {
                Dead = value;
            }

        }
        public Vector2 Pose
        {
            get
            {
                return position;
            }
        }
        public float GetSize
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
        public Rectangle GetAllSize
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)Monstersize, (int)Monstersize);
            }
        }
    }

}
    


