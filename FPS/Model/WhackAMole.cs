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

        //int MaxenemySpawn = 10;
        Player player;
        float spawn = 0;
        
        Random rand = new Random();

        public WhackAMole(Player player)
        {
            this.player = player;

            //for (int i = 0; i < MaxenemySpawn; i++)
            //{
            //    enemyspawn.Add(new Enemy(player, rand));
            //}

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
            //for (int i = 0; i < MaxenemySpawn; i++)
            //{
            //    enemyspawn.Add(new Enemy(player, rand));
            //}
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
        public void setEnemyDead(float coordX, float coordY, float crosshairSize)
        {
            // tar in crosshairen senare//
            // lade in crosshair storleken för att täcka fungerar fortfarande inte//
            foreach (Enemy enemies in enemyspawn)
            {
                Vector2 MonsterlogicMouse = new Vector2(coordX, coordY);

                bool containCoord = enemies.GetAllSize.Contains(MonsterlogicMouse.X , MonsterlogicMouse.Y);
                Console.Write(containCoord);

                if (containCoord)
                    {
                        Console.Write("it got hit");
                        enemies.Dead = true;
                    }
                }
            


            }
        }
    }

