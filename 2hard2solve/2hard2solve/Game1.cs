using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace _2hard2solve
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Player player1;
        Player player2;

        Goal goal;

        List<PassiveObject> passiveObjects;
        List<Door> doors;
        List<PressurePlate> pressurePlates;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Menu.isMenuActive = true;
            Menu.isGamePaused = false;
            graphics.PreferredBackBufferWidth = Constants.screenWidth;   // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = Constants.screenHeight;   // set this value to the desired height of your window
            graphics.ApplyChanges();

            Levels.Init(GraphicsDevice);
            Level level = Levels.GetLevelData();

            player1 = new Player(new Vector2(20, 50), 40, Color.Red, Keys.D, Keys.A, Keys.Space, GraphicsDevice);
            player2 = new Player(new Vector2(100, 50), 40, Color.Blue, Keys.Right, Keys.Left, Keys.Up, GraphicsDevice);

            goal = new Goal(level.goal, GraphicsDevice);

            player1.position = level.player1DefaultPosition;
            player2.position = level.player2DefaultPosition;

            passiveObjects = level.passiveObjects;
            doors = level.doors;
            pressurePlates = level.pressurePlates;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Menu.menuFont = Content.Load<SpriteFont>("MenuFont");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (!Menu.isMenuActive)
            {
                for (int i = 0; i < Constants.accuracy; i++)
                {

                    Physics.Gravity(player1);
                    Physics.FloorCollision(player1);
                    Physics.LeftSideColission(player1);
                    Physics.RightSideColission(player1);
                    Physics.ControllsHandling(player1);
                    Physics.PassiveObjectsCollidingHandling(player1, passiveObjects);

                    Physics.PlayersCollisions(player1, player2);
                    player1.Update(Keyboard.GetState());


                    Physics.Gravity(player2);
                    Physics.FloorCollision(player2);
                    Physics.LeftSideColission(player2);
                    Physics.RightSideColission(player2);
                    Physics.ControllsHandling(player2);
                    Physics.PassiveObjectsCollidingHandling(player2, passiveObjects);
                    player2.Update(Keyboard.GetState());

                    if (goal.GetCollisionRectangle().IsCollidingWithRectangle(player1.GetCollisionRectangle()) && goal.GetCollisionRectangle().IsCollidingWithRectangle(player2.GetCollisionRectangle()))
                    {
                        Levels.NextLevel();
                        Level level = Levels.GetLevelData();

                        player1 = new Player(new Vector2(20, 50), 50, Color.Red, Keys.D, Keys.A, Keys.Space, GraphicsDevice);
                        player2 = new Player(new Vector2(100, 50), 50, Color.Blue, Keys.Right, Keys.Left, Keys.Up, GraphicsDevice);

                        goal = new Goal(level.goal, GraphicsDevice);

                        player1.position = level.player1DefaultPosition;
                        player2.position = level.player2DefaultPosition;

                        passiveObjects = level.passiveObjects;
                        doors = level.doors;
                        pressurePlates = level.pressurePlates;
                    }
                }
            }
            else
            {
                Menu.KeysHandler(Keyboard.GetState());

            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            goal.Draw(spriteBatch);
            Menu.Draw(spriteBatch);

            foreach (PassiveObject _object in passiveObjects)
            {
                _object.Draw(spriteBatch);
            }

            foreach (Door door in doors)
            {
                door.Draw(spriteBatch);
            }

            foreach (PressurePlate pressurePlate in pressurePlates)
            {
                pressurePlate.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
