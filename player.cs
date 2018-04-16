using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace project_game_ver0._3
{
    class player
    {
        
        int direction = 1;
        projectgame.AnimatedTexture playerX;

        //List<lazer> lazerlist = new List<lazer>();
        SpriteBatch spriteBatch;

        Vector2 bgpos = new Vector2(0, 0);
        Vector2 cameraPos = Vector2.Zero;
        Vector2 scroll_factor = new Vector2(1.0f, 1);

        Vector2 posplayer = new Vector2(350, 100);
        Game1 game;
        SpriteFont font;
        GraphicsDeviceManager graphics;
        KeyboardState old_ks;
        private float Rotation = 0;
        private float Scale = 1.0f;
        private float Depth = 0.5f;
        float gravity=3.0f;
        float foce=0;
        bool jumpplayer = false;
        bool shoot = false;
        bool check=false;
        bool checktime=false;
        int count;
        public Vector2 speed;
        spawnmonster monster;
        lazer lazer;
        camera camera;
        background bg;
        Hp hp;
        public int counttime;
        public Rectangle playercol;
        public Rectangle lasorcol;

        public player(Game1 game, string asset)
        {
            playerX = new projectgame.AnimatedTexture(Vector2.Zero, Rotation, Scale, Depth);
            lazer = new lazer(game);
            monster = new spawnmonster(game);
            this.game = game;
            bg = new background(game);
            hp = new Hp(0.5f,1);
            playercol = new Rectangle((int)posplayer.X, (int)posplayer.Y, 85, 125);
            lasorcol = new Rectangle((int)lazer.poslazer.X, (int)lazer.poslazer.Y, 30, 30);


        }
        public void Load(ContentManager content, string asset)
        {
            playerX.Load(content, asset, 12, 3, 10);
            font = content.Load<SpriteFont>("font");
            lazer.Load(content);
            bg.Load(content);
            monster.Load(content);
            hp.Load(content);
        }

        public void Update(float elapsed)
        {
            playerX.UpdateFrame(elapsed);
            posplayer.X += 1;

            
            playercol = new Rectangle((int)posplayer.X, (int)posplayer.Y, 85, 125);
            lasorcol = new Rectangle((int)lazer.poslazer.X, (int)lazer.poslazer.Y, 30, 30);
            if (playercol.Intersects(monster.moncol) == true)
            {
               
                hp.DecreaseHp(playercol.Intersects(monster.moncol));
                check = true;
                

            }
            if (lasorcol.Intersects(monster.moncol) == true)
            {


                checktime = true;
                monster.gethit(true);

            }
            

            if(checktime == true)
            {
                checktimetospawnmonster();
            }
            bg.getposplayer(posplayer);
            posplayer.Y += gravity;
            if(posplayer.Y> 380)
            {
                posplayer.Y = 380;
                foce = 7;


            }
            if (foce == 0)
            {
                jumpplayer = false;
            }
            if (jumpplayer == true)
            {
                count++;
                posplayer.Y -= foce;
                if (count == 15)
                {
                    foce -= 1;
                    count = 0;
                }
            }
            
            monster.Update(elapsed);
            lazer.Update(elapsed);
            bg.Update(elapsed);
            hp.Update(elapsed);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();

            bg.Draw(spriteBatch);
            playerX.DrawFrame(spriteBatch, posplayer, direction);
            monster.Draw(spriteBatch);
            hp.Draw(spriteBatch);
            spriteBatch.DrawString(font, "jump : " + jumpplayer, new Vector2(200, 260), Color.Black);
            spriteBatch.DrawString(font, "g : " + gravity, new Vector2(200, 275), Color.Black);
            spriteBatch.DrawString(font, "foce : " + foce, new Vector2(200, 300), Color.Black);
            spriteBatch.DrawString(font, "count : " + count, new Vector2(200, 315), Color.Black);
            spriteBatch.DrawString(font, "lazer : " + lazer.poslazer, new Vector2(400, 260), Color.Black);
            spriteBatch.DrawString(font, "check : " + check, new Vector2(400, 275), Color.Black);
            spriteBatch.DrawString(font, "moncol : " + monster.moncol, new Vector2(400, 290), Color.Black);
            spriteBatch.DrawString(font, "playercol : " + playercol, new Vector2(400, 305), Color.Black);
            spriteBatch.DrawString(font, "checktime : " + counttime, new Vector2(400, 320), Color.Black);
            spriteBatch.DrawString(font, "hit monster : " + monster.hit, new Vector2(400, 335), Color.Black);



            if (shoot == true)
            {
                lazer.Draw(spriteBatch);
                if (lazer.poslazer.X >= 800)
                {
                    shoot = false;
                }
            }
            
            //spriteBatch.End();

        }
        public void getposmon(Vector2 getposplayer)
        {
            
        }

        public void checktimetospawnmonster()
        {
            counttime++;
            if(counttime == 300)
            {
                monster.posmonster.X = 800;
                monster.hit = false;
                counttime = 0;
            }

        }

        public void move(int move,float move1)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Space)&&shoot==false)
            {   

                lazer lazer1 = new lazer(game);
                lazer.shoot(posplayer);
                shoot = true;
                //lazerlist.Add(lazer1);

            }
            if (ks.IsKeyDown(Keys.D))
            {
                
                playerX.Play();
                posplayer.X += 1;

                
                direction = 3;

            }
            else if (ks.IsKeyUp(Keys.D))
            {
                playerX.Pause();

            }



            if (ks.IsKeyDown(Keys.A))
            {
                playerX.Play();
                posplayer.X -= 3;
                
                direction = 2;



            }
            else if (ks.IsKeyUp(Keys.A))
            {
                playerX.Play();

            }
            if (ks.IsKeyUp(Keys.W)&&old_ks.IsKeyDown(Keys.W)&&jumpplayer==false)
            {
               
                playerX.Play();
                
                //power();



                jumpplayer = true;
                //direction = 4;


            }
            /*else if (ks.IsKeyUp(Keys.W))
            {
                foce += 25;

            }*/
            old_ks = ks;

        }
        
    }
}
