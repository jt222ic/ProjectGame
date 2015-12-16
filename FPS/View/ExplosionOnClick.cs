using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.View
{
    class ExplosionOnClick
    {
        public List<TheOneWhoControl> explosionsView = new List<TheOneWhoControl>();

        ContentManager _content;
        SpriteBatch _spritebatch;
        Camera _camera;
        



        public ExplosionOnClick(ContentManager content, SpriteBatch spritebatch, Camera camera)
        {
            _content = content;
            _spritebatch = spritebatch;
            _camera = camera;
        }
        public void CreateExplosion()
        {
            
            explosionsView.Add(new TheOneWhoControl(_content, _spritebatch, _camera));
        }

        public void Update(float time)
        {
            foreach (TheOneWhoControl explosionOnClick in explosionsView)
            {
                explosionOnClick.Updateeverything(time);

            }
        }
        public void Draw()
        {

            foreach (TheOneWhoControl explosionOnClick in explosionsView)
            {
                explosionOnClick.DrawEverything();
            }
        }
    }
}
