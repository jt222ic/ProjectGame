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
            levelcontroller = new LevelController(Content);
            Particle = new Raiton(Content, bossSimulation);
            particlesystem = new particleSystem(Content, bossSimulation);
        }
       public Stage currentgameState = Stage.Stage1;

        public void SendingArmies(float time, float microtime)
        {
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
