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
        float spawncount = 4;
        Random rand = new Random();
        public bool allMonsterdead;
        int monsterCount = 4;

        public WhackAMole(Player player)
        {
            this.player = player;
        }
        public void TestSpawning()
        {
            if (spawn >= 2)
            {
                spawn = 0;

                if (enemyspawn.Count() < 4)
                {
                    enemyspawn.Add(new Enemy(player, rand));
                    spawncount--;
                }
                DeadList();
            }

        }
        public void DeadList()
        {
            foreach (Enemy enemy in enemyspawn)
            {
                    if (!enemy.Deadyet && enemyspawn.Count >=0)
                    {                  
                        allMonsterdead = false;
                        monsterCount--;
                    }
                    else if(monsterCount <=0)   // more precise for other weapon, if not it doesnt work for other weapon loadout
                    {
                        allMonsterdead = true;
                    }
            }
            
        }

        public bool reallyDead()
        {
            return allMonsterdead;
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
                    bool containCoord = enemies.GetAllSize.Contains(MonsterlogicMouse.X, MonsterlogicMouse.Y);

                    if (containCoord)
                    {
                        enemies.enemyHealth -= damage;
                    }
                }
            }

            }
        }
    

