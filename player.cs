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



        List<Platform> platfroms = new List<Platform>();
        List<coin> coinss = new List<coin>();

        Random random = new Random();
        //List<lazer> lazerlist = new List<lazer>();
        SpriteBatch spriteBatch;

        Vector2 bgpos = new Vector2(0, 0);
        Vector2 cameraPos = Vector2.Zero;
        Vector2 scroll_factor = new Vector2(1.0f, 1);
        Vector2 velocity;
        public Vector2 posplayer;
        Vector2 old_posplayer ;
        

        Game1 game;

        SpriteFont font;

        GraphicsDeviceManager graphics;
        KeyboardState old_ks;

        private float Rotation = 0;
        private float Scale = 1.0f;
        private float Depth = 0.5f;

        Vector2 gravity =new Vector2(0,3.0f);
        float foce=0;
        bool jumpplayer = false;
        bool shoot = false;
        bool check=false;
        bool checktime=false;
        int count;
        public Vector2 speed;

        coin coins;
        lazer lazer;
        camera camera;
        background bg;
        Hp hp;
        bullet bullet;

        public int counttime;
        public Rectangle playercol;
        public Rectangle lasorcol;

        int score;

        public player(Game1 game, string asset)
        {
            playerX = new projectgame.AnimatedTexture(Vector2.Zero, Rotation, Scale, Depth);
            lazer = new lazer(game);
            coins = new coin(game,new Vector2(0,0));
            this.game = game;
            bg = new background(game);
            hp = new Hp(0.5f,1);
            playercol = new Rectangle((int)posplayer.X, (int)posplayer.Y, 85, 125);
            lasorcol = new Rectangle((int)lazer.poslazer.X, (int)lazer.poslazer.Y, 30, 30);
            cameraPos += new Vector2(1, 0);
            posplayer = new Vector2(350, 0);

    }
        public void Load(ContentManager content, string asset)
        {
            playerX.Load(content, asset, 12, 3, 10);
            
            font = content.Load<SpriteFont>("font");
            lazer.Load(content);
            bg.Load(content);

            for (int i = 0; i < 5; i++)
            {
                coinss.Add(new coin(game, new Vector2(700+(50*i), 250)));


            }

            for (int i = 0; i < 5; i++)
            {
                coinss.Add(new coin(game, new Vector2(1200 + (50 * i), 250)));


            }

            for (int i = 0; i < 5; i++)
            {
                coinss.Add(new coin(game, new Vector2(2100 + (50 * i), 150)));


            }

            for (int i = 0; i < 3; i++)
            {
                coinss.Add(new coin(game, new Vector2(2500 + (50 * i), 250)));


            }

            for (int i = 0; i < 3; i++)
            {
                coinss.Add(new coin(game, new Vector2(2900 + (50 * i), 350)));


            }

            for (int i = 0; i < 7; i++)
            {
                coinss.Add(new coin(game, new Vector2(3500 + (50 * i), 150)));


            }

            for (int i = 0; i < 4; i++)
            {
                coinss.Add(new coin(game, new Vector2(4000 + (50 * i), 150)));


            }

            //coinss.Load(content,"coin");


            for (int i = 0; i < coinss.Count; i++)
            {
                coinss[i].Load(content, "coin");
            }


            hp.Load(content);
            

            for (int i = 0; i < 20; i++)
            {
                platfroms.Add(new Platform(game, content.Load<Texture2D>("platfrom"), new Vector2(100 + (25 * (i + 1)), 400)));


            }

            for (int i = 0; i < 20; i++)
            {
                platfroms.Add(new Platform(game, content.Load<Texture2D>("platfrom"), new Vector2(600 + (25 * (i + 1)), 300)));


            }

            for (int i = 0; i < 10; i++)
            {
                platfroms.Add(new Platform(game, content.Load<Texture2D>("platfrom"), new Vector2(1500 + (25 * (i + 1)), 400)));


            }

            for (int i = 0; i < 10; i++)
            {
                platfroms.Add(new Platform(game, content.Load<Texture2D>("platfrom"), new Vector2(2100 + (25 * (i + 1)), 400)));


            }

            for (int i = 0; i < 10; i++)
            {
                platfroms.Add(new Platform(game, content.Load<Texture2D>("platfrom"), new Vector2(2500 + (25 * (i + 1)), 350)));


            }

            for (int i = 0; i < 10; i++)
            {
                platfroms.Add(new Platform(game, content.Load<Texture2D>("platfrom"), new Vector2(2900 + (25 * (i + 1)), 300)));


            }

            for (int i = 0; i < 10; i++)
            {
                platfroms.Add(new Platform(game, content.Load<Texture2D>("platfrom"), new Vector2(3500 + (25 * (i + 1)), 250)));


            }

            for (int i = 0; i < 10; i++)
            {
                platfroms.Add(new Platform(game, content.Load<Texture2D>("platfrom"), new Vector2(4000 + (25 * (i + 1)), 400)));


            }
            for (int i = 0; i < 15; i++)
            {
                platfroms.Add(new Platform(game, content.Load<Texture2D>("platfrom"), new Vector2(4500 + (25 * (i + 1)), 450)));


            }
            for (int i = 0; i < 10; i++)
            {
                platfroms.Add(new Platform(game, content.Load<Texture2D>("platfrom"), new Vector2(5000 + (25 * (i + 1)), 300)));


            }

            for (int i = 0; i < 15; i++)
            {
                platfroms.Add(new Platform(game, content.Load<Texture2D>("platfrom"), new Vector2(5500 + (25 * (i + 1)), 250)));


            }
            for (int i = 0; i < 10; i++)
            {
                platfroms.Add(new Platform(game, content.Load<Texture2D>("platfrom"), new Vector2(6000 + (25 * (i + 1)), 300)));


            }




        }

        

        public void Update(float elapsed)
        {

            velocity.Y = 0;
            playerX.UpdateFrame(elapsed);
            posplayer += velocity;
            old_posplayer = posplayer;
            hp.DecreaseHp(true);


            /*if (jumpplayer == false)
            {
                velocity.Y = 3;
            }
            if (posplayer.Y>380)
            {
                posplayer.Y = 380;
            }
            if (jumpplayer == true)
            {
                velocity.Y = -6;
            }*/

            for (int i = 0; i < platfroms.Count; i++)
            {

                platfroms[i].Update(elapsed);
            }
            for (int i = 0; i < coinss.Count; i++)
            {
                coinss[i].Update(elapsed);
               // Rectangle reccoin = new Rectangle((int)coinss[i].poscoin.X, (int)coinss[i].poscoin.Y, 50, 50);
            }

           

            for (int i = 0; i < coinss.Count; i++)
            {

               
                if (playercol.Intersects(coinss[i].reccoin))
                {

                    check = true;
                    coinss.RemoveAt(i);
                    score += 5;
                }


            }

            foreach (Platform platform in platfroms)
                if (playercol.Intersects(platform.rectangle))
                {
                    jumpplayer = false;
                    posplayer = old_posplayer;
                    
                    //foce = 7;
                }
                else
                {
                    posplayer.Y += gravity.Y;
                }
           


            playercol = new Rectangle((int)posplayer.X, (int)posplayer.Y, 85, 125);
            lasorcol = new Rectangle((int)lazer.poslazer.X, (int)lazer.poslazer.Y, 30, 30);
            /*if (playercol.Intersects(monster.moncol) == true)
            {
               
                hp.DecreaseHp(playercol.Intersects(monster.moncol));
                check = true;
                

            }*/
           /* if (lasorcol.Intersects(monster.moncol) == true)
            {

                hitmonster();

                checktime = true;
                

            }*/
            

            
            bg.getposplayer(posplayer);

            if(jumpplayer == false)
            {
                //posplayer.Y += gravity.Y;
            }
           
            /*if(posplayer.Y> 380)
            {
                posplayer.Y = 380;
                foce = 10;


            }*/
           
            if (jumpplayer == true)
            {
                
                count++;
                posplayer.Y -= foce;
                if (count == 15)
                {
                    foce -= 2;
                    count = 0;
                }
                if (foce == 0)
                {
                    jumpplayer = false;
                }
            }


           /*if(velocity.X == 0)
            {
                jumpplayer = true;
            }*/
            
            lazer.Update(elapsed);
            bg.Update(elapsed);
            hp.Update(elapsed);
            
            
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            
            bg.Draw(spriteBatch);
            playerX.DrawFrame(spriteBatch, posplayer, direction);
            for (int i = 0; i < platfroms.Count; i++) 
            {
                platfroms[i].Draw(spriteBatch);
            }
            for (int i = 0; i < coinss.Count; i++)
            {
                coinss[i].Draw(spriteBatch);
            }


            /*foreach (Platform platform in platfroms)
                platform.Draw(spriteBatch);*/

            hp.Draw(spriteBatch);
            spriteBatch.DrawString(font, "jump : " + jumpplayer, new Vector2(200, 260), Color.Black);
            spriteBatch.DrawString(font, "g : " + gravity, new Vector2(200, 275), Color.Black);
            spriteBatch.DrawString(font, "foce : " + foce, new Vector2(200, 300), Color.Black);
            spriteBatch.DrawString(font, "count : " + count, new Vector2(200, 315), Color.Black);
            spriteBatch.DrawString(font, "lazer : " + lazer.poslazer, new Vector2(400, 260), Color.Black);
            spriteBatch.DrawString(font, "check : " + check, new Vector2(400, 275), Color.Black);
            
      
            spriteBatch.DrawString(font, "playercol : " + playercol, new Vector2(400, 305), Color.Black);
            spriteBatch.DrawString(font, "checktime : " + counttime, new Vector2(400, 320), Color.Black);
            spriteBatch.DrawString(font, "score : " + score, new Vector2(700, 100), Color.Black);



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
        public void hitmonster()
        {

            
            
        }

        public void checktimetospawnmonster()
        {
            counttime++;
            if(counttime == 300)
            {
               
                counttime = 0;
            }

        }

        

        public void move(int move,float move1)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Space)&&shoot==false)
            {   

                //lazer lazer1 = new lazer(game);
                lazer.shoot(posplayer);
                shoot = true;
                //lazerlist.Add(lazer1);

            }
            if (ks.IsKeyDown(Keys.D))
            {
                
                playerX.Play();
                //posplayer.X += 1;
                velocity.X = 2;
                
                direction = 3;

            }
            else if (ks.IsKeyUp(Keys.D))
            {
                playerX.Pause();

            }



            if (ks.IsKeyDown(Keys.A))
            {
                playerX.Play();
                //posplayer.X -= 3;
                velocity.X = -2;
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
    static class RectangleHelper
    {
        const int penetrationMargin = 5;
        public static bool IsOnTopOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Bottom >= r2.Top - penetrationMargin &&
                r1.Bottom <= r2.Top + 1 &&
                r1.Right >= r2.Left + 5 &&
                r1.Left <= r2.Right - 5);
        }
    }
}
