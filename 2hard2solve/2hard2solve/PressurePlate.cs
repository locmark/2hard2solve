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
    class PressurePlate
    {
        public Vector2 position;
        public bool state;
        public int width;

        private Color color;
        private Texture2D texture;

        public PressurePlate(Vector2 position, int width, Color color, GraphicsDevice graphicsDevice)
        {
            this.position = position;
            this.state = false;
            this.width = width;
            this.color = color;

            this.CreateTexture(graphicsDevice);
        }

        private void CreateTexture(GraphicsDevice graphicsDevice)
        {
            texture = new Texture2D(graphicsDevice, 1, 1);
            Color[] colorData = new Color[1];
            colorData[0] = color;
            texture.SetData(colorData);
        }

        public CollisionRectangle GetCollisionRectangle() { return new CollisionRectangle(position, this.width, Constants.pressurePlateHeight); }

        // draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, new Rectangle((int)this.position.X, (int)this.position.Y, this.width, Constants.pressurePlateHeight), this.color);
        }
    }
}
