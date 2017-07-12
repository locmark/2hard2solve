﻿using Microsoft.Xna.Framework;
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

        Player player1;
        Player player2;

        List<PassiveObject> passiveObjects;

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
            graphics.PreferredBackBufferWidth = Constants.screenWidth;   // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = Constants.screenHeight;   // set this value to the desired height of your window
            graphics.ApplyChanges();

            player1 = new Player(new Vector2(20, 50), 50, Color.Red, Keys.D, Keys.A, Keys.Space, GraphicsDevice);
            player2 = new Player(new Vector2(100, 50), 50, Color.Blue, Keys.Right, Keys.Left, Keys.Up, GraphicsDevice);

            passiveObjects = new List<PassiveObject>();
            passiveObjects.Add(new PassiveObject(new Vector2(200, Constants.screenHeight-50), 50, 50, Color.Gray, GraphicsDevice));
            passiveObjects.Add(new PassiveObject(new Vector2(200, Constants.screenHeight - 120), 50, 50, Color.Gray, GraphicsDevice));

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

            Physics.PlayerUpdate(player1, passiveObjects);
            Physics.PlayerUpdate(player2, passiveObjects);
            player1.Update(Keyboard.GetState());
            player2.Update(Keyboard.GetState());

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

            foreach (PassiveObject _object in passiveObjects)
            {
                _object.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}