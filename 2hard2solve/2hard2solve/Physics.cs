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
        private static void Gravity (iGravityEffect _object)
        {
            _object.SetSpeed(new Vector2(_object.GetSpeed().X, _object.GetSpeed().Y + 1));
        }

        private static void RectangleCollisions()
        {

        }

        private static void FloorCollision (iFloorCollidingAbitity _object)
        {
            if (_object.GetCollisionRectangle().IsCollidingWithLine(new Vector2(0, Constants.screenHeight)))
            {
                _object.OnCollideWithFloor();
            }
        }

        private static bool CanPlayerJump (Player player)
        {
            return player.GetCollisionRectangle().IsCollidingWithLine(new Vector2(0, Constants.screenHeight));
        }

        private static void ControllsHandling (Player player)
        {
            if (player.isMovingRight) { player.position.X += Constants.movementSpeed; }
            if (player.isMovingLeft) { player.position.X -= Constants.movementSpeed; }
            if (player.isMovingUp && CanPlayerJump(player)) { player.SetSpeed(new Vector2(player.GetSpeed().X, player.GetSpeed().Y - Constants.jumpPower)); }
        }

        private static void PassiveObjectsCollidingHandling (CollisionRectangle _object, List<PassiveObject> passiveObjects)
        {

        }

        public static void PlayerUpdate(Player player, List<PassiveObject> passiveObjects)
        {
            Gravity(player);
            FloorCollision(player);
            PassiveObjectsCollidingHandling(player.GetCollisionRectangle(), passiveObjects);
            ControllsHandling(player);
        }

    }
}
