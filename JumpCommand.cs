using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mercado
{
    public class JumpCommand : ICommand
    {
        Vector2 jumpingForce;
        public JumpCommand(float jumpingForce)
        {
            this.jumpingForce = new Vector2(0,jumpingForce);
        }
        public void Execute(GameObject gameObject)
        {
            if(gameObject is PhysicsGameObject)
            {
                PhysicsGameObject physicsObject = (PhysicsGameObject)gameObject;
                physicsObject.ApplyForce(jumpingForce);
            }
        }
    }
}
