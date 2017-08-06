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

        public static void Init(GraphicsDevice graphicsDevice)
        {
            levels = new List<Level>{
                new Level(new Vector2(10, 10), new Vector2(10, 100), new Vector2(600, 850),
                    new List<PassiveObject> {
                        new PassiveObject(new Vector2(200, Constants.screenHeight - 250), 50, 200, Color.Gray, graphicsDevice),
                        new PassiveObject(new Vector2(200, 0), 50, 550, Color.Gray, graphicsDevice)
                    },
                    new List<Door> {
                        new Door(new Vector2(200, Constants.screenHeight - 50), 50, Color.Red, (List<PressurePlate> pressurePlates) => { return pressurePlates[0].state; } ,graphicsDevice)
                    },
                    new List<PressurePlate>
                    {
                        new PressurePlate(new Vector2(400, Constants.screenHeight - Constants.pressurePlateHeight), 50, Color.Red, graphicsDevice)
                    }
                ),
                new Level(new Vector2(50, 850), new Vector2(100, 850), new Vector2(1450, 850),
                    new List<PassiveObject> {
                        new PassiveObject(new Vector2(0, 700), 300, 50, Color.Gray, graphicsDevice),
                        new PassiveObject(new Vector2(250, 750), 50, 100, Color.Gray, graphicsDevice),
                        new PassiveObject(new Vector2(400, 700), 1150, 50, Color.Gray, graphicsDevice),
                        new PassiveObject(new Vector2(400, 750), 50, 100, Color.Gray, graphicsDevice),
                        new PassiveObject(new Vector2(1300, 750), 50, 100, Color.Gray, graphicsDevice),
                        new PassiveObject(new Vector2(200, 550), 50, 50, Color.Gray, graphicsDevice),
                        new PassiveObject(new Vector2(400, 500), 1150, 50, Color.Gray, graphicsDevice),
                        new PassiveObject(new Vector2(900, 750), 50, 100, Color.Gray, graphicsDevice),
                        new PassiveObject(new Vector2(1500, 550), 50, 150, Color.Gray, graphicsDevice),
                        new PassiveObject(new Vector2(1500, 0), 50, 450, Color.Gray, graphicsDevice),
                    },
                    new List<Door> {
                        new Door(new Vector2(400, 850), 50, Color.Moccasin, (List<PressurePlate> pressurePlates) => { return pressurePlates[0].state; } ,graphicsDevice),
                        new Door(new Vector2(1300, 850), 50, Color.Red, (List<PressurePlate> pressurePlates) => { return pressurePlates[1].state; } ,graphicsDevice),
                        new Door(new Vector2(900, 850), 50, Color.SteelBlue, (List<PressurePlate> pressurePlates) => { return pressurePlates[2].state; } ,graphicsDevice),
                        new Door(new Vector2(1500, 450), 50, Color.Purple, (List<PressurePlate> pressurePlates) => { return pressurePlates[3].state; } ,graphicsDevice)
                    },
                    new List<PressurePlate> {
                        new PressurePlate(new Vector2(150, Constants.screenHeight - Constants.pressurePlateHeight), 50, Color.Moccasin, graphicsDevice),
                        new PressurePlate(new Vector2(300, Constants.screenHeight - Constants.pressurePlateHeight), 100, Color.Red, graphicsDevice),
                        new PressurePlate(new Vector2(1400, 700 - Constants.pressurePlateHeight), 100, Color.SteelBlue, graphicsDevice),
                        new PressurePlate(new Vector2(1350, Constants.screenHeight - Constants.pressurePlateHeight), 50, Color.Purple, graphicsDevice),
                    }
                )
            };
        }



        public static int GetLevelsAmount()
        {
            return levels.Count;
        }

        public static Level GetLevelData()
        {
            return levels[level];
        }

        public static int GetLevel()
        {
            return level;
        }

        public static void SetLevel(int _level)
        {
           level = _level;
        }

        public static void NextLevel()
        {
            level++;
        }

        public static void Reset()
        {
            level = 0;
        }
    }
}
