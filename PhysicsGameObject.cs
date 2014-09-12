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
        public PhysicsBody body;

        bool fixedPos;

        public PhysicsGameObject(Game game, Texture2D texture, Vector2 position, bool fixedPos)
            : base(game, texture)
        {
            this.fixedPos = fixedPos;
            body = new PhysicsBody(position, new Point(texture.Height, texture.Width));
        }

        public PhysicsGameObject(Game game, Texture2D texture, Vector2 position, float gravity) 
            : base(game, texture)
        {
            fixedPos = false;
            body = new PhysicsBody(position, new Point(texture.Height, texture.Width), gravity);
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
            if (!fixedPos)
            {
                body.Update(gameTime);
            }
            drawPosition = Camera.WorldToCamera(body.position); 
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
