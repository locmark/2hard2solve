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
    class Player
    {
        private Vector2 position;
        private int size;

        private Color color;
        private Texture2D texture;

        public Player (Vector2 position, int size, Color color, GraphicsDevice graphicsDevice)
        {
            this.position = position;
            this.size = size;
            this.color = color;
            CreateTexture(graphicsDevice);
        }

        private void CreateTexture (GraphicsDevice graphicsDevice)
        {
            texture = new Texture2D(graphicsDevice, 1, 1);
            Color[] colorData = new Color[1];
            colorData[0] = color;
            texture.SetData(colorData);
        }

        public void Update()
        {

        }

        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, size, size), color);
        }
    }
}
