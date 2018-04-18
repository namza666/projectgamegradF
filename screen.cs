using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace project_game_ver0._3
{
    public class screen
    {
        protected EventHandler ScreenEvent;
        public screen(EventHandler theScreenEvent)
        {
            ScreenEvent = theScreenEvent;
        }
        public virtual void Update(GameTime theTime)
        {
        }
        public virtual void Draw(SpriteBatch theBatch)
        {
        }
    }
}
