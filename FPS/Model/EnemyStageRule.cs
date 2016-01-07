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
        Snake enemy1;
        Level level;
        Texture2D enemyTexture;
        public float time;
        public float Micro;
        //public enum Stage
        //{
        //    Stage1,
        //    Stage2,
        //    Stage3,
        //}

        public EnemyStageRule(ContentManager Content, WhackAMole Enemysimulation, EnemyView enemyView, SpriteBatch spritebatch, Camera camera, BossSimulation bosssimulation, GraphicsDeviceManager graphics)
        {
            this.EnemySimulation = Enemysimulation;
            this.enemyView = enemyView;
            this.background = new Background(Content, spritebatch, camera);
            bossSimulation = bosssimulation;
            this.bossenView = new BossView(Content,spritebatch, camera, bossSimulation);
            level = new Level();
            levelcontroller = new LevelController(Content,level);
            Particle = new Raiton(Content, bossSimulation);
            particlesystem = new particleSystem(Content, bossSimulation);
            enemyTexture = Content.Load<Texture2D>("enemy.gif");
            enemy1 = new Snake(enemyTexture,Vector2.Zero,0.9f);
        }
       public Stage currentgameState = Stage.Stage3;

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
                    enemy1.Update();
                    enemy1.SetWaypoints(level.Waypoints);

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
                    break;
                case Stage.Stage2:
                    //background.DrawStage2();
                    levelcontroller.Draw(spritebatch);
                    enemy1.Draw(spritebatch);
                    break;

                case Stage.Stage3:
                   background.DrawStage3();
                    this.bossenView.Draw();
                    this.bossenView.DrawSphere();
                    this.Particle.Draw(spritebatch);
                    particlesystem.Draw(spritebatch);
                  break;

            }
        }
    }
}
