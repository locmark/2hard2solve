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
    static class Timer
    {
        public static SpriteFont font = Menu.font;
        private static float timer;
        public static int counterSeconds;

        public static void Tick(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            counterSeconds += (int)timer;
            if (timer >= 1.0F) timer = 0F;
          
        }
        public static void Display(SpriteBatch spriteBatch)
        {
            var minutes = counterSeconds / 60;
            var seconds = counterSeconds % 60;
            spriteBatch.DrawString(font, $"{minutes.ToString("00")}:{seconds.ToString("00")}", new Vector2(1480, 20), Color.Black);
        }

       
    }
}
