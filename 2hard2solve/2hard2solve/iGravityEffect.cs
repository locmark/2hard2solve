using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2hard2solve
{
    interface iGravityEffect
    {
        Vector2 GetSpeed();
        void SetSpeed(Vector2 speed);
    }
}
