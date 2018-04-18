using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;

namespace project_game_ver0._3
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        List<enemy> enemies = new List<enemy>();

        Random random = new Random();
        SpriteBatch spriteBatch;
        SpriteFont font;
        Song song;
        Vector2 posplayer;
        Vector2 posball;
        Vector2 speedball;
        
        Vector2 posmonster = new Vector2(800, 400);
       

        Vector2 offset = new Vector2(0, 60);
        Vector2 bgpos = new Vector2(0, 0);
        Vector2 cameraPos = Vector2.Zero;
        Vector2 scroll_factor = new Vector2(1.0f, 1);


        bool keyActiveUp = false;
        bool keyActiveDown = false;

        KeyboardState old_ks;
        int direction = 1;
        int score = 0;
        Texture2D manu;
        Texture2D UII01;

        int manu01 = 0;


        int counts = 0;

        //Texture2D bg;
        Texture2D lazer;

        Texture2D itemingame;
        //item.item item2;

        int gravity = 20;

        int currentMenu = 1;

        Texture2D ball;

        projectgame.AnimatedTexture player;

        Item item;
        Hp hp;
        player playerX;
        coin coins;
        
        lazer lazer0;
        background bg;


        public Game1()
        {
            item = new Item(1, 0.5f);
            hp = new Hp(0.5f, 1);
            //lazer0 = new lazer(1);
           
            playerX = new player(this, "Char01");
            coins = new coin(this,new Vector2(0,0));
            graphics = new GraphicsDeviceManager(this);
            player = new projectgame.AnimatedTexture(Vector2.Zero, 0, 1.0f, 0.5f);
            Content.RootDirectory = "Content";
            
            //itemingame = item.item2;
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
            posplayer = new Vector2(0, 0);
            posball = new Vector2(0, 0);
            speedball = new Vector2(5, 5);

            cameraPos = new Vector2(3, 0);
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            manu = Content.Load<Texture2D>("TDK");
            UII01 = Content.Load<Texture2D>("UI01");
            // Create a new SpriteBatch, which can be used to draw textures.
            font = Content.Load<SpriteFont>("font");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.Load(Content, "player", 12, 3, 20);
            //bg = Content.Load<Texture2D>("bg4");
            ball = Content.Load<Texture2D>("ball");

            this.song = Content.Load<Song>("sound");
            //lazer0.Load(Content);
            item.Load(Content);
            hp.Load(Content);
            
            playerX.Load(Content, "player");
            coins.Load(Content, "coin");
            MediaPlayer.Play(song);
            MediaPlayer.Volume = 0.1f;
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        /// 


        void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {  
            // 0.0f is silent, 1.0f is full volume  

            MediaPlayer.Volume = 0.5f;
            MediaPlayer.Play(song);
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
        float spawn = 0;

        internal List<enemy> Enemies { get => enemies; set => enemies = value; }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //ProcessInput();
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //LoadEnemies();
            spawn += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (enemy enemy in enemies)
                enemy.Update(graphics.GraphicsDevice);

            Rectangle playercol = new Rectangle((int)posplayer.X, (int)posplayer.Y, 85, 125);
            KeyboardState keyboard = Keyboard.GetState();

            playerX.move(1, 0.1f);
            item.colitem(playercol);
            if (manu01 == 0)
            {
                if (keyboard.IsKeyDown(Keys.Up))
                {
                    if (keyActiveUp == true)
                    {
                        if (currentMenu > 1)
                        {
                            currentMenu = currentMenu - 1;
                            keyActiveUp = false;
                        }
                    }
                }
                if (keyboard.IsKeyDown(Keys.Down))
                {
                    if (keyActiveDown == true)
                    {
                        if (currentMenu < 4)
                        {
                            currentMenu = currentMenu + 1;
                            keyActiveDown = false;
                        }
                    }
                }
                if (keyboard.IsKeyUp(Keys.Up))
                {
                    keyActiveUp = true;
                }
                if (keyboard.IsKeyUp(Keys.Down))
                {
                    keyActiveDown = true;
                }                if (keyboard.IsKeyDown(Keys.Enter) && currentMenu == 1)
                {
                    manu01 = 1;
                }                if (keyboard.IsKeyDown(Keys.Enter) && currentMenu == 2)
                {
                    manu01 = 2;
                }                if (keyboard.IsKeyDown(Keys.Enter) && currentMenu == 3)
                {
                    manu01 = 3;
                }                if (keyboard.IsKeyDown(Keys.Enter) && currentMenu == 4)
                {
                    Exit();
                }
            }

            if (manu01 == 1)
            {
                playerX.Update(elapsed);
                player.UpdateFrame(elapsed);
            }

            


            item.Update(elapsed);
            hp.Update(elapsed);
          
            //playerX.Update(elapsed);

            

            base.Update(gameTime);
        }

       
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if (manu01 == 0)
            {
                spriteBatch.Draw(manu, new Vector2(0, 0), Color.White);

                if (currentMenu == 1)
                {
                    spriteBatch.Draw(UII01, new Vector2(300, 50), new Rectangle(0, 0, 130, 100), Color.White);
                }
                else
                {
                    spriteBatch.Draw(UII01, new Vector2(300, 50), new Rectangle(130, 0, 130, 100), Color.White);
                }
                if (currentMenu == 2)
                {
                    spriteBatch.Draw(UII01, new Vector2(300, 150), new Rectangle(0, 100, 130, 100), Color.White);
                }
                else
                {
                    spriteBatch.Draw(UII01, new Vector2(300, 150), new Rectangle(130, 100, 130, 100), Color.White);
                }
                if (currentMenu == 3)
                {
                    spriteBatch.Draw(UII01, new Vector2(300, 250), new Rectangle(0, 200, 130, 100), Color.White);
                }
                else
                {
                    spriteBatch.Draw(UII01, new Vector2(300, 250), new Rectangle(130, 200, 130, 100), Color.White);
                }
                if (currentMenu == 4)
                {
                    spriteBatch.Draw(UII01, new Vector2(300, 350), new Rectangle(0, 300, 130, 100), Color.White);
                }
                else
                {
                    spriteBatch.Draw(UII01, new Vector2(300, 350), new Rectangle(130, 300, 130, 100), Color.White);
                }
            }

           
            
















            if (manu01 == 1)
            {
                playerX.Draw(spriteBatch);
            }
               
           

            
            
            
            
           


            spriteBatch.End();
            base.Draw(gameTime);

        }
        
        
        


    }

}
