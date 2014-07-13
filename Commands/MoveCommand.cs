using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mercado
{
    public class MoveCommand : ICommand, IVectorCommand
    {
        Vector2 move;

        public MoveCommand(Vector2 move)
        {
            this.move = move;
        }

        public void Execute(GameObject gameObject)
        {
            if (gameObject is PhysicsGameObject)
            {
                PhysicsGameObject physicsObject = (PhysicsGameObject)gameObject;
                physicsObject.body.position += move;
            }
        }

        public void Execute(GameObject gameObject, Vector2 vector)
        {
            if (gameObject is PhysicsGameObject)
            {
                PhysicsGameObject physicsObject = (PhysicsGameObject)gameObject;
                physicsObject.body.position += move * vector;
            }
        }
    }
}
