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
    class spawnmonster
    {

        //List<Vector2> monsterpos = new List<Vector2>();
        //List<Rectangle> playerpos = new List<Rectangle>();

        public Vector2 posmonster = new Vector2(800, 300);
        public Texture2D monster;

        int direction = 1;
        projectgame.AnimatedTexture playerX;
        
        
        SpriteFont font;
        GraphicsDeviceManager graphics;
        KeyboardState old_ks;
        private float Rotation = 0;
        private float Scale = 1.0f;
        private float Depth = 0.5f;
        
        public bool hit=false;
        public int counttime;
        lazer lazer;
        player player;
        public Rectangle moncol;
        public Vector2 speedX = new Vector2(3, 0);
        

        public spawnmonster(Game1 game)
        {
            
            
            // playerX = new projectgame.AnimatedTexture(Vector2.Zero, Rotation, Scale, Depth);

            lazer = new lazer(game);
            
            //this.game = game;
        }
        public void Load(ContentManager content)
        {
           // playerX.Load(content, asset, 12, 3, 10);
            font = content.Load<SpriteFont>("font");
            monster = content.Load<Texture2D>("ball");

        }

        public void Update(float elapsed)
        {

            moncol = new Rectangle((int)posmonster.X, (int)posmonster.Y, 80, 80);

            
            
            //lazer.getcol(moncol);
            
            if (posmonster.X<0)
            {
                posmonster.X = 0;
            }
            // playerX.UpdateFrame(elapsed);


            // Rectangle playercol = new Rectangle((int)posplayer.X, (int)posplayer.Y, 85, 125);
            lazer.Update(elapsed);
            

        }
        public void gethit(bool get)
        {
            hit = get;
            hit = false;
            posmonster.X = 800;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            //playerX.DrawFrame(spriteBatch, posplayer, direction);

            //spriteBatch.Draw(monster, posmonster, Color.White);

            //spriteBatch.Draw(monster, posmonster, new Rectangle(170, 0, 170, 210), Color.White, 0, Vector2.Zero, new Vector2(1, 1), 0, 0);
            //spriteBatch.Draw(monster, posmonster, new Rectangle(100,100, 30, 30), Color.White);
            if (hit == false)
            {
                posmonster.X -= speedX.X;
                spriteBatch.Draw(monster, posmonster, Color.White);
            }


            //spriteBatch.End();

        }

        

    }
}
