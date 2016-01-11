using FPS.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.FontView
{
    class Font
    {
        SpriteFont text;
        Player player;
        BossSimulation boss;
        Ninja nin;
        public Font(Player player, ContentManager Content,BossSimulation boss, Ninja nin)
        {
            this.player = player;
            text = Content.Load<SpriteFont>("Font");
            this.boss = boss;
            this.nin = nin;
        }
        public void DrawFont(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(text,"Potion x :"+ this.player.Maxused.ToString(), new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(text, "Health :" + this.player.Health.ToString(), new Vector2(280, 340), Color.Red);
    
            spriteBatch.End();
        }
        public void DrawMiniBoss(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(text, "MiniBoss :"+this.nin.NinjaHP.ToString(), new Vector2(650, 10), Color.Blue);
            spriteBatch.End();
        }
        public void DrawLastBoss(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(text, "LastBoss :" + this.boss.BossAttribute().BossHealth.ToString(), new Vector2(650, 10), Color.LightCoral);
            spriteBatch.End();
        }

        public void MainScreenInstruction(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin();
            spriteBatch.DrawString(text, "Left Click -> to shot the gun".ToString(), new Vector2(0, 0), Color.Black);
            spriteBatch.DrawString(text, "Right Click -> wait for animation complete and blue bar to fill up to reload the gun".ToString(), new Vector2(0, 20), Color.Black);
            spriteBatch.DrawString(text, "Press R -> To Switch weapon(pistol,v.0.13shotgun, v0.01machinegun)".ToString(), new Vector2(0, 40), Color.Black);
            spriteBatch.DrawString(text, "Press E -> use the available potion that your character keep".ToString(), new Vector2(0, 60), Color.Black);
            spriteBatch.DrawString(text, "Move the mousecursor/crosshair -> to aim".ToString(), new Vector2(0, 80), Color.Black);
            spriteBatch.DrawString(text, "How to start the game? -> click on play button!".ToString(), new Vector2(0, 100), Color.Black);
            spriteBatch.DrawString(text, "Tips? -> to use shotgun - blue bar must be filled!".ToString(), new Vector2(0, 120), Color.Black);
            spriteBatch.End();
        }

        public void GameOverFont(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(text, "GAMEOVER ".ToString(), new Vector2(100, 100), Color.Black);
            if (this.player.GameOver())
            {
                spriteBatch.DrawString(text, "you Lost!".ToString(), new Vector2(100, 300), Color.Black);
            }
            if(this.boss.GameOver)
            {
                spriteBatch.DrawString(text, "you WIN!".ToString(), new Vector2(100, 200), Color.Black);
            }

            
           
        }
    }
}
