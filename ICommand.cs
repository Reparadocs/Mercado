using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mercado
{
    interface ICommand
    {
        void Execute(GameObject gameObject);
    }

    interface IVectorCommand
    {
        void Execute(GameObject gameObject, Vector2 vector)
        {

        }
    }
}
