using FPS.View;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.Model
{
    class EnemyStageRule
    {
        
        WhackAMole EnemySimulation;
        BossSimulation bossSimulation;
        EnemyView enemyView;
        Background background;
        BossView bossenView;

        enum Stage
        {
            Stage1,
            Stage2,
            Stage3,
        }

        public EnemyStageRule(ContentManager Content, WhackAMole Enemysimulation, EnemyView enemyView, SpriteBatch spritebatch, Camera camera, BossSimulation bosssimulation)
        {
            this.EnemySimulation = Enemysimulation;
            this.enemyView = enemyView;
            this.background = new Background(Content, spritebatch, camera);
            bossSimulation = bosssimulation;
            this.bossenView = new BossView(Content,spritebatch, camera, bossSimulation);
           
        }
        Stage currentgameState = Stage.Stage3;

        public void SendingArmies(float time)
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
                    background.DrawStage2();
                    break;

                case Stage.Stage3:
                   background.DrawStage3();
                    this.bossenView.Draw();
                    this.bossenView.DrawSphere();
                    
                    break;

            }
        }
    }
}
