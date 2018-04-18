using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace project_game_ver0._3
{
    class coin
    {
        projectgame.AnimatedTexture cointex;
        private float Rotation = 0;
        private float Scale = 1.0f;
        private float Depth = 0.5f;
        protected int width, height;
        public Vector2 poscoin;
        Vector2 cameraPos;
        camera cam;
        player player;
        public Rectangle reccoin;

        public coin(Game1 game,Vector2 poscoin)
        {
            cam = new camera(game);
            this.poscoin = poscoin;
            //player = new player(game,"");
            
        }

        public void Load(ContentManager content, string asset)
        {
            cointex = new projectgame.AnimatedTexture(Vector2.Zero, Rotation, Scale, Depth);
            cointex.Load(content, asset, 10, 1, 10);
            

        }

        public void Update(float elapsed)
        {
            reccoin = new Rectangle((int)this.poscoin.X, (int)this.poscoin.Y, 50, 50);
            poscoin-=cameraPos;
            cointex.UpdateFrame(elapsed);
            cameraPos = new Vector2(1, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            cointex.DrawFrame(spriteBatch, (poscoin-cameraPos));

            
            
        }
        public int GetWidth
        {
            get { return width; }
        }

        public int GetHeight
        {
            get { return height; }
        }
    }
}
