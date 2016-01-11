using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.Model
{
    class Boss
    {
        public int BossHealth = 160;
        public int CurrentBossHealth = 200;
        public int BossGainShield = 1;
        public int Deadcondition = 0;
        public int waittime = 400;
        public int cooldown = 1;
        public int MegaBlaster = 20;
        public bool regen1time = true;
        public Vector2 BossPosition = new Vector2(280,200);
        public float BossSize = 255;
        public int Monstersize = 2;
       public bool Sphereshield = false;
        private bool BossImmune = false;
        public bool BossAttack;
        public bool BossDead;
        private bool BossPerformClone;
        BossSphere SphereBall;
        Player player;
        Vector2 clonePosition = new Vector2(280,200);
        Vector2 clonePosition2 = new Vector2(280, 200);
        Vector2 CloneMoving;
        Vector2 CloneMoving2;
        //int percentDamage = 0.2f;

        float CloneCoolDown = 100;

        public Boss(BossSphere sphereball, Player player)
        {
            this.player = player;
            SphereBall = sphereball;

            CloneMoving = new Vector2(clonePosition.X *-1, 0f);
            CloneMoving2 = new Vector2(clonePosition2.X *+1, 0f);
          

        }
        public void BossShield()
        {
            Sphereshield = true;
            if (!SphereBall.IsDead)
            {

                BossHealth += BossGainShield;
            }
        }
        public void BossClone()
        {
            BossPerformClone = true;
            if (BossHealth > 120 && BossHealth <140 || BossHealth <=50)
            {
                BossPerformClone = true;
                CloneCoolDown -= cooldown;
                if (CloneCoolDown == 0)
                {
                    player.Health -= 1;
                    CloneCoolDown = 100;
                }
                if (clonePosition.X <= 0 || clonePosition.X >= 600)
                {
                    clonePosition.X *= 0;
                }

                if (ClonePosition2.X <= 0 || ClonePosition2.X >= 550)
                {
                    clonePosition2 = new Vector2(550, 200);
                }
            }
            else
            {
                BossPerformClone = false;
            }
        }
        public void BossCurrentHealth()
        {
            if( BossHealth<=110 && BossHealth >= 100)
            {
                Differentspells(1);
            }
            else if(BossHealth <140 || BossHealth > 120)
            {
                Differentspells(2);
            }
             if( BossHealth <=50)
            {
                Differentspells(2);
            }
              if(BossHealth <20)
            {
                Differentspells(3);
                Differentspells(2);
                Differentspells(1);
            }
        }
        public void Differentspells(int spells)
        {
           int spellsCondition = spells;
             switch(spellsCondition)
            {
                case 0:
                    break;
                case 1:
                    BossShield();
                    break;
                case 2:
                    BossClone();
                    break;
                case 3:
                    BossRestoration();
                    break;
            }
        }
        public void BossRestoration()
        {
           
            if (regen1time)
            {
                BossHealth += 100;
                player.Health -= (player.Health) * 4/10;
                regen1time = false;
            }
        }
        public bool BossCloneNoJutsu
        {
            get
            {
                return BossPerformClone;
            }
        }
        public void BossPerformAttack()
        {
            if (BossHealth == Deadcondition)
            {
                BossDead = true;
                BossAttack = false;
            }
            else if (waittime > 0 && BossHealth > Deadcondition)
            {
                waittime -= cooldown;
            }
            if (waittime == 0 && BossHealth > Deadcondition)
            {
                BossAttack = true;
                player.Health -= MegaBlaster;
                waittime += 400;
            }
            else if (waittime == 200)
            {
                BossAttack = false;
            }
        }
        public void Update(float time)
        {if(BossPerformClone)
            {
                clonePosition += CloneMoving * time;
                clonePosition2 += CloneMoving2 * time;
            }
           
            BossCurrentHealth();
            BossPerformAttack();

        }
        public bool SphereShield
        {
            get
            {
                return Sphereshield;
            }
        }
        public bool BossImmuneShield
        {
            get
            {
                return BossImmune;
            }
        }
        public Rectangle PositionBoss
        {
            get
            {
                return new Rectangle((int)BossPosition.X, (int)BossPosition.Y, (int)BossSize, (int)BossSize);
            }
        }
        public Vector2 ClonePosition
        {
            get
            {
                return new Vector2((int)clonePosition.X, (int)clonePosition.Y);
            }
        }
        public Vector2 ClonePosition2
        {
            get
            {
                return new Vector2((int)clonePosition2.X, (int)clonePosition2.Y);
            }
        }
    }

}

