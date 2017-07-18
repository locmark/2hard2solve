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
    class Level
    {
        public Vector2 player1DefaultPosition;
        public Vector2 player2DefaultPosition;
        public Vector2 goal;
        public List<PassiveObject> passiveObjects;

        public Level(Vector2 player1DefaultPosition, Vector2 player2DefaultPosition, Vector2 goal, List<PassiveObject> passiveObjects)
        {
            this.player1DefaultPosition = player1DefaultPosition;
            this.player2DefaultPosition = player2DefaultPosition;
            this.goal = goal;
            this.passiveObjects = passiveObjects;
        }
    }

    static class Levels
    {
        private static List<Level> levels;

        public static void Init (GraphicsDevice graphicsDevice)
        {
            levels = new List<Level>{
                new Level(new Vector2(10, 10), new Vector2(10, 100), new Vector2(600, 600), new List<PassiveObject> {
                    new PassiveObject(new Vector2(260, Constants.screenHeight - 120), 50, 50, Color.Gray, graphicsDevice),
                    new PassiveObject(new Vector2(200, Constants.screenHeight - 70), 50, 50, Color.Gray, graphicsDevice)
                })
            };
        }

        public static Level GetLevel (int level)
        {
            return levels[level];
        }
    }
}
