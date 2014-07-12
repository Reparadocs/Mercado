using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mercado
{
    public class PhysicsBody
    {
        public Vector2 position;

        bool onGround;
        Vector2 velocity;
        Vector2 gravity;
        Rectangle boundingBox;

        PhysicsService PhysicsService;

        public PhysicsBody(Vector2 position, Point size)
        {
            PhysicsService = ServiceProvider.GetService<PhysicsService>();
            this.position = position;
            boundingBox = new Rectangle((int)position.X, (int)position.Y, size.X, size.Y);
            PhysicsService.addCollider(boundingBox);
            velocity = Vector2.Zero;
        }

        public PhysicsBody(Vector2 position, Point size, float gravity) : this(position, size)
        {
            this.gravity = new Vector2(0, gravity);
        }

        public void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            ApplyForce(gravity);
            position += velocity * delta;
            boundingBox.Location = new Point((int)position.X, (int)position.Y);
            CollisionResolution();
        }

        public void Destroy()
        {
            PhysicsService.removeCollider(boundingBox);
        }

        public void ApplyForce(Vector2 force)
        {
            this.velocity += force;
        }

        bool OnGround()
        {
            return onGround;
        }

        void CollisionResolution()
        {
            onGround = false;
            Rectangle? collider = PhysicsService.CollisionDetection(boundingBox);
            if (collider != null)
            {
                Vector2 depth = PhysicsService.GetIntersectionDepth(boundingBox, (Rectangle)collider);
                if (Math.Abs(depth.X) > Math.Abs(depth.Y))
                {
                    if(depth.Y < 0)
                    {
                        onGround = true;
                    }
                    position += new Vector2(0, depth.Y);
                    velocity = new Vector2(velocity.X, 0);
                }
                else
                {
                    position += new Vector2(depth.X, 0);
                    velocity = new Vector2(0, velocity.Y);
                }
            }
        }
    }
}
