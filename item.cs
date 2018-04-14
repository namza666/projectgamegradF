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


public class Item
{

    Vector2 itempos;
    Vector2 old_itempos;
    public Texture2D item2;
    List<Vector2> itemposx = new List<Vector2>();
    List<Rectangle> playerpos = new List<Rectangle>();
    List<Boolean> dropitem = new List<Boolean>();
    SpriteFont font;
    Vector2 g = new Vector2(0, 5);


    //Texture2D item;

    //GraphicsDeviceManager graphics;
    //SpriteBatch spriteBatch;

    public Item(int p1, float p2)
    {


        //graphics = new GraphicsDeviceManager(this);
        //Content.RootDirectory = "Content";
    }

    public void Load(ContentManager content)
    {


        item2 = content.Load<Texture2D>("item");
        // Create a new SpriteBatch, which can be used to draw textures.

        // item = Content.Load<Texture2D>("item");

        // TODO: use this.Content to load your game content here
    }
    public void Update(float elapsed)
    {


        for (int i = 0; i < itemposx.Count; i++)
        {



            itemposx[i] = new Vector2(itemposx[i].X, itemposx[i].Y + g.Y);

            if (itemposx[i].Y > 460)
            {
                itemposx[i] = new Vector2(itemposx[i].X, 460);
            }
        }

        for (int i = 0; i < itemposx.Count; i++)
        {
            Rectangle itemcol = new Rectangle((int)itemposx[i].X, (int)itemposx[i].Y, 20, 20);
            if (playerpos[i].Intersects(itemcol) == true)
            {

                dropitem[i] = false;
            }
            else
            {
                dropitem[i] = true;
            }

        }

        

        // TODO: Add your update logic here


    }

    public void positem(Vector2 itempos1)
    {
        itemposx.Add(itempos1);
        dropitem.Add(false);
    }
    public void colitem(Rectangle playercol)
    {
        playerpos.Add(playercol);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        for (int i = 0; i < itemposx.Count; i++)
        {
            if (dropitem[i] == true)
            {
                spriteBatch.Draw(item2, itemposx[i], Color.White);
            }

        }




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

}

