using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mercado
{
    public interface ICommand
    {
        void Execute(GameObject gameObject);
    }

    public interface IVectorCommand
    {
        void Execute(GameObject gameObject, Vector2 vector);
    }
}
