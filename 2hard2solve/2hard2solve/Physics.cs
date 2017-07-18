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
        public static void Gravity(iGravityEffect _object)
        {
            _object.SetSpeed(new Vector2(_object.GetSpeed().X, _object.GetSpeed().Y + 1f / Constants.accuracy));
        }

        private static void RectangleCollisions()
        {

        }

        public static void FloorCollision(iFloorCollidingAbitity _object)
        {
            if (_object.GetCollisionRectangle().IsCollidingWithLine(new Vector2(0, Constants.screenHeight)))
            {
                _object.OnCollideWithFloor();
            }
        }

        public static void LeftSideColission(iSidesCollidingAbility _object)
        {
            if (_object.GetCollisionRectangle().position.X <= 0)
            {
                _object.OnCollideWithLeftSide();
            }
        }

        public static void RightSideColission(iSidesCollidingAbility _object)
        {
            if (_object.GetCollisionRectangle().position.X >= Constants.screenWidth - _object.GetCollisionRectangle().width)
            {
                _object.OnCollideWithRightSide();
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
                        rectangle.position.Y + rectangle.height - 5 <= passiveObject.position.Y)
                    {
                        _object.OnCollideWithObjectFromBottom(passiveObject.position.Y);
                    }

                    if (rectangle.position.Y <= passiveObject.position.Y + passiveObject.height &&
                        rectangle.position.Y + 5>= passiveObject.position.Y + passiveObject.height)
                    {
                        _object.OnCollideWithObjectFromTop(passiveObject.position.Y + passiveObject.height);
                    }
                }
            }
        }


        public static void PlayersCollisions (Player player1, Player player2)
        {
            if (player1.GetCollisionRectangle().IsCollidingWithRectangle(player2.GetCollisionRectangle()))
            {
                CollisionRectangle rectangle1 = player1.GetCollisionRectangle();
                CollisionRectangle rectangle2 = player2.GetCollisionRectangle();

                if (rectangle1.position.X + rectangle1.width >= rectangle2.position.X &&
                    rectangle1.position.X + rectangle1.width - 5 <= rectangle2.position.X)
                {
                    player1.OnCollideWithObjectFromRight(rectangle2.position.X);
                    player2.OnCollideWithObjectFromLeft(rectangle1.position.X + rectangle1.width);
                }

                if (rectangle1.position.X <= rectangle2.position.X + rectangle2.width &&
                    rectangle1.position.X + 5 >= rectangle2.position.X + rectangle2.width)
                {
                    player1.OnCollideWithObjectFromLeft(rectangle2.position.X + rectangle2.width);
                    player2.OnCollideWithObjectFromRight(rectangle1.position.X);
                }

                if (rectangle1.position.Y + rectangle1.height >= rectangle2.position.Y &&
                    rectangle1.position.Y + rectangle1.height - 5 <= rectangle2.position.Y)
                {
                    player1.OnCollideWithObjectFromBottom(rectangle2.position.Y);
                    player2.OnCollideWithObjectFromTop(rectangle1.position.Y + rectangle1.height);
                }

                if (rectangle1.position.Y <= rectangle2.position.Y + rectangle2.height &&
                    rectangle1.position.Y + 5 >= rectangle2.position.Y + rectangle2.height)
                {
                    player1.OnCollideWithObjectFromTop(rectangle2.position.Y + rectangle2.height);
                    player2.OnCollideWithObjectFromBottom(rectangle1.position.Y);
                }
            }
        }

    }
}
