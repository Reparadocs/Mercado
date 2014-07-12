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
    public abstract class GameObject : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public Vector2 drawPosition { get; protected set; }
        public float rotation { get; protected set; }
        public float scale { get; protected set; }
        public float depth { get; protected set; }
        public Texture2D texture { get; protected set; }

        protected SpriteBatch SpriteBatch;
        protected Camera Camera;

        public GameObject(Game game, Texture2D texture)
            : base(game)
        {
            this.scale = 1.0f;
            this.texture = texture;
            SpriteBatch = ServiceProvider.GetService<SpriteBatch>();
            Camera = ServiceProvider.GetService<Camera>();
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
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Draw(texture, new Vector2((int)drawPosition.X, (int)drawPosition.Y), null, Color.White, rotation, Vector2.Zero, scale, SpriteEffects.None, depth);
            base.Draw(gameTime);
        }
    }
}
