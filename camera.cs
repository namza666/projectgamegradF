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
    class camera
    {
        SpriteFont font;
        string str;

        public Vector2 cameraPos = Vector2.Zero;
        public Vector2 scroll_factor = new Vector2(1.0f, 1);
        public float speedCamera;

        public Rectangle cameraRec;

        public float TimeGame;
        int Time = 0;
        public int pos = 0;

        public float SpeedOfGame = (float)0.2;

        Game1 game;

        public camera(Game1 game)
        {
            speedCamera = (float)2;
            cameraRec = new Rectangle((int)cameraPos.X, (int)cameraPos.Y, 1024, 768);
            
        }

        public void Update(float elapse)
        {
            

            //What happen when Time passed
            
            

        }

        public void Draw(SpriteBatch batch)
        {
           
            //batch.DrawString(font, str, new Vector2(350, 120), Color.Black);
            
        }
    }
}
