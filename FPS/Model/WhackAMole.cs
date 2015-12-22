using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace FPS.Model
{
    class WhackAMole
    {

        private List<Enemy> enemyspawn = new List<Enemy>();
        Player player;
        float spawn = 0;
        Random rand = new Random();

        public WhackAMole(Player player)
        {
            this.player = player;
        }
        public void TestSpawning()
        {
            if (spawn >= 2)
            {
                spawn = 0;

                if (enemyspawn.Count() <= 4)
                {
                    enemyspawn.Add(new Enemy(player, rand));
                }
            }
        }

        public List<Enemy> GetPosition()
        {
            return enemyspawn;
        }

        public void Update(float time)
        {

            float seconds = time;
            spawn += seconds;
            TestSpawning();

            foreach (Enemy enemies in enemyspawn)
            {
                enemies.Move(seconds);
                enemies.EnemyHurtsPlayer();
            }
        }
        public void setEnemyDead(float coordX, float coordY, float damage)
        {
            foreach (Enemy enemies in enemyspawn)
            {
               Vector2 MonsterlogicMouse = new Vector2(coordX, coordY);

               bool containCoord = enemies.GetAllSize.Contains(MonsterlogicMouse.X , MonsterlogicMouse.Y);
                //Rectangle penetrate = new Rectangle((int)MonsterlogicMouse.X,(int) MonsterlogicMouse.Y, 1, 1);
                //Console.Write(containCoord);
                //if (enemies.GetAllSize.Intersects(penetrate))
                if (containCoord)
                    {
                    enemies.enemyHealth -= damage;
                    Console.WriteLine("{0}", enemies.enemyHealth);
                    }
               
            }
            


            }
        }
    }

