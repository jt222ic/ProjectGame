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
      
        int MaxenemySpawn = 10;
        Player player;
        Timer timer;
        
        Random rand = new Random();

        public WhackAMole(Player player)
        {
            this.player = player;
            
            for (int i = 0; i< MaxenemySpawn; i++)
            {
                enemyspawn.Add(new Enemy(player, rand));

                timer = new Timer(rand.Next(500, 2000));
               
                timer.Start();
            }

           

        }

        public List<Enemy> GetPosition()
            {
            return enemyspawn;                    // re-using this code to master the return statement;
            }

        public void Update()
        {
            foreach(Enemy enemies in enemyspawn)
            {
                enemies.EnemyHurtsPlayer();
            }
        }
        


    }
}
