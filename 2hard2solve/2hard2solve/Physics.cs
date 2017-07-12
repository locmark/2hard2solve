using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2hard2solve
{
    static class Physics
    {
        public static void Gravity (iGravityEffect _object)
        {
            _object.SetSpeed(new Vector2(_object.GetSpeed().X, _object.GetSpeed().Y + 1));
        }

        public static void RectangleCollisions()
        {

        }

        public static void FloorCollision (iFloorCollidingAbitity _object)
        {
            if (_object.GetCollisionRectangle().IsCollidingWithLine(new Vector2(0, Constants.screenHeight)))
            {
                _object.OnCollideWithFloor();
            }
        }

        public static void PlayerUpdate(Player player)
        {
            Gravity(player);
            FloorCollision(player);
        }

    }
}
