using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using project_game_ver0._3;
using Microsoft.Xna.Framework.Content;

namespace project_game_ver0._3
{
    class Hp : Game
    {
        Vector2 itempos = new Vector2(0, 0);
        public Texture2D item2;
        Texture2D barTexture;
        GraphicsDeviceManager graphics;

        Game1 game;

        int currentHeart;
        //Texture2D item;

        //GraphicsDeviceManager graphics;
        //SpriteBatch spriteBatch;

        public Hp(float p1,int p2)
        {
            //game = new Game1();
            //graphics = new GraphicsDeviceManager(this);
            //Content.RootDirectory = "Content";
        }

        public void Load(ContentManager content)
        {

            barTexture = content.Load<Texture2D>("HealthBar_thumb");
            currentHeart = barTexture.Width - 5;
        }
        public void Update(float elapsed)
        {

           
            







            // TODO: Add your update logic here


        }
        public void Draw(SpriteBatch spriteBatch)
        {



            spriteBatch.Draw(barTexture, new Rectangle(800 / 2 - barTexture.Width / 2, 30, barTexture.Width, 44), new Rectangle(0, 0, barTexture.Width - 4, 59), Color.White);
            spriteBatch.Draw(barTexture, new Rectangle(800 / 2 - barTexture.Width / 2, 30, currentHeart, 42), new Rectangle(0, 58, barTexture.Width - 10, 60), Color.Red);



        }

        //public void drawitem(int p1,SpriteBatch spriteBatch)
        //{

        //    spriteBatch.Draw(item2, itempos, Color.White);

        //}
        /* public item()
         {
             GraphicsDevice.Clear(Color.CornflowerBlue);
             spriteBatch.Begin();
             spriteBatch.Draw(item2, itempos, Color.White);
             spriteBatch.End();
         }*/
        public void DecreaseHp(bool c)
        {
            if (c = true) {
                if (currentHeart > 0 && c == true)
                {
                    currentHeart = currentHeart - 3;
                }
                
            }
        }
    }
   
}
