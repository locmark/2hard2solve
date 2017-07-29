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
    class Door
    {
        public Vector2 position;
        public bool state;
        public int height;

        private Color color;
        private Texture2D openTexture;
        private Texture2D closedTexture;

        private bool animation = false;
        private float animationPosition;

        private Func<List<PressurePlate>, bool> checkState;

        public Door(Vector2 position, int height, Color color, Func<List<PressurePlate>, bool> checkState, GraphicsDevice graphicsDevice)
        {
            this.position = position;
            this.state = false;
            this.height = height;
            this.animationPosition = height;
            this.color = color;
            this.checkState = checkState;

            this.CreateOpenTexture(graphicsDevice);
            this.CreateClosedTexture(graphicsDevice);
        }

        public void Update(List<PressurePlate> pressurePlates)
        {
            if (checkState(pressurePlates) && !this.state)
            {
                this.Open();
            }

            if (!checkState(pressurePlates) && this.state)
            {
                this.Close();
            }

            if (animation)
            {
                if (this.state)
                {
                    animationPosition -= 0.1f;
                }
                else
                {
                    animationPosition += 0.1f;
                }
            }
        }

        private void CreateOpenTexture(GraphicsDevice graphicsDevice)
        {
            openTexture = new Texture2D(graphicsDevice, 1, 1);
            Color[] colorData = new Color[1];
            colorData[0] = color * 0.5f;
            openTexture.SetData(colorData);
        }

        private void Close()
        {
            this.state = false;
            animation = true;
        }

        private void Open()
        {
            this.state = true;
            animation = true;
        }

        private void CreateClosedTexture(GraphicsDevice graphicsDevice)
        {
            closedTexture = new Texture2D(graphicsDevice, 1, 1);
            Color[] colorData = new Color[1];
            colorData[0] = color;
            closedTexture.SetData(colorData);
        }

        // draw
        public void Draw(SpriteBatch spriteBatch)
        {
            if (animation)
            {
                spriteBatch.Draw(this.openTexture, new Rectangle((int)this.position.X, (int)(this.position.Y), Constants.doorsWidth, this.height), this.color);
                spriteBatch.Draw(this.closedTexture, new Rectangle((int)this.position.X, (int)this.position.Y, Constants.doorsWidth, (int)this.animationPosition), this.color);
                
                if ((!this.state && (animationPosition >= this.height))){
                    animationPosition = this.height;
                    animation = false;
                }

                if ((this.state && (animationPosition <= 0)))
                {
                    animationPosition = 0;
                    animation = false;
                }
            }
            else
            {
                if (state == true)
                {
                    spriteBatch.Draw(this.openTexture, new Rectangle((int)this.position.X, (int)this.position.Y, Constants.doorsWidth, this.height), this.color);
                }
                else
                {
                    spriteBatch.Draw(this.closedTexture, new Rectangle((int)this.position.X, (int)this.position.Y, Constants.doorsWidth, this.height), this.color);
                }
            }
            
            
        }

    }
}
