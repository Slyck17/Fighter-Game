using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FightingGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle p1Rect;
        Rectangle p2Rect;
        PlayerIndex p1 = PlayerIndex.One;
        PlayerIndex p2 = PlayerIndex.Two;
        Texture2D texture;
        int screenWidth;
        int screenHeight;
        Vector2 p1Speed;
        Vector2 p2Speed;
        enum playerState {standing, jumping, crouching};
        playerState p1State;
        playerState p2State;
        bool p1CanJump;
        bool p2CanJump;
        Fighter player1;
        Fighter player2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 500;
            graphics.ApplyChanges();
            this.Window.AllowUserResizing = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screenWidth = graphics.GraphicsDevice.Viewport.Width;
            screenHeight = graphics.GraphicsDevice.Viewport.Height;
            p1Rect = new Rectangle(0, 350, 50, 150);
            p2Rect = new Rectangle(500, 350, 50, 150);
            p1Speed = new Vector2(3, 0);
            p2Speed = new Vector2(3, 0);
            p1State = playerState.standing;
            p2State = playerState.standing;
            p1CanJump = true;
            p2CanJump = true;
            player1 = new Fighter("p1", 100, p1Rect);
            player2 = new Fighter("p2", 100, p2Rect);
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
            texture = Content.Load<Texture2D>("White square");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            player1.Update(GamePad.GetState(p1), screenHeight);
            player2.Update(GamePad.GetState(p2), screenHeight);
            base.Update(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(texture, player1.rect, Color.White);
            spriteBatch.Draw(texture, player2.rect, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
