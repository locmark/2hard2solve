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
   
    static class Ranking
    {
        public static bool isRankingActive = false;
        private static bool wasIngameMenuActive = false;
        private static bool wasMenuActive = false;
        public static SpriteFont font;
       
        private static void Draw(SpriteBatch spriteBatch)
        {
            int index = 0;
            spriteBatch.DrawString(font, "Game Ranking", new Vector2(700, 100), Color.Black);
            spriteBatch.DrawString(font, "Level", new Vector2(300, 200), Color.Black);
            spriteBatch.DrawString(font, "Score", new Vector2(900, 200), Color.Black);
            foreach (var item in DB.GetDatabaseContent())
            {
                
                spriteBatch.DrawString(font, $"{item.level}", new Vector2(300, 200 + index), Color.Black);
                spriteBatch.DrawString(font, $"{item.score}", new Vector2(900, 200 + index), Color.Black);
                index += 100;
            }
            while (Keyboard.GetState().IsKeyUp(Keys.Escape))
            {

            }
            isRankingActive = false;
        }
    }
}
