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
    enum MenuStateEnum { newGame = 0, loadLevel = 1, ranking = 2, exit = 3 };
    enum IngameMenuStateEnum { resume = 0, chooseLevel = 1, ranking = 2, exit = 3 };

    static class MenuFlags
    {
        public static bool isGamePaused = false;
        public static bool isMenuActive = true;
        public static bool exitFlag = false;

    }

    static class Menu
    {

        public static SpriteFont font;
        private static KeyboardState oldKeyboardState;

        public static MenuStateEnum menuState;

        public static void Init(GraphicsDevice graphicsDevice)
        {
            //MenuFont = Content

        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            Color stringColor = Color.Black;
            spriteBatch.DrawString(font, "2 Hard 2 Solve", new Vector2(700, 100), stringColor);
            

            if (menuState == MenuStateEnum.newGame) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(font, "New game", new Vector2(700, 300), stringColor);

            if (menuState == MenuStateEnum.loadLevel) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(font, "Choose level", new Vector2(700, 400), stringColor);

            if (menuState == MenuStateEnum.ranking) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(font, "Ranking", new Vector2(700, 500), stringColor);

            if (menuState ==MenuStateEnum.exit) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(font, "Close this shit ASAP", new Vector2(700, 600), stringColor);
        }

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
                if (menuState == (MenuStateEnum)4) menuState = MenuStateEnum.exit;
            }
            else if (keyboard.IsKeyDown(Keys.Enter))
            {
                switch (menuState)
                {
                    case MenuStateEnum.newGame:
                        MenuFlags.isMenuActive = false;
                        //DB.AddNewScore(0, 0);
                        break;
                    case MenuStateEnum.loadLevel:
                        DB.AddNewScore(1, 100);
                        DB.AddNewScore(2, 200);
                        DB.AddNewScore(5, 400);
                        DB.AddNewScore(3, 900);
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
    }

    static class IngameMenu
    {
        private static KeyboardState oldKeyboardState;
        public static SpriteFont font;

        public static IngameMenuStateEnum IngameMenuState;
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
                if (IngameMenuState == (IngameMenuStateEnum)4) IngameMenuState = IngameMenuStateEnum.exit;
            }
            else if (keyboard.IsKeyDown(Keys.Enter))
            {
                switch (IngameMenuState)
                {
                    case IngameMenuStateEnum.resume:
                        MenuFlags.isGamePaused = false;
                        //DB.AddNewScore(0, 0);
                        break;
                    case IngameMenuStateEnum.chooseLevel:
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
        public static void Draw(SpriteBatch spriteBatch)
        {
            Color stringColor = Color.Black;
            spriteBatch.DrawString(font, "Game paused", new Vector2(700, 100), stringColor);
            //spriteBatch.DrawString(menuFont, $"{(int)IngameMenuState}", new Vector2(1000, 100), stringColor);

            if (IngameMenuState == IngameMenuStateEnum.resume) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(font, "Resume", new Vector2(700, 300), stringColor);

            if (IngameMenuState == IngameMenuStateEnum.chooseLevel) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(font, "Choose another level", new Vector2(700, 400), stringColor);

            if (IngameMenuState == IngameMenuStateEnum.ranking) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(font, "Ranking", new Vector2(700, 500), stringColor);

            if (IngameMenuState == IngameMenuStateEnum.exit) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(font, "Close this shit ASAP", new Vector2(700, 600), stringColor);
        }
    }
}


