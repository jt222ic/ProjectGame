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
        int monsterCount = 4;
        public bool collectionOfDead;
        int onemonsterDead;

        public WhackAMole(Player player)
        {
            this.player = player;
        }
        public void TestSpawning()
        {
            if (spawn >= 1)
            {
                spawn = 0;

                if (enemyspawn.Count() < 4)
                {
                    enemyspawn.Add(new Enemy(player, rand));
                }
            }
        }
        public void DeadList()
        {

            Console.Write(onemonsterDead);
            foreach (Enemy enemy in enemyspawn)
            {
                for (int i = 0; i < enemyspawn.Count; i++)
                {
                    if (!enemyspawn[i].Deadyet)
                    {
                        onemonsterDead = 1;
                    }
                    if (onemonsterDead == 4)
                    {
                        Console.WriteLine("hej Monnika");
                    }
                    else if (monsterCount == 0)
                    {
                        allMonsterdead = true;
                    }
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
                enemies.Update(seconds);
                enemies.EnemyHurtsPlayer();
                RotationEnemy(enemies);
            }
        }

        public void RotationEnemy(Enemy enemies)
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
                        DeadList();
                    }

                }
            }
        }
    }
}

            
        
    

