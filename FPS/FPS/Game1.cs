using FPS.Model;
using FPS.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace FPS
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MouseState prevMouse;
        MouseState mousestate;
        Camera camera;
        CrossHair cross;
        Vector2 MousePosition;
        Texture2D Aim;
        Texture2D ReLoad;
        ShootAnimation animation;
        ReLoadAnimation reload;
        EnemyView enemyView;
        TheOneWhoControl BoomEffect;
        int damage = 1;
        ExplosionOnClick ClickExplosion;
        Transition trans;
        int maxammo = 7;
        int  ammo = 7;
        int clip = 0;
        float reloadclip = 2f;
        int frameControl = 0;
        //sound//
        SoundEffect GunSound;
        SoundEffect reloadSound;
        SoundEffect DryGun;
        SoundEffectInstance soundEffect;
        Enemy enemies;
        Player players;
        HealthBar playerHealth;
        Random random = new Random();
        WhackAMole EnemySimulation;
        
        Texture2D pauseTexture;
        Rectangle pauserectangle;

        //Health//

        WeaponBar heal;
        


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
           // graphics.PreferredBackBufferHeight = 640;
            //graphics.PreferredBackBufferWidth = 600;
            //graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
           
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera();
            cross = new CrossHair(Content, spriteBatch, camera);
            camera.ScaleEverything(graphics.PreferredBackBufferHeight, graphics.PreferredBackBufferWidth);
            Aim = Content.Load<Texture2D>("BetterDoom.png");
            animation = new ShootAnimation(Aim);
           
            
            BoomEffect = new TheOneWhoControl(Content, spriteBatch, camera);
            ClickExplosion = new ExplosionOnClick(Content, spriteBatch, camera);
            ReLoad = Content.Load<Texture2D>("Badass.png");
            reload = new ReLoadAnimation(ReLoad);
            trans = new Transition(animation, reload);
            
            players = new Player(enemies);
            enemies = new Enemy(players, random);
            playerHealth = new HealthBar(Content, players, enemies);
            EnemySimulation = new WhackAMole(players);
            enemyView = new EnemyView(Content, spriteBatch, camera, EnemySimulation);
            //song = Content.Load<Song>("neyo");

            //MediaPlayer.Play(song);


            pauseTexture = Content.Load<Texture2D>("background.jpeg");
            pauserectangle = new Rectangle(0, 0, pauseTexture.Width, pauseTexture.Height);

            //sound//
            reloadSound = Content.Load<SoundEffect>("reloading");
            GunSound = Content.Load<SoundEffect>("firesound");
            soundEffect = reloadSound.CreateInstance();
            DryGun = Content.Load<SoundEffect>("DryGun");

            heal = new WeaponBar(Content);




            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            EnemySimulation.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            // enemies.EnemyHurtsPlayer();
            playerHealth.Update();

            // Console.WriteLine(players.Health);
            //Console.WriteLine("{0}", mousestate.LeftButton);
            mousestate = Mouse.GetState();

            if (mousestate.LeftButton == ButtonState.Pressed && ammo >= clip && prevMouse.LeftButton == ButtonState.Released)
            {
                animation.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                heal.Update();
                
                GunSound.Play();

                EnemySimulation.setEnemyDead(MousePosition.X, MousePosition.Y, cross.CrossHairsize/2);

                damage += 1;
                ammo -= 1;
                frameControl = 0;
                
                ClickExplosion.CreateExplosion();
                reload.fade = 1;
                animation.fade = 0;
            }
            

            else if (prevMouse.LeftButton == ButtonState.Released && prevMouse.LeftButton == ButtonState.Released)
            {
                animation.timeElapsed = 0;
                animation.frame = 0;

            }
            prevMouse = mousestate;

            if (mousestate.LeftButton == ButtonState.Pressed && ammo <= clip  && prevMouse.LeftButton == ButtonState.Released)
            {
                DryGun.Play();
            }
            if (mousestate.RightButton == ButtonState.Pressed && ammo<=maxammo)
            {
               
                soundEffect.Play();
                soundEffect.IsLooped = false;
                heal.UpdateReLoad();
                if (frameControl >= 29)
                {
                    
                    ammo += (int)reloadclip;
                    reload.fade = 0;
                    animation.fade = 1;

                }
                else if (frameControl < 30)
                { 
                    frameControl++;
                }
            }

           
           
            MousePosition = camera.getLogicalCord(mousestate.X, mousestate.Y);
            ClickExplosion.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            cross.Update(MousePosition);
            trans.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            trans.transition();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            
            enemyView.Draw();
            cross.Draw();
            animation.Draw(spriteBatch, camera);
            ClickExplosion.Draw();
            trans.Draw(spriteBatch,camera);
            heal.Draw(spriteBatch);

            playerHealth.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}

