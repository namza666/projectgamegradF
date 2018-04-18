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
    class bullet
    {
        
        
        Texture2D laser;
        public Vector2 posbullet;
        // bullet for monster
        public bullet(Game game)
        {
           
        }
        public void Load(ContentManager content)
        {

            laser = content.Load<Texture2D>("laser");

        }
        public void reload(Vector2 posmonster)
        {

            posbullet = posmonster;

        }
        public void Update(float elapsed)
        {
            posbullet.Y += 1;
            

        }

        
        public void Draw(SpriteBatch spriteBatch)
        {

            //spriteBatch.Draw(laser, posbullet, Color.White);



        }

        
    }
}
