using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mercado
{
    public class PhysicsService
    {
        public List<Rectangle> colliders { get; private set; }

        public PhysicsService()
        {
            colliders = new List<Rectangle>();
        }

        public void addCollider(Rectangle collider)
        {
            colliders.Add(collider);
        }

        public void removeCollider(Rectangle collider)
        {
            colliders.Remove(collider);
        }

        public Vector2 GetIntersectionDepth(Rectangle a, Rectangle b)
        {
            Point distance = a.Center - b.Center;

            Vector2 minDistance = new Vector2(a.Width + b.Width, a.Height + b.Height) / 2.0f;

            if (Math.Abs(distance.X) >= minDistance.X || Math.Abs(distance.Y) > minDistance.Y)
            {
                return Vector2.Zero;
            }

            float depthX = distance.X > 0 ? minDistance.X - distance.X : -minDistance.X - distance.X;
            float depthY = distance.Y > 0 ? minDistance.Y - distance.Y : -minDistance.Y - distance.Y;
            return new Vector2(depthX, depthY);
        }

        public List<Rectangle> CollisionDetection(Rectangle box)
        {
            List<Rectangle> collisions = new List<Rectangle>();
            foreach (Rectangle r in colliders)
            {
                if (r.Intersects(box) && r != box)
                {
                    collisions.Add(r);
                }
            }
            if(collisions.Count == 0)
            {
                return null;
            }
            for(int i = 0; i < collisions.Count; i++)
            {
                int closest = i;
                float closestDistance = new Vector2(box.X - collisions[i].X, box.Y - collisions[i].Y).Length();
                for(int j = i+1; j < collisions.Count; j++)
                {
                    float distance = new Vector2(box.X - collisions[i].X, box.Y - collisions[i].Y).Length();
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closest = i;
                    }
                }
                Rectangle temp = collisions[i];
                collisions[i] = collisions[closest];
                collisions[closest] = temp;
            }
            return collisions;
        }
    }
}
