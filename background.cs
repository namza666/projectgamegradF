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
    class background
    {
        GraphicsDeviceManager graphics;
        SpriteFont font;
        
        Texture2D bg;

        Vector2 bgpos = new Vector2(0, 0);
        Vector2 posplayer;
        Vector2 cameraPos = Vector2.Zero;
        Vector2 scroll_factor = new Vector2(1.0f, 1);

        player player;
        camera camera;
        Game1 game;
        public background(Game1 game)
        {
            
            camera = new camera(game);
            //graphics = new GraphicsDeviceManager(this);
            //Content.RootDirectory = "Content";
        }

        public void Load(ContentManager content)
        {

            font = content.Load<SpriteFont>("font");
            bg = content.Load<Texture2D>("bg4");
            // Create a new SpriteBatch, which can be used to draw textures.

            // item = Content.Load<Texture2D>("item");

            // TODO: use this.Content to load your game content here
        }
        public void Update(float elapsed)
        {

            /*if (posplayer.X < 325)
            {
                cameraPos -= new Vector2(2, 0);
                
            }*/
            


            if (posplayer.X > 0)
            {


                cameraPos += new Vector2(1, 0);
            }




            // TODO: Add your update logic here

            camera.Update(elapsed);
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            /* if (posplayer.X < 250)
             {
                 spriteBatch.Draw(bg, (bgpos - cameraPos) , Color.White);
             }*/
            
            spriteBatch.Draw(bg, (bgpos- cameraPos), Color.White);
            
            spriteBatch.Draw(bg, (bgpos - cameraPos) + new Vector2(1400, 0), Color.White);
            spriteBatch.Draw(bg, (bgpos - cameraPos) + new Vector2(2800, 0), Color.White);
            spriteBatch.Draw(bg, (bgpos - cameraPos) + new Vector2(4200, 0),Color.White);
            spriteBatch.Draw(bg, (bgpos - cameraPos) + new Vector2(5600, 0), Color.White);


            /*if (posplayer.X > 400)
            {
                spriteBatch.Draw(bg, (bgpos - cameraPos) , Color.White);
                

            }*/
            spriteBatch.DrawString(font, "posplayer : " + posplayer, new Vector2(200, 175), Color.Black);
            spriteBatch.DrawString(font, "bgpos : " + bgpos, new Vector2(200, 345), Color.Black);
            spriteBatch.DrawString(font, "cameraPos : " + cameraPos, new Vector2(200, 360), Color.Black);


        }
        public void getposplayer(Vector2 getposplayer)
        {
            posplayer = getposplayer;
        }
        
    }
}
