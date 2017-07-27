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
        public List<Door> doors;
        public List<PressurePlate> pressurePlates;

        public Level(Vector2 player1DefaultPosition, Vector2 player2DefaultPosition, Vector2 goal, List<PassiveObject> passiveObjects, List<Door> doors, List<PressurePlate> pressurePlates)
        {
            this.player1DefaultPosition = player1DefaultPosition;
            this.player2DefaultPosition = player2DefaultPosition;
            this.goal = goal;
            this.passiveObjects = passiveObjects;
            this.doors = doors;
            this.pressurePlates = pressurePlates;
        }
    }



    static class Levels
    {
        private static int level = 0;
        private static List<Level> levels;

        public static void Init (GraphicsDevice graphicsDevice)
        {
            levels = new List<Level>{
                new Level(new Vector2(10, 10), new Vector2(10, 100), new Vector2(600, 850),
                    new List<PassiveObject> {
                        new PassiveObject(new Vector2(200, Constants.screenHeight - 250), 50, 200, Color.Gray, graphicsDevice),
                        new PassiveObject(new Vector2(200, 0), 50, 550, Color.Gray, graphicsDevice)
                    },
                    new List<Door> {
                        new Door(new Vector2(200, Constants.screenHeight - 50), 50, Color.Red, graphicsDevice)
                    },
                    new List<PressurePlate>
                    {

                    }
                ),
                new Level(new Vector2(10, 10), new Vector2(10, 100), new Vector2(600, 850), 
                    new List<PassiveObject> {
                        new PassiveObject(new Vector2(200, Constants.screenHeight - 120), 50, 50, Color.Gray, graphicsDevice),
                        new PassiveObject(new Vector2(200, Constants.screenHeight - 70), 50, 50, Color.Gray, graphicsDevice)
                    },
                    new List<Door>(),
                    new List<PressurePlate>()
                )
            };
        }

        public static Level GetLevelData ()
        {
            return levels[level];
        }

        public static int GetLevel()
        {
            return level;
        }

        public static void NextLevel ()
        {
            level++;
        }

        public static void Reset()
        {
            level = 0;
        }
    }
}
