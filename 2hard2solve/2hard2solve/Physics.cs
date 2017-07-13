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
            _object.SetSpeed(new Vector2(_object.GetSpeed().X, _object.GetSpeed().Y + 1f / Constants.accuracy));
        }

        private static void RectangleCollisions()
        {

        }

        public static void FloorCollision (iFloorCollidingAbitity _object)
        {
            if (_object.GetCollisionRectangle().IsCollidingWithLine(new Vector2(0, Constants.screenHeight)))
            {
                _object.OnCollideWithFloor();
            }
        }

        private static bool CanPlayerJump (Player player)
        {
            if (player.GetCollisionRectangle().IsCollidingWithLine(new Vector2(0, Constants.screenHeight)))
            {
                player.canJump = true;
            }
            return player.canJump;
        }

        public static void ControllsHandling (Player player)
        {
            if (player.isMovingRight) { player.position.X += (float) Constants.movementSpeed / Constants.accuracy; }
            if (player.isMovingLeft) { player.position.X -= (float) Constants.movementSpeed / Constants.accuracy; }
            if (player.isMovingUp && CanPlayerJump(player))
            {
                player.SetSpeed(new Vector2(player.GetSpeed().X, player.GetSpeed().Y - Constants.jumpPower));
                player.canJump = false;
            }
        }

        public static void PassiveObjectsCollidingHandling (iPassiveObjectCollidingAbility _object, List<PassiveObject> passiveObjects)
        {
            foreach (PassiveObject passiveObject in passiveObjects)
            {
                if (_object.GetCollisionRectangle().IsCollidingWithRectangle(passiveObject.GetCollisionRectangle()))
                {
                    //Console.WriteLine("collision!");
                    CollisionRectangle rectangle = _object.GetCollisionRectangle();
                    if (rectangle.position.X + rectangle.width >= passiveObject.position.X &&
                        rectangle.position.X + rectangle.width - 5 <= passiveObject.position.X)
                    {
                        _object.OnCollideWithObjectFromRight(passiveObject.position.X);
                    }

                    if (rectangle.position.X <= passiveObject.position.X + passiveObject.width &&
                        rectangle.position.X + 5 >= passiveObject.position.X + passiveObject.width)
                    {
                        _object.OnCollideWithObjectFromLeft(passiveObject.position.X + passiveObject.width);
                    }

                    if (rectangle.position.Y + rectangle.height >= passiveObject.position.Y &&
                        rectangle.position.Y + rectangle.height - 2 <= passiveObject.position.Y)
                    {
                        _object.OnCollideWithObjectFromBottom(passiveObject.position.Y);
                    }
                }
            }
        }

        //public static void PlayerUpdate(Player player, List<PassiveObject> passiveObjects)
        //{
        //    Gravity(player);
        //    FloorCollision(player);
        //    PassiveObjectsCollidingHandling(player, passiveObjects);
        //    ControllsHandling(player);
        //}

    }
}
