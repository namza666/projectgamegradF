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
    class lazer
    {

        //List<Vector2> monsterpos = new List<Vector2>();
        //List<Rectangle> playerpos = new List<Rectangle>();
        //List<Vector2> lazerpos = new List<Vector2>();



        public Vector2 poslazer;
        public Texture2D lazer0;

        int direction = 1;
        projectgame.AnimatedTexture playerX;
        Rectangle moncol;
        Game1 game;
        SpriteFont font;
        GraphicsDeviceManager graphics;
        KeyboardState old_ks;
        private float Rotation = 0;
        private float Scale = 1.0f;
        private float Depth = 0.5f;
        float gravity = 3.0f;
        float foce = 0;
        bool jumpplayer = false;
        int count;
        
        Hp hp;
        player player;
        public Rectangle lasercol;
        //lazer is bullet of player
        public lazer(Game1 game)
        {
            
            
            hp = new Hp(0.1f,1);
            //lasercol = new Rectangle((int)poslazer.X, (int)poslazer.Y, lazer0.Width, lazer0.Height);
            this.game = game;
        }
        public void Load(ContentManager content)
        {
            // playerX.Load(content, asset, 12, 3, 10);
            font = content.Load<SpriteFont>("font");
            lazer0 = content.Load<Texture2D>("lazer");

        }

        public void Update(float elapsed)
        {
            if (poslazer.X < 800)
            {
                poslazer.X += 5;
            }
            

          

            // playerX.UpdateFrame(elapsed);
            //Rectangle lazerrcol = new Rectangle((int)poslazer.X, (int)poslazer.Y, 30, 30);

            // Rectangle playercol = new Rectangle((int)posplayer.X, (int)posplayer.Y, 85, 125);

            /*if (lazerrcol.Intersects(moncol) == true)
            {
               // monster.gethit(true);
               


            }*/

            //hp.Update(elapsed);

        }

        public void getcol(Rectangle col)
        {
            //moncol = col;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            //playerX.DrawFrame(spriteBatch, posplayer, direction);
            /*for(int i = 0; i < lazerpos.Count; i++)
            {
                spriteBatch.Draw(lazer0, lazerpos[i], Color.White);
                
            }*/

            spriteBatch.Draw(lazer0, poslazer, Color.White);



        }
        public void hitmonster()
        {

        }

        public void shoot(Vector2 posplayer)
        {
            poslazer = posplayer;
            
        }

    }
}
