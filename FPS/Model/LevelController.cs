using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.Model
{
    class LevelController
    {
        Level level;
        Texture2D grass;
        Texture2D path;
        public LevelController(ContentManager Content)
        {
            level = new Level();

            // grass = Content.Load<Texture2D>("grass");
            // path = Content.Load<Texture2D>("path");
            //level.AddTexture(grass);
            //level.AddTexture(path);
        }


        public void Draw(SpriteBatch spritebatch)
        {

            level.Draw(spritebatch);

        }
    }
}
