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
    class Platform
    {
        Texture2D texture;
        public Vector2 position;
        public Rectangle rectangle;
        camera camera;
        Vector2 cameraPos = Vector2.Zero;

        public Platform (Game1 game, Texture2D newTexture, Vector2 newPosition)
        {
           
            texture = newTexture;
            position = newPosition;
            camera = new camera(game);
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

        }
        public void Load(ContentManager content)
        {
            //texture = content.Load<Texture2D>("platfrom");

            
        }
        public void Update(float elapsed)
        {

            cameraPos += new Vector2(1, 0);


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(texture,(position- cameraPos), rectangle, Color.White);

        }
    }
}
