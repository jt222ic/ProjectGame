using FPS.FontView;
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
        //Mostly for viewclass//
        GraphicsDeviceManager graphics;   // should have seperate the instance of the class // first solving the problem 
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
        ExplosionOnClick ClickExplosion;
        Transition trans;
        Font fontview;

        float damage = 1;
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
        //Song Berserk;
        //Song Castle;
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
        Ninja nin;

        //EnemyStageRule//

        EnemyStageRule StageSelection;
        PauseMenu buttonQuit, buttonResume, buttonMain;
        Texture2D pauseTexture;

        //Main Menu//
        MainMenu mainMenu;
        Viewport graphicss;
        // 

        BossSimulation bossSimu;
        
        enum GameState
        {
            MainMenu,
            PlayGame,
            PauseMenu,
            GameOver
           
        }
        GameState currentgameState = GameState.MainMenu;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //graphics.PreferredBackBufferHeight = 640 *32;
            //graphics.PreferredBackBufferWidth = 600 *32;
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
            players = new Player(enemies,Content);
            enemies = new Enemy(players, random);
            playerHealth = new HealthBar(Content, players, enemies);
            EnemySimulation = new WhackAMole(players);
            enemyView = new EnemyView(Content, spriteBatch, camera, EnemySimulation);
            //Berserk = Content.Load<Song>("gatsu");
            //Castle = Content.Load<Song>("castle");
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
            nin = new Ninja(players);
            bossSimu = new BossSimulation(players);
            mainMenu = new MainMenu(graphicss,Content);
           
            // Pause texture//
            pauseTexture = Content.Load<Texture2D>("pausebild.png");
            //pausedRectangle = new Rectangle(0, 0, pauseTexture.Width, pauseTexture.Height);
            //buttonPlay = new PauseMenu();
            //buttonPlay.Load(Content.Load<Texture2D>("ResumeButton"), new Vector2(400, 400));   // draw here  directly instead // new way of using sprite draw, and sendigng value
            buttonResume = new PauseMenu();
            buttonResume.Load(Content.Load<Texture2D>("Resume"), new Vector2(200, 200));
            buttonQuit = new PauseMenu();
            buttonQuit.Load(Content.Load<Texture2D>("Quit"), new Vector2(400, 200));
            buttonMain = new PauseMenu();
            buttonMain.Load(Content.Load<Texture2D>("MainMeny"), new Vector2(400, 400));


            // FONT //

            fontview = new Font(players, Content, bossSimu, nin);

            StageSelection = new EnemyStageRule(Content, EnemySimulation, enemyView, spriteBatch, camera, bossSimu, nin, fontview);

        }
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
                        mainMenu.isClicked = false;
                        buttonMain.isClicked = false;
                        buttonResume.isClicked = false;
                         // Måste göra till false annars skiftar det från pause till in -game på dirren!!! TYPISK ÄCKLIGA FEL
                        currentgameState = GameState.PlayGame;
                    }
                    break;
                case GameState.PlayGame:

                    IsMouseVisible = false;
                    if(players.GameOver() || bossSimu.GameOver)
                    {
                        currentgameState = GameState.GameOver;
                    }

                    Keyboardnow = Keyboard.GetState();

                    if(Keyboardnow.IsKeyDown(Keys.Enter)&& currentKeyboard.IsKeyUp(Keys.Enter))
                    {
                        currentgameState = GameState.PauseMenu;
                    }
                    playerHealth.Update();
                    mousestate = Mouse.GetState();
                    MousePosition = camera.getLogicalCord(mousestate.X, mousestate.Y);
                    if (Keyboardnow.IsKeyDown(Keys.E) && currentKeyboard.IsKeyUp(Keys.E))
                    {
                        players.Regenerate();
                    }

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

                            if(StageSelection.currentgameState == Stage.Stage3)
                            {
                                bossSimu.BallGetHit(MousePosition.X, MousePosition.Y, damage);
                            }
                            if(StageSelection.currentgameState == Stage.Stage2)
                            {
                                nin.getHit(MousePosition.X, MousePosition.Y, damage);
                            }
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
                            if (StageSelection.currentgameState == Stage.Stage3)
                            {
                                bossSimu.BallGetHit(MousePosition.X, MousePosition.Y, damage);
                            }
                            if (StageSelection.currentgameState == Stage.Stage2)
                            {
                                nin.getHit(MousePosition.X, MousePosition.Y, damage);
                            }
                            damage = 1;
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
                                if (StageSelection.currentgameState == Stage.Stage3)
                                {
                                    bossSimu.BallGetHit(MousePosition.X, MousePosition.Y, damage);
                                }
                                if (StageSelection.currentgameState == Stage.Stage2)
                                {
                                    nin.getHit(MousePosition.X, MousePosition.Y, damage);
                                }
                                frameControl = 0;
                    }
                    frameControl++;
                    damage = 6;
                }
            }

            StageSelection.SendingArmies((float)gameTime.ElapsedGameTime.TotalSeconds, (float)gameTime.ElapsedGameTime.TotalMilliseconds);
            currentKeyboard = Keyboardnow;
            prevMouse = mousestate;
            ClickExplosion.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            cross.Update(MousePosition);
            trans.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            trans.transition();
            break;
                case GameState.PauseMenu:
                    IsMouseVisible = true;
                     if (buttonQuit.isClicked && prevMouse.LeftButton == ButtonState.Released)
                    {
                        Exit();
                    }
                     if (buttonResume.isClicked && prevMouse.LeftButton == ButtonState.Released)
                    {
                        currentgameState = GameState.PlayGame;
                    }
                    else if (buttonMain.isClicked)
                    {
                        
                        ammo = 7;
                       
                        heal = new WeaponBar(Content);
                        players = new Player(enemies, Content);
                        enemies = new Enemy(players, random);
                        nin = new Ninja(players);
                        playerHealth = new HealthBar(Content, players, enemies);
                        bossSimu = new BossSimulation(players);
                        EnemySimulation = new WhackAMole(players);
                        enemyView = new EnemyView(Content, spriteBatch, camera, EnemySimulation);
                        StageSelection = new EnemyStageRule(Content, EnemySimulation, enemyView, spriteBatch, camera, bossSimu, nin, fontview);
                        fontview = new Font(players, Content, bossSimu, nin);
                        StageSelection.currentgameState = Stage.Stage1;
                        currentgameState = GameState.MainMenu;
                    }
                    buttonQuit.Update();
                    buttonResume.Update();
                    buttonMain.Update();
                    break;
                case GameState.GameOver:
                    IsMouseVisible = true;
                    if (buttonMain.isClicked == true)
                    {    // så den inte returnera Gameover igen om jag startar spelet 
                         // äckligaste lösning
                        //DEFAULT VALUE ALL //
                        ammo = 7;
                        heal = new WeaponBar(Content);
                        players = new Player(enemies, Content);
                        nin = new Ninja(players);
                        enemies = new Enemy(players, random);
                        playerHealth = new HealthBar(Content, players, enemies);
                        bossSimu = new BossSimulation(players);
                        EnemySimulation = new WhackAMole(players);
                        enemyView = new EnemyView(Content, spriteBatch, camera, EnemySimulation);
                        StageSelection = new EnemyStageRule(Content, EnemySimulation, enemyView, spriteBatch, camera, bossSimu, nin, fontview);
                        StageSelection.currentgameState = Stage.Stage1;
                        fontview = new Font(players, Content, bossSimu, nin);
                        currentgameState = GameState.MainMenu;
                    }
                    buttonMain.Update();
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
                    fontview.MainScreenInstruction(spriteBatch);
                    break;

                case GameState.PlayGame:

                   
                    StageSelection.Draw(spriteBatch);
                    

                    if (!players.swap)    
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

                case GameState.PauseMenu:
                    spriteBatch.Begin();
                    buttonResume.Draw(spriteBatch);
                    buttonMain.Draw(spriteBatch);
                   buttonQuit.Draw(spriteBatch);
                    spriteBatch.End();
                    break;

                case GameState.GameOver:
                    spriteBatch.Begin();
                    buttonMain.Draw(spriteBatch);
                    fontview.GameOverFont(spriteBatch);
                    spriteBatch.End();
                    break;
            }
            base.Draw(gameTime);
        }
    }
}

