using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Mercado
{
    public class InputManager
    {
        public GameObject gameObject;

        public Dictionary<Keys, ICommand> keyCommands;
        public Dictionary<Buttons, ICommand> buttonCommands;
        public IVectorCommand leftStick, rightStick;



        public InputManager(GameObject gameObject)
        {
            this.gameObject = gameObject;
            keyCommands = new Dictionary<Keys, ICommand>();
            buttonCommands = new Dictionary<Buttons, ICommand>();
        }
        public void Update()
        {
            GamePadState controller = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboard = Keyboard.GetState();

            foreach(Keys k in keyCommands.Keys)
            {
                if(keyboard.IsKeyDown(k))
                {
                    keyCommands[k].Execute(gameObject);
                }
            }

            foreach(Buttons b in buttonCommands.Keys)
            {
                if(controller.IsButtonDown(b))
                {
                    buttonCommands[b].Execute(gameObject);
                }
            }

            if(leftStick != null)
            {
                leftStick.Execute(gameObject, controller.ThumbSticks.Left);
            }

            if(rightStick != null)
            {
                rightStick.Execute(gameObject, controller.ThumbSticks.Right);
            }
        }
    }
}
