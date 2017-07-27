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
    class Goal
    {
        public Vector2 position;
        private Texture2D texture;

        public Goal(Vector2 position, GraphicsDevice graphicsDevice)
        {
            this.position = position;
            CreateTexture(graphicsDevice);
        }

        private void CreateTexture(GraphicsDevice graphicsDevice)
        {
            texture = new Texture2D(graphicsDevice, 1, 1);
            Color[] colorData = new Color[1];
            colorData[0] = Color.White;
            texture.SetData(colorData);
        }

        public CollisionRectangle GetCollisionRectangle() { return new CollisionRectangle(position, Constants.goalWidth, Constants.goalHeight); }

        // draw
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, new Rectangle((int)this.position.X, (int)this.position.Y, Constants.goalWidth, Constants.goalHeight), Color.Green * 0.5f);
        }
    }
}
