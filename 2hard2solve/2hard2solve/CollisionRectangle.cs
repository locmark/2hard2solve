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
    class CollisionRectangle
    {
        public Vector2 position;
        public int width;
        public int height;

        public CollisionRectangle (Vector2 position, int width, int height)
        {
            this.position = position;
            this.width = width;
            this.height = height;
        }

        public bool IsCollidingWithLine (Vector2 line)
        {
            if (line.X == 0)
            {
                // Horizontal line
                return position.Y + height >= line.Y && position.Y <= line.Y;
            }
            else
            {
                // Verdical line
                return position.X + width >= line.X && position.X <= line.X;
            }
        }

        public bool IsCollidingWithRectangle(CollisionRectangle rectangle)
        {
            return rectangle.position.X >= position.X - rectangle.width &&
                   rectangle.position.X <= position.X + width &&
                   rectangle.position.Y >= position.Y - rectangle.height &&
                   rectangle.position.Y <= position.Y + height;
        }
    }
}
