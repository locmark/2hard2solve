﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2hard2solve
{
    interface iSidesCollidingAbility
    {
        CollisionRectangle GetCollisionRectangle();
        void OnCollideWithLeftSide();
        void OnCollideWithRightSide();
    }
}
