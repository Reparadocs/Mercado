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
        public static GameObject gameObject;

        public static Dictionary<Keys, ICommand> keyCommands;
        public static Dictionary<Buttons, ICommand> buttonCommands;
        public static IVectorCommand leftStick, rightStick;
        public static ICommand leftTrigger, rightTrigger;

        public static float triggerResistance;

        public InputManager()
        {
            keyCommands = new Dictionary<Keys, ICommand>();
            buttonCommands = new Dictionary<Buttons, ICommand>();
        }
        public void Update()
        {
            GamePadState controller = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboard = Keyboard.GetState();

            if (gameObject != null)
            {
                foreach (Keys k in keyCommands.Keys)
                {
                    if (keyboard.IsKeyDown(k))
                    {
                        keyCommands[k].Execute(gameObject);
                    }
                }

                foreach (Buttons b in buttonCommands.Keys)
                {
                    if (controller.IsButtonDown(b))
                    {
                        buttonCommands[b].Execute(gameObject);
                    }
                }

                if (leftStick != null)
                {
                    leftStick.Execute(gameObject, controller.ThumbSticks.Left);
                }

                if (rightStick != null)
                {
                    rightStick.Execute(gameObject, controller.ThumbSticks.Right);
                }

                if (leftTrigger != null)
                {
                    leftTrigger.Execute(gameObject);
                }

                if (rightTrigger != null)
                {
                    rightTrigger.Execute(gameObject);
                }
            }
        }
    }
}
