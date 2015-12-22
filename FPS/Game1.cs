﻿using FPS.Model;
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
        //Mostly for viewclass//
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
        float damage = 1;
        ExplosionOnClick ClickExplosion;
        Transition trans;
        // Controller check ammo//  maybe put on Player Class, which i made them to public global variable or get set return statement function
        int maxammo = 7;
        float  ammo = 7;
        int clip = 0;
        float reloadclip = 2f;
        int frameControl = 0;
        int ticktock;
        bool secretweapon = false;
        float decrease;
        //sound//
        SoundEffect GunSound;
        SoundEffect reloadSound;
        SoundEffect DryGun;
        SoundEffectInstance soundEffect;
        SoundEffectInstance ShotgunEffect;
        Song Berserk;
        Song Castle;
        SoundEffect ShotLoud;
        SoundEffect MachineLoud;
       //Model//
        Enemy enemies;
        Player players;
        Random random = new Random();
        WhackAMole EnemySimulation;
        //keyboard//
        KeyboardState Keyboardnow;
        KeyboardState currentKeyboard;
       
        //Health -Weapon regen//
        WeaponBar heal;
        HealthBar playerHealth;
        //animation work
        Texture2D Shotgun;
        ShotgunShootAnimation ShotgunAnimation;
        Texture2D Machinegun;
        MachinegunAnimation machinegunAnimation;
        // playonce//  Maybe to player class;
        bool playonce = false;


        //Main Menu//

        MainMenu mainMenu;
        Viewport graphicss;
        bool pause;
        enum GameState
        {
            MainMenu,
            PlayGame
           
        }
        GameState currentgameState = GameState.MainMenu;

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
            graphicss = new Viewport();
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera();
            cross = new CrossHair(Content, spriteBatch, camera);
            camera.ScaleEverything(graphics.PreferredBackBufferHeight, graphics.PreferredBackBufferWidth);
            Aim = Content.Load<Texture2D>("BetterDoom.png");
            animation = new ShootAnimation(Aim);
            Shotgun = Content.Load<Texture2D>("onehand.png");
            ShotgunAnimation = new ShotgunShootAnimation(Shotgun);
            Machinegun = Content.Load < Texture2D>("twohand.png");
            machinegunAnimation = new MachinegunAnimation(Machinegun);
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
            Berserk = Content.Load<Song>("gatsu");
            Castle = Content.Load<Song>("castle");
            //sound//
            ShotLoud = Content.Load<SoundEffect>("oldschool");
            reloadSound = Content.Load<SoundEffect>("reloading");
            GunSound = Content.Load<SoundEffect>("firesound");
            soundEffect = reloadSound.CreateInstance();
            ShotgunEffect = ShotLoud.CreateInstance();
            DryGun = Content.Load<SoundEffect>("DryGun");
            MachineLoud = Content.Load<SoundEffect>("Mp5");
            heal = new WeaponBar(Content);


            //MediaPlayer.Play(Berserk);

            mainMenu = new MainMenu(graphicss,Content);

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

            

            switch (currentgameState)
            {
                case GameState.MainMenu:
                     mainMenu.Update();
                    if (mainMenu.isClicked == true)
                    {
                        currentgameState = GameState.PlayGame;
                    }
                    break;


                case GameState.PlayGame:

                      Keyboardnow = Keyboard.GetState();
                    if(Keyboardnow.IsKeyDown(Keys.Enter)&& currentKeyboard.IsKeyUp(Keys.Enter))
                    {
                        Console.Write("Suppose to pause or return to Main screen");
                        pause = true;
                        currentgameState = GameState.MainMenu;
                    }


                    playerHealth.Update();
                    mousestate = Mouse.GetState();
                    MousePosition = camera.getLogicalCord(mousestate.X, mousestate.Y);

                    if (Keyboardnow.IsKeyDown(Keys.R) && currentKeyboard.IsKeyUp(Keys.R))
            {
                if (ticktock != 14)
                {

                    players.SwapWeapon();
                }
                else
                {
                    secretweapon = true;
                    ticktock = 1;
                }

                ticktock++;
                Console.WriteLine(ticktock);
            }

            if (!players.swap)
            {
                if (mousestate.LeftButton == ButtonState.Pressed && ammo >= clip && prevMouse.LeftButton == ButtonState.Released)
                {
                    decrease = 1;
                    heal.Update(decrease);
                    GunSound.Play();
                    damage = 1;
                    animation.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                    frameControl = 0;
                    ammo -= 1;
                    ClickExplosion.CreateExplosion();
                    EnemySimulation.setEnemyDead(MousePosition.X, MousePosition.Y, damage);
                    reload.fade = 1;
                    animation.fade = 0;
                }
                else if (prevMouse.LeftButton == ButtonState.Released && prevMouse.LeftButton == ButtonState.Released)
                {
                    animation.timeElapsed = 0;
                    animation.frame = 0;
                }
                if (mousestate.LeftButton == ButtonState.Pressed && ammo <= clip && prevMouse.LeftButton == ButtonState.Released)
                {
                    DryGun.Play();
                }
                if (mousestate.RightButton == ButtonState.Pressed && ammo <= maxammo)
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
            }
            else if (secretweapon)
            {

                if (mousestate.LeftButton == ButtonState.Pressed && ammo >= clip)
                {

                    if (!playonce)
                    {
                        MachineLoud.Play();
                        playonce = true;
                    }
                    if (frameControl >= 40)
                    {
                        playonce = false;
                        frameControl = 0;
                    }
                    maxammo = 32;
                    decrease = 0.09f;
                    heal.Update(decrease);
                    Console.WriteLine(ammo);
                    ammo -= 0.35f;
                    frameControl++;
                    machinegunAnimation.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                    EnemySimulation.setEnemyDead(MousePosition.X, MousePosition.Y, damage);
                    damage = 0.1f;
                }
                if (mousestate.RightButton == ButtonState.Pressed && ammo <= maxammo)
                {

                    soundEffect.Play();
                    soundEffect.IsLooped = false;
                    heal.UpdateReLoad();

                    ammo += 0.5f;
                    
                }
            }
            else
            {
                if (mousestate.LeftButton == ButtonState.Pressed && ammo >= clip)
                {

                    ShotgunAnimation.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
                    if (frameControl >= 74)
                    {
                        ShotLoud.Play();
                        EnemySimulation.setEnemyDead(MousePosition.X, MousePosition.Y, damage);
                        frameControl = 0;
                    }
                    frameControl++;
                    damage = 4;
                }
            }

            EnemySimulation.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            currentKeyboard = Keyboardnow;
            prevMouse = mousestate;
            ClickExplosion.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            cross.Update(MousePosition);
            trans.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            trans.transition();
            break;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (currentgameState)
            {
                case GameState.MainMenu:
                    mainMenu.Draw(spriteBatch);
                    break;

                case GameState.PlayGame:
                    enemyView.Draw();

                    if (!players.swap)     // could send it to Player Controller
                    {
                        cross.Draw();
                        animation.Draw(spriteBatch, camera);
                        ClickExplosion.Draw();
                        trans.Draw(spriteBatch, camera);
                        heal.Draw(spriteBatch);
                        playerHealth.Draw(spriteBatch);
                    }
                    else if (secretweapon)
                    {
                        cross.Draw();
                        heal.Draw(spriteBatch);
                        machinegunAnimation.Draw(spriteBatch, camera);
                        playerHealth.Draw(spriteBatch);
                    }
                    else
                    {
                        cross.Draw();
                        heal.Draw(spriteBatch);
                        playerHealth.Draw(spriteBatch);
                        ShotgunAnimation.Draw(spriteBatch, camera);
                    }
                    break;
            }

            base.Draw(gameTime);
        }
    }
}

