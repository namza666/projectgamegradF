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

        List<Vector2> monsterpos = new List<Vector2>();
        List<Rectangle> playerpos = new List<Rectangle>();

        Vector2 posmonster = new Vector2(800, 400);
        public Texture2D monster;

        int direction = 1;
        projectgame.AnimatedTexture playerX;
        
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

        public spawnmonster(Game1 game)
        {

           // playerX = new projectgame.AnimatedTexture(Vector2.Zero, Rotation, Scale, Depth);


            this.game = game;
        }
        public void Load(ContentManager content)
        {
           // playerX.Load(content, asset, 12, 3, 10);
            font = content.Load<SpriteFont>("font");
            monster = content.Load<Texture2D>("ball");

        }

        public void Update(float elapsed)
        {

            posmonster.X -= 3;
            if (posmonster.X<0)
            {
                posmonster.X = 800;
            }
            // playerX.UpdateFrame(elapsed);


           // Rectangle playercol = new Rectangle((int)posplayer.X, (int)posplayer.Y, 85, 125);

            

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            //playerX.DrawFrame(spriteBatch, posplayer, direction);
            spriteBatch.Draw(monster, posmonster, Color.White);


            //spriteBatch.End();

        }

        

    }
}
