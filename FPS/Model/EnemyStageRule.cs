using FPS.View;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.Model
{
    class EnemyStageRule
    {
        bool stageClear = false;
        WhackAMole EnemySimulation;
        EnemyView enemyView;
        Background background;
        enum Stage
        {
            Stage1,
            Stage2,
            Stage3,
        }

        public EnemyStageRule(ContentManager Content, WhackAMole Enemysimulation, EnemyView enemyView, SpriteBatch spritebatch)
        {
            this.EnemySimulation = Enemysimulation;
            this.enemyView = enemyView;
          
            this.background = new Background(Content, spritebatch);
        }
        Stage currentgameState = Stage.Stage1;

        public void SendingArmies(float time)
        {
            switch(currentgameState)
            {
                case Stage.Stage1:
                    EnemySimulation.Update(time);
                    
                    if(stageClear == true)            // måste lägga till hur många monster är döda kanske skapa en bool function och returnera dead<= 0???
                    {
                        currentgameState = Stage.Stage2;
                    }
                    break;
                case Stage.Stage2:
                    
                    break;

                case Stage.Stage3:
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
                    break;

            }
        }
    }
}
