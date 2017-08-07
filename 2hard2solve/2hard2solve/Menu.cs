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
    /// <summary>
    /// State machine for menu
    /// </summary>
    enum MenuStateEnum { newGame = 0, ranking = 1, exit = 2 };
    /// <summary>
    /// State machine for pause menu
    /// </summary>
    enum IngameMenuStateEnum { resume = 0, ranking = 1, exit = 2 };

    /// <summary>
    /// Class with all flags needed by Menu section
    /// </summary>
    static class MenuFlags
    {
        public static bool isGamePaused = false;
        public static bool isMenuActive = true;
        public static bool exitFlag = false;
        public static bool winFlag = false;

    }

    static class Menu
    {

        public static SpriteFont font;
        private static KeyboardState oldKeyboardState;

        public static MenuStateEnum menuState;

        /// <summary>
        /// Draws menu on the screen.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            Color stringColor = Color.Black;
            spriteBatch.DrawString(font, "2 Hard 2 Solve", new Vector2(700, 100), stringColor);
            

            if (menuState == MenuStateEnum.newGame) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(font, "New game", new Vector2(700, 300), stringColor);

            if (menuState == MenuStateEnum.ranking) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(font, "Scores", new Vector2(700, 400), stringColor);

            if (menuState ==MenuStateEnum.exit) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(font, "Close this shit ASAP", new Vector2(700, 500), stringColor);
        }

        /// <summary>
        /// Handling keys for menu navigation.
        /// </summary>
        /// <param name="keyboard"> Game's KeyboardState.</param>
        public static void KeysHandler(KeyboardState keyboard)
        {
            KeyboardState newKeyboardState = keyboard;
            if (newKeyboardState.IsKeyDown(Keys.Up) && oldKeyboardState.IsKeyUp(Keys.Up))
            {
                menuState--;
                if (menuState < 0) menuState = 0;
            }
            else if (newKeyboardState.IsKeyDown(Keys.Down) && oldKeyboardState.IsKeyUp(Keys.Down))
            {
                menuState++;
                if (menuState == (MenuStateEnum)3) menuState = MenuStateEnum.exit;
            }
            else if (keyboard.IsKeyDown(Keys.Enter))
            {
                switch (menuState)
                {
                    case MenuStateEnum.newGame:
                        MenuFlags.isMenuActive = false;
                      
                        break;
                    case MenuStateEnum.ranking:
                        Ranking.isRankingActive = true;
                        break;
                    case MenuStateEnum.exit:
                        MenuFlags.exitFlag = true;
                        break;
                    default:
                        break;
                }

            }
            oldKeyboardState = newKeyboardState;

        }

        /// <summary>
        /// Draws outro.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        public static void EndOfGame(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "YOU WIN!", new Vector2(700, 300), Color.Black);
            spriteBatch.DrawString(font, "Press SPACE to go to the menu", new Vector2(500, 500), Color.Black);
           
           
        }
       
    }

    /// <summary>
    /// Class for pause menu 
    /// </summary>
    static class IngameMenu
    {
        private static KeyboardState oldKeyboardState;
        public static SpriteFont font;

        
        public static IngameMenuStateEnum IngameMenuState;
        /// <summary>
        /// Handling keys for pause menu navigation.
        /// </summary>
        /// <param name="keyboard"> Game's KeyboardState.</param>
        public static void KeysHandler(KeyboardState keyboard)
        {
            KeyboardState newKeyboardState = keyboard;
            
            if (newKeyboardState.IsKeyDown(Keys.Up) && oldKeyboardState.IsKeyUp(Keys.Up))
            {
                IngameMenuState--;
                if (IngameMenuState < 0) IngameMenuState = 0;
            }
            else if (newKeyboardState.IsKeyDown(Keys.Down) && oldKeyboardState.IsKeyUp(Keys.Down))
            {
                IngameMenuState++;
                if (IngameMenuState == (IngameMenuStateEnum)3) IngameMenuState = IngameMenuStateEnum.exit;
            }
            else if (keyboard.IsKeyDown(Keys.Enter))
            {
                switch (IngameMenuState)
                {
                    case IngameMenuStateEnum.resume:
                        MenuFlags.isGamePaused = false;
                        break;
                    case IngameMenuStateEnum.ranking:
                        Ranking.isRankingActive = true;
                        break;
                    case IngameMenuStateEnum.exit:
                        MenuFlags.exitFlag = true;
                        break;
                    default:
                        break;
                }

            }
            oldKeyboardState = newKeyboardState;

        }
        /// <summary>
        /// Draws actualy selected option in menu
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            Color stringColor = Color.Black;
            spriteBatch.DrawString(font, "Game paused", new Vector2(700, 100), stringColor);


            if (IngameMenuState == IngameMenuStateEnum.resume) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(font, "Resume", new Vector2(700, 300), stringColor);

            if (IngameMenuState == IngameMenuStateEnum.ranking) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(font, "Scores", new Vector2(700, 400), stringColor);

            if (IngameMenuState == IngameMenuStateEnum.exit) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(font, "Close this shit ASAP", new Vector2(700, 500), stringColor);
        }
    }
}


