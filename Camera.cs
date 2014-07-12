using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mercado
{
    public class Camera
    {
        public Vector2 position { get; protected set; }
        public Vector2 size { get; protected set; }
        public Camera(Vector2 position, Vector2 size)
        {
            this.position = position;
            this.size = size;
        }

        public void Move(Vector2 move)
        {
            position += move;
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        } 

        public void SetSize(Vector2 size)
        {
            this.size = size;
        }

        public Vector2 WorldToCamera(Vector2 world)
        {
            return world - position;
        }

        public Vector2 CameraToWorld(Vector2 camera)
        {
            return camera + position;
        }

        public bool OnScreen(Vector2 position, Vector2 objectSize)
        {
            if(position.X - objectSize.X > size.X || position.Y - objectSize.Y > size.Y || position.X + objectSize.X < 0 || position.Y + objectSize.Y < 0)
            {
                return false;
            }

            return true;
        }
    }
}
