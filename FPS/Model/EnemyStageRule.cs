using FPS.FontView;
using FPS.SnakeView;
using FPS.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using RaitonParticle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.Model
{

    public enum Stage
    {
        Stage1,
        Stage2,
        Stage3,
    }
    class EnemyStageRule
    {
        
        WhackAMole EnemySimulation;
        BossSimulation bossSimulation;
        EnemyView enemyView;
        Background background;
        BossView bossenView;
        LevelController levelcontroller;
        Raiton Particle;
        particleSystem particlesystem;
        //Snake enemy1;
        Level level;
        //Texture2D enemyTexture;
        SerpentView serpentview;
        Serpent serpent;
        Ninja nin;
        Font newfont;
        public float time;
        public float Micro;
        //public enum Stage
        //{
        //    Stage1,
        //    Stage2,
        //    Stage3,
        //}

        public EnemyStageRule(ContentManager Content, WhackAMole Enemysimulation, EnemyView enemyView, SpriteBatch spritebatch, Camera camera, BossSimulation bosssimulation, Ninja ninja, Font font)
        {
            this.EnemySimulation = Enemysimulation;
            this.enemyView = enemyView;
            this.background = new Background(Content, spritebatch, camera);
            bossSimulation = bosssimulation;
            this.bossenView = new BossView(Content,spritebatch, camera, bossSimulation);
            level = new Level();
            levelcontroller = new LevelController(Content, level);
            Particle = new Raiton(Content, bossSimulation);
            particlesystem = new particleSystem(Content, bossSimulation);
            serpent = new Serpent();
            nin = ninja;
            serpentview = new SerpentView(Content, serpent,nin);
            newfont = font;
            //enemyTexture = Content.Load<Texture2D>("Ballz.png");
            //enemy1 = new Snake(enemyTexture,Vector2.Zero,0.9f);
        }
       public Stage currentgameState = Stage.Stage1;

        public void SendingArmies(float time, float microtime)
        {
            this.time = time;
            this.Micro = microtime;
            switch (currentgameState)
            {
                case Stage.Stage1:
                    EnemySimulation.Update(time);
                    enemyView.FadeAway(time);
                    if (EnemySimulation.reallyDead() == true)            // måste lägga till hur många monster är döda kanske skapa en bool function och returnera dead<= 0???
                    {
                        currentgameState = Stage.Stage2;
                    }
                    break;
                case Stage.Stage2:
                    serpent.Update(time);
                    serpent.Crazyness();
                    nin.NinjaTeleportation(time);
                    
                    if(nin.miniBossDeath)
                    {
                        currentgameState = Stage.Stage3;
                    }
                    //enemy1.Update();
                    //enemy1.SetWaypoints(level.Waypoints);
                    break;
                case Stage.Stage3:
                   this.bossSimulation.Update(time);
                    this.bossenView.Update(time);
                    Particle.Update(microtime);
                    particlesystem.Update(time);
                    break;
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            switch (currentgameState)
            {
                case Stage.Stage1:
                    background.DrawStage1();
                    enemyView.Draw();
                    newfont.DrawFont(spritebatch);
                    break;
                case Stage.Stage2:
                    background.DrawStage2();
                    serpentview.NinjaDraw(spritebatch);
                    serpentview.Draw(spritebatch);
                    newfont.DrawMiniBoss(spritebatch);
                    newfont.DrawFont(spritebatch);
                    break;

                case Stage.Stage3:
                   background.DrawStage3();
                    this.bossenView.Draw();
                    this.bossenView.DrawSphere();
                    this.Particle.Draw(spritebatch);
                    particlesystem.Draw(spritebatch);
                    newfont.DrawLastBoss(spritebatch);
                    newfont.DrawFont(spritebatch);
                    break;

            }
        }
    }
}
