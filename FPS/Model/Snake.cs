using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPS.Model
{

    class Snake 
    {

        private Queue<Vector2> waypoints = new Queue<Vector2>();
        public Vector2 position = new Vector2(0.0f,0.1f);
        public Vector2 velocity;
        public Vector2 center = new Vector2(0,0);
        public Vector2 origin = new Vector2(0,0);
        protected float rotation = 0;

        float speed = 0.1f;
        Texture2D enemyTexture;

        public Snake(Texture2D texture, Vector2 position, float speed)
{
            enemyTexture = texture;
            this.speed = speed;
            this.position = position;
        }
        public void SetWaypoints(Queue<Vector2> waypoints)
        {
            foreach (Vector2 waypoint in waypoints)
                this.waypoints.Enqueue(waypoint);

            this.position = this.waypoints.Dequeue();
        }
        public float DistanceToDestination
        {
            get { return Vector2.Distance(position, waypoints.Peek()); }  // reach the peek of the waypoints;
        }

        public  void Update()
        {
            this.center = new Vector2(position.X + enemyTexture.Width / 2,
                 position.Y + enemyTexture.Height / 2);


            if (waypoints.Count > 0)
            {
                if (DistanceToDestination < speed)
                {
                    position = waypoints.Peek();
                    waypoints.Dequeue();
                }
                else
                {
                    Vector2 direction = waypoints.Peek() - position;
                    direction.Normalize();
                    velocity = Vector2.Multiply(direction, speed);
                    position += velocity;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(enemyTexture, center, null, Color.White, rotation,
                origin, 0.2f, SpriteEffects.None, 0);
            spriteBatch.End();
        }

    }
}
