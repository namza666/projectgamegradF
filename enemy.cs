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

    class enemy
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;

        public bool isVisible;

         Random random = new Random();
        public int randX, randY;

        public enemy(Texture2D newTexture,Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;

            randY = random.Next(-4, 4);
            randX = random.Next(-4, -1);

            velocity = new Vector2(randX, randY);
        }

        public void Update(GraphicsDevice graphics)
        {
            position += velocity;
            if (position.Y <= 0 || position.Y >= graphics.Viewport.Height - texture.Height)
                velocity.Y = -velocity.Y;

            if (position.X < 0 - texture.Width)
                isVisible = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
