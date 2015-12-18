﻿using FPS.View;
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
        private float waittime = 40;
        private float cooldown = 1;
        public bool Dead = false;
        public int shootdamage = 4;
        private int enemyHealth = 10;
        Player player;
        private Vector2 position = new Vector2(0.5f,100);
        private float Monstersize = 0.4f;
        private Vector2 enemymovement = new Vector2(0.5f, 0.5f);
        private Vector2 RandomPosition;
        Rectangle destiny = new Rectangle((int)10, (int)10, 60, 60);

        public Enemy(Player player, Random rand)
        {
            
            this.player = player;

           RandomPosition = new Vector2(position.X *40, (float)rand.NextDouble() );
            RandomPosition.Normalize();
            RandomPosition = RandomPosition * ((float)rand.NextDouble() + 200);
            enemymovement = RandomPosition;

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
        }

        public void Move(float time)
        {
            position += enemymovement * time;
            
        }
        public bool alive()
        {
            return Dead;
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
                return destiny;
            }
        }
    }

}
    


