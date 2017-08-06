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

        /// <summary>
        /// Draws the scoretable on screen.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            int index = 0;

            wasIngameMenuActive = MenuFlags.isGamePaused;
            wasMenuActive = MenuFlags.isMenuActive;

            MenuFlags.isMenuActive = false;
            MenuFlags.isGamePaused = false;

            spriteBatch.DrawString(font, "Game Ranking", new Vector2(700, 100), Color.Black);
            spriteBatch.DrawString(font, "Level", new Vector2(500, 200), Color.Black);
            spriteBatch.DrawString(font, "Best time", new Vector2(1100, 200), Color.Black);

            foreach (var item in DB.GetDatabaseContent())
            {
                var minutes = item.time / 60;
                var seconds = item.time % 60;
                spriteBatch.DrawString(font, $"{item.level}", new Vector2(500, 300 + index), Color.Black);
                spriteBatch.DrawString(font, $"{minutes.ToString("00")}:{seconds.ToString("00")}", new Vector2(1100, 300 + index), Color.Black);
                index += 100;
            }//:{item.seconds.ToString("00")}
        }
        /// <summary>
        /// Restores the flags to return to the menu.
        /// </summary>
        public static void RestoreFlags()
        {
            MenuFlags.isGamePaused = wasIngameMenuActive;
            MenuFlags.isMenuActive = wasMenuActive;
        }
    }
}
