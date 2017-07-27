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
    enum MenuStateEnum { newGame = 0, loadLevel = 1, rank = 2, exit = 3 };

    static class Menu
    {
        public static bool isGamePaused;
        public static bool isMenuActive = true;
        public static bool exitFlag = false;

        private static Color color;
        private static Texture2D texture;

        public static SpriteFont menuFont;
        private static KeyboardState oldKeyboardState;

        public static MenuStateEnum menuState;

        public static void Init(GraphicsDevice graphicsDevice)
        {
            //MenuFont = Content

        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            Color stringColor = Color.Black;
            spriteBatch.DrawString(menuFont, "2 Hard 2 Solve", new Vector2(700, 100), stringColor);
            spriteBatch.DrawString(menuFont, $"{(int)menuState}", new Vector2(1000, 100), stringColor);

            if (menuState == MenuStateEnum.newGame) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(menuFont, "New game", new Vector2(700, 300), stringColor);

            if (menuState == MenuStateEnum.loadLevel) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(menuFont, "Choose level", new Vector2(700, 400), stringColor);

            if (menuState == MenuStateEnum.rank) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(menuFont, "Rank", new Vector2(700, 500), stringColor);

            if (menuState == MenuStateEnum.exit) stringColor = Color.Chocolate;
            else stringColor = Color.Black;
            spriteBatch.DrawString(menuFont, "Close that shit ASAP", new Vector2(700, 600), stringColor);
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
                        isMenuActive = false;
                       
                        break;
                    case MenuStateEnum.loadLevel:
                        break;
                    case MenuStateEnum.rank:
                        break;
                    case MenuStateEnum.exit:
                        exitFlag = true;
                        break;
                    default:
                        break;
                }

            }
            oldKeyboardState = newKeyboardState;
            
        }
    }

}
