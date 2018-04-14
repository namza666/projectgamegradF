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

        List<Vector2> monsterpos = new List<Vector2>();
        List<Rectangle> playerpos = new List<Rectangle>();

        Vector2 poslazer = new Vector2(100, 100);
        public Texture2D lazer0;

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

        public lazer(int f)
        {

            // playerX = new projectgame.AnimatedTexture(Vector2.Zero, Rotation, Scale, Depth);


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

           
            // playerX.UpdateFrame(elapsed);


            // Rectangle playercol = new Rectangle((int)posplayer.X, (int)posplayer.Y, 85, 125);



        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            //playerX.DrawFrame(spriteBatch, posplayer, direction);
            spriteBatch.Draw(lazer0, poslazer, Color.White);


            spriteBatch.End();

        }

        public void shoot(Vector2 posplayer)
        {
            poslazer = posplayer;
        }

    }
}
