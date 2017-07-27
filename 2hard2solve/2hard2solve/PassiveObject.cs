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
    class PassiveObject
    {
        public Vector2 position;
        public int width;
        public int height;

        private Texture2D texture;
        private Color color;

        public PassiveObject (Vector2 position, int width, int height, Color color, GraphicsDevice graphicsDevice)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.color = color;
            if (graphicsDevice != null)
                CreateTexture(graphicsDevice);
        }

        public CollisionRectangle GetCollisionRectangle() { return new CollisionRectangle(position, width, height); }

        private void CreateTexture(GraphicsDevice graphicsDevice)
        {
            texture = new Texture2D(graphicsDevice, 1, 1);
            Color[] colorData = new Color[1];
            colorData[0] = color;
            texture.SetData(colorData);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), this.color);
        }
    }
}
