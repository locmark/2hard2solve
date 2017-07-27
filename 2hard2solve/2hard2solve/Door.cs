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

        public Door(Vector2 position, int height, Color color, GraphicsDevice graphicsDevice)
        {
            this.position = position;
            this.state = false;
            this.height = height;
            this.color = color;

            this.CreateOpenTexture(graphicsDevice);
            this.CreateClosedTexture(graphicsDevice);
        }

        private void CreateOpenTexture(GraphicsDevice graphicsDevice)
        {
            openTexture = new Texture2D(graphicsDevice, 1, 1);
            Color[] colorData = new Color[1];
            colorData[0] = color * 0.5f;
            openTexture.SetData(colorData);
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
