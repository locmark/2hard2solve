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
        /// <summary>
        /// adds speed in Y caused by gravity
        /// </summary>
        /// <param name="_object"></param>
        public static void Gravity(iGravityEffect _object)
        {
            _object.SetSpeed(new Vector2(_object.GetSpeed().X, _object.GetSpeed().Y + 1f / Constants.accuracy));
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

        /// <summary>
        /// check if player can jump in current situation
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private static bool CanPlayerJump (Player player)
        {
            if (player.GetCollisionRectangle().IsCollidingWithLine(new Vector2(0, Constants.screenHeight)))
            {
                player.canJump = true;
            }
            return player.canJump;
        }

        /// <summary>
        /// change position if player press keys
        /// </summary>
        /// <param name="player"></param>
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

        private static void PassiveObjectCollision (iPassiveObjectCollidingAbility _object, PassiveObject passiveObject)
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
                    rectangle.position.Y + rectangle.height - 5 <= passiveObject.position.Y &&
                   !(rectangle.position.X + rectangle.width >= passiveObject.position.X &&          // to prevent from 
                    rectangle.position.X + rectangle.width - 5 <= passiveObject.position.X) &&      // stopping on edges
                   !(rectangle.position.X <= passiveObject.position.X + passiveObject.width &&      //
                    rectangle.position.X + 5 >= passiveObject.position.X + passiveObject.width)     //
                    )
                {
                    _object.OnCollideWithObjectFromBottom(passiveObject.position.Y);
                }

                if (rectangle.position.Y <= passiveObject.position.Y + passiveObject.height &&
                    rectangle.position.Y + 5 >= passiveObject.position.Y + passiveObject.height &&
                   !(rectangle.position.X + rectangle.width >= passiveObject.position.X &&          // same situation
                    rectangle.position.X + rectangle.width - 5 <= passiveObject.position.X) &&
                   !(rectangle.position.X <= passiveObject.position.X + passiveObject.width &&
                    rectangle.position.X + 5 >= passiveObject.position.X + passiveObject.width)
                    )
                {
                    _object.OnCollideWithObjectFromTop(passiveObject.position.Y + passiveObject.height);
                }
            }
        }

        public static void PassiveObjectsCollidingHandling (iPassiveObjectCollidingAbility _object, List<PassiveObject> passiveObjects)
        {
            foreach (PassiveObject passiveObject in passiveObjects)
            {
                PassiveObjectCollision(_object, passiveObject);
            }
        }


        public static void DoorsCollisions (Player player, List<Door> doors)
        {
            foreach (Door door in doors)
            {
                if (!door.state)
                    PassiveObjectCollision(player, new PassiveObject(door.position, Constants.doorsWidth, door.height, Color.White, null));
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
                    rectangle1.position.Y + rectangle1.height - 5 <= rectangle2.position.Y &&
                   !(rectangle1.position.X + rectangle1.width >= rectangle2.position.X &&          // same situation
                    rectangle1.position.X + rectangle1.width - 5 <= rectangle2.position.X) &&
                   !(rectangle1.position.X <= rectangle1.position.X + rectangle2.width &&
                    rectangle1.position.X + 5 >= rectangle1.position.X + rectangle2.width)
                    )
                {
                    player1.OnCollideWithObjectFromBottom(rectangle2.position.Y);
                    player2.OnCollideWithObjectFromTop(rectangle1.position.Y + rectangle1.height);
                }

                if (rectangle1.position.Y <= rectangle2.position.Y + rectangle2.height &&
                    rectangle1.position.Y + 5 >= rectangle2.position.Y + rectangle2.height &&
                   !(rectangle1.position.X + rectangle1.width >= rectangle2.position.X &&          // same situation
                    rectangle1.position.X + rectangle1.width - 5 <= rectangle2.position.X) &&
                   !(rectangle1.position.X <= rectangle1.position.X + rectangle2.width &&
                    rectangle1.position.X + 5 >= rectangle1.position.X + rectangle2.width)
                    )
                {
                    player1.OnCollideWithObjectFromTop(rectangle2.position.Y + rectangle2.height);
                    player2.OnCollideWithObjectFromBottom(rectangle1.position.Y);
                }
            }
        }

    }
}
