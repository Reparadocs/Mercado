using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Mercado
{
    public class PhysicsGameObject : GameObject
    {
        protected PhysicsBody physicsBody;

        public PhysicsGameObject(Game game, Texture2D texture, Vector2 position)
            : base(game, texture)
        {
            physicsBody = new PhysicsBody(position, new Point(texture.Height, texture.Width));
        }

        public PhysicsGameObject(Game game, Texture2D texture, Vector2 position, float gravity) 
            : base(game, texture)
        {
            physicsBody = new PhysicsBody(position, new Point(texture.Height, texture.Width), gravity);
        }


        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            physicsBody.Update(gameTime);
            drawPosition = Camera.WorldToCamera(physicsBody.position); 
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public void ApplyForce(Vector2 force)
        {
            physicsBody.ApplyForce(force);
        }
    }
}
