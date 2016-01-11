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
        public bool allMonsterdead;
        int monsterCount = 10;
        int tick;
        float spawnDelay = 0.5f;
        float elapsedSeconds;
    

        public WhackAMole(Player player)
        {
            this.player = player;
        }
        public void TestSpawning()
        {
          
            if (spawn >= 1)
            {
                tick++;
                spawn = 0;
                if (tick <= monsterCount)
                {
                    enemyspawn.Add(new Enemy(player, rand));
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
            elapsedSeconds += time;

            if (elapsedSeconds > spawnDelay)
            {
                TestSpawning();
                elapsedSeconds = 0;
            }

            for (int i = enemyspawn.Count - 1; i >= 0; --i)
            {
                if(enemyspawn[i].Dead)
                {
                    enemyspawn.RemoveAt(i);
                    if(EnemiesDead())
                    {
                        allMonsterdead = true;
                    }
                }
            }
            foreach (Enemy enemies in enemyspawn)
            {
                enemies.Update(seconds);
                enemies.EnemyHurtsPlayer();
                RotationEnemy(enemies);
            }
        }

        public bool EnemiesDead()
        {
            if(enemyspawn.Count <= 0)
            {
                return true;
            }
            return false;
        }

        public void RotationEnemy(Enemy enemies)
        {
            if (!enemies.Deadyet)
            {
                if (enemies.Pose.Y <= 0 || enemies.Pose.Y >= 300)
                {
                    enemies.rotationspeedY();
                }
                if (enemies.Pose.X <= 0 || enemies.Pose.X >= 600)
                {
                    enemies.rotationspeedX();
                }
            }
        }
        public void setEnemyDead(float coordX, float coordY, float damage)
        {
            foreach (Enemy enemies in enemyspawn)
            {
                if (!enemies.Deadyet)
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
}

            
        
    

