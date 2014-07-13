using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Mercado
{
    public class MercadoEngine
    {
        InputManager InputManager;
        public MercadoEngine()
        {
            InputManager = new InputManager();
        }

        public void RegisterServices(SpriteBatch spriteBatch, Vector2 screenSize)
        {
            ServiceProvider.AddService<SpriteBatch>(spriteBatch);
            ServiceProvider.AddService<PhysicsService>(new PhysicsService());
            ServiceProvider.AddService<Camera>(new Camera(Vector2.Zero, screenSize));
        }

        public void Update()
        {
            InputManager.Update();
        }
    }
}
