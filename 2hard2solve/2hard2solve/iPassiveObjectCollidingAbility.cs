﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2hard2solve
{
    interface iPassiveObjectCollidingAbility
    {
        CollisionRectangle GetCollisionRectangle();
        void OnCollideWithObjectFromTop(float position);
        void OnCollideWithObjectFromRight(float position);
        void OnCollideWithObjectFromLeft(float position);
        void OnCollideWithObjectFromBottom(float position);
    }
}
