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

        public static void Draw(SpriteBatch spriteBatch)
        {
            int index = 0;

            wasIngameMenuActive = MenuFlags.isGamePaused;
            wasMenuActive = MenuFlags.isMenuActive;

            MenuFlags.isMenuActive = false;
            MenuFlags.isGamePaused = false;

            spriteBatch.DrawString(font, "Game Ranking", new Vector2(700, 100), Color.Black);
            spriteBatch.DrawString(font, "Level", new Vector2(500, 200), Color.Black);
            spriteBatch.DrawString(font, "Score", new Vector2(1100, 200), Color.Black);
            foreach (var item in DB.GetDatabaseContent())
            {

                spriteBatch.DrawString(font, $"{item.level}", new Vector2(500, 300 + index), Color.Black);
                spriteBatch.DrawString(font, $"{item.score}", new Vector2(1100, 300 + index), Color.Black);
                index += 100;
            }
        }
        public static void RestoreFlags()
        {
            MenuFlags.isGamePaused = wasIngameMenuActive;
            MenuFlags.isMenuActive = wasMenuActive;
        }
    }
}
