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
        public bool Dead;
        private int Deadcondition = 0;
        public int shootdamage = 4;
        public float enemyHealth = 4;
        Player player;
        private Vector2 position= new Vector2(2, 0.5f);
        private float Monstersize = 100;
        private Vector2 enemymovement = new Vector2(0.5f, 0.5f);
        private Vector2 RandomPosition;
        private bool MonsterPerformAttack;
        public bool isVisible = false;

        public Enemy(Player player, Random rand)
        {
            this.player = player;
            RandomPosition = new Vector2(position.X + 400, (float)rand.NextDouble() *200);
            RandomPosition.Normalize();
            RandomPosition = RandomPosition * ((float)rand.NextDouble() + 200);
            enemymovement = RandomPosition;
        }

        public void EnemyHurtsPlayer()
        {
            if (enemyHealth == Deadcondition)
            {
                Dead = true;
                enemymovement *= 0;
                MonsterPerformAttack = false;
            }
            else if (waittime > 0 && enemyHealth > Deadcondition)
            {
                waittime -= cooldown;
            }
            if (waittime == 0 && enemyHealth > Deadcondition)
            {
                MonsterPerformAttack = true;
                player.Health -= shootdamage;
                waittime += 80;
            }
            else if (waittime == 40)
            {
                MonsterPerformAttack = false;
            }
        }

        public void Update(float time)
        {
            
            position += enemymovement * time;
        }
        public Vector2 rotation
        {
            get
                {
                return new Vector2(enemymovement.X, enemymovement.Y);
               }
        }
        public void rotationspeedX()
        {
            enemymovement.X = -enemymovement.X;
        }
        public void rotationspeedY()
        {
            enemymovement.Y = -enemymovement.Y;
        }
        public bool Deadyet
        {
            get { return Dead;}
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
        public bool AttackAnimation()
        {
            return MonsterPerformAttack;
        }
    }

}

    


