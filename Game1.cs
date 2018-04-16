using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace project_game_ver0._3
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;
        SpriteFont font;

        Vector2 posplayer;
        Vector2 posball;
        Vector2 speedball;
        Vector2 poslazer;
        Vector2 posmonster = new Vector2(800, 400);
        Vector2 itempos;
        Vector2 old_posmon;

        Vector2 offset = new Vector2(0, 60);
        Vector2 bgpos = new Vector2(0, 0);
        Vector2 cameraPos = Vector2.Zero;
        Vector2 scroll_factor = new Vector2(1.0f, 1);



        KeyboardState old_ks;
        int direction = 1;
        int score = 0;

        bool jumpplayer = false;
        bool shoot;
        bool shootpos = false;
        bool hit = false;
        bool positemcheck;
        bool death;
        bool dropitem = false;
        bool checkcol;
        bool b;


        bool count = false;
        int counts = 0;

        //Texture2D bg;
        Texture2D lazer;

        Texture2D itemingame;
        //item.item item2;

        int gravity = 20;



        Texture2D ball;

        projectgame.AnimatedTexture player;

        Item item;
        Hp hp;
        player playerX;
        spawnmonster monster;
        lazer lazer0;
        background bg;


        public Game1()
        {
            item = new Item(1, 0.5f);
            hp = new Hp(0.5f, 1);
            //lazer0 = new lazer(1);
            monster = new spawnmonster(1);
            playerX = new player(this, "Char01");
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

            // Create a new SpriteBatch, which can be used to draw textures.
            font = Content.Load<SpriteFont>("font");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.Load(Content, "player", 12, 3, 20);
            //bg = Content.Load<Texture2D>("bg4");
            ball = Content.Load<Texture2D>("ball");
            

            //lazer0.Load(Content);
            item.Load(Content);
            hp.Load(Content);
            monster.Load(Content);
            playerX.Load(Content, "player");
            

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
            //ProcessInput();
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            

            Rectangle playercol = new Rectangle((int)posplayer.X, (int)posplayer.Y, 85, 125);

            Rectangle lazercol = new Rectangle((int)poslazer.X, (int)poslazer.Y, 30, 30);

            Rectangle moncol = new Rectangle((int)posmonster.X, (int)posmonster.Y, 80, 80);
            playerX.move(1, 0.1f);
            item.colitem(playercol);

            if (count == true)
            {
                counts++;
                if (counts > 120)
                {
                    counts = 0;
                    posmonster.X = 800;
                    hit = false;
                    count = false;
                    checkcol = false;

                }
                if (counts < 120)
                {
                    posmonster.X = -100;
                }


            }

            if (playercol.Intersects(moncol) == true)
            {

                hp.DecreaseHp(playercol.Intersects(moncol));


            }

            if (lazercol.Intersects(moncol) == true && checkcol == false)
            {


                count = true;
                old_posmon = posmonster;
                hits();



            }





            /* else if (lazercol.Intersects(moncol) == false)
             {
                 hit = false;
             }*/

            //posmonster.X -= 3;

            if (posmonster.X < -100)
            {
                posmonster.X = 800;
            }

            if (jumpplayer == false)
            {
                posplayer.Y += gravity;
            }
            if (posplayer.Y > 320)
            {
                posplayer.Y = 320;

            }
            if (jumpplayer == true)
            {
                gravity--;
            }

            posball.Y += speedball.Y;
            posball.X += speedball.X;
            if (posball.Y > 400)
            {

                speedball.Y = -speedball.Y;
            }
            if (posball.X > 720)
            {
                speedball.X = -speedball.X;
            }
            if (posball.Y < 0)
            {
                speedball.Y = speedball.Y * -1;
            }
            if (posball.X < 0)
            {
                speedball.X = speedball.X * -1;
            }

            
            playerX.Update(elapsed);
            player.UpdateFrame(elapsed);
            item.Update(elapsed);
            hp.Update(elapsed);
            monster.Update(elapsed);
            //playerX.Update(elapsed);

            // TODO: Add your update logic here

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

            System.Console.WriteLine("bg Pos (x,y ) " + posplayer);
            

            /*if (posplayer.X < 520)
            {
                spriteBatch.Draw(bg, (bgpos - cameraPos) * scroll_factor, Color.White);
            }
            spriteBatch.Draw(bg, (bgpos - cameraPos) * scroll_factor + new Vector2(graphics.GraphicsDevice.Viewport.Width, 0), Color.White);


            if (posplayer.X > 520)
            {
                spriteBatch.Draw(bg, (bgpos - cameraPos) * scroll_factor + new Vector2(graphics.GraphicsDevice.Viewport.Width, 0) * 2, Color.White);

            }*/

            
            hp.Draw(spriteBatch);

            //lazer0.Draw(spriteBatch);

           
            spriteBatch.Draw(ball, posball, Color.White);





            if (hit == false)
            {
                //spriteBatch.Draw(ball, posmonster, Color.White);

            }
            if (dropitem == true)
            {

                item.Draw(spriteBatch);

            }


            //player.DrawFrame(spriteBatch, posplayer, direction);

            playerX.Draw(spriteBatch);

            if (shootpos == true)
            {
                //poslazer = posplayer;
                poslazer = posplayer + offset;

                shootpos = false;

            }

            
            spriteBatch.DrawString(font, "Col : " + checkcol, new Vector2(200, 200), Color.Black);
            
            spriteBatch.DrawString(font, "score : " + score, new Vector2(200, 230), Color.Black);
            spriteBatch.DrawString(font, "count : " + counts, new Vector2(200, 245), Color.Black);
            spriteBatch.DrawString(font, "check : " + b, new Vector2(200, 330), Color.Black);


            spriteBatch.End();
            base.Draw(gameTime);

        }
        public void hits()
        {
            dropitem = true;

            checkcol = true;
            item.positem(old_posmon);
        }

        /*public void fire(bool a)
        {
            if (a == true)
            {
                lazer0.Draw(spriteBatch);
                b = a;
            }

        }*/
        


    }

}
