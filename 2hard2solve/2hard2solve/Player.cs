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
    class Player : iFloorCollidingAbitity, iGravityEffect, iPassiveObjectCollidingAbility, iSidesCollidingAbility
    {
        public Vector2 position;
        public Vector2 speed;
        public int size;

        private Color color;
        private Texture2D texture;

        private Keys keyRight;
        private Keys keyLeft;
        private Keys keyJump;

        public bool isMovingRight = false;
        public bool isMovingLeft = false;
        public bool isMovingUp = false;

        public bool canJump = false;

        public Player (Vector2 position, int size, Color color, Keys keyRight, Keys keyLeft, Keys keyJump, GraphicsDevice graphicsDevice)
        {
            this.position = position;
            this.size = size;
            this.color = color;
            this.speed = Vector2.Zero;
            this.keyRight = keyRight;
            this.keyLeft = keyLeft;
            this.keyJump = keyJump;

            this.CreateTexture(graphicsDevice);
        }

        private void CreateTexture (GraphicsDevice graphicsDevice)
        {
            texture = new Texture2D(graphicsDevice, 1, 1);
            Color[] colorData = new Color[1];
            colorData[0] = color;
            texture.SetData(colorData);
        }

        public void Update (KeyboardState keyboard)
        {
            CheckKeys(keyboard);
            position += speed / Constants.accuracy;
        }

        private void CheckKeys (KeyboardState keyboard)
        {
            isMovingRight = keyboard.IsKeyDown(keyRight);
            isMovingLeft = keyboard.IsKeyDown(keyLeft);
            isMovingUp = keyboard.IsKeyDown(keyJump);
        }

        // passive objects
        public void OnCollideWithObjectFromTop (float position)
        {
            this.speed.Y *= -1;
            this.position.Y = position;
        }

        public void OnCollideWithObjectFromRight(float position)
        {
            this.speed.X = 0;
            this.position.X = position - this.size;     
        }

        public void OnCollideWithObjectFromLeft(float position)
        {
            this.speed.X = 0;
            this.position.X = position;
        }

        public void OnCollideWithObjectFromBottom(float position)
        {
            if (this.speed.Y >= 0)
            {
                this.speed.Y = 0;
                this.position.Y = position - this.size;
                this.canJump = true;
            }
        }

        // gravity
        public Vector2 GetSpeed () { return speed; }
        public void SetSpeed (Vector2 speed) { this.speed = speed; }

        // floor collision
        public CollisionRectangle GetCollisionRectangle () { return new CollisionRectangle(position, size, size); }

        public void OnCollideWithFloor()
        {
            this.speed.Y = 0;
            this.position.Y = Constants.screenHeight - this.size;
        }

        // sides collisions
        public void OnCollideWithLeftSide()
        {
            if (this.isMovingLeft)
            {
                this.speed.X = 0;
                this.position.X = 0;
            }
        }

        public void OnCollideWithRightSide()
        {
            this.position.X = Constants.screenWidth - this.size;
            this.speed.X = 0;
        }

        // draw
        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, new Rectangle((int)this.position.X, (int)this.position.Y, this.size, this.size), this.color);
        }
    }
}
