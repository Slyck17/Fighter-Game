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
    /// </summary>gg
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle fullScreen;
        Rectangle p1Rect;
        Rectangle p2Rect;
        PlayerIndex p1 = PlayerIndex.One;
        PlayerIndex p2 = PlayerIndex.Two;
        Texture2D texture;
        HealthBar healthBar;
        enum GameState { start, select, play, quit }
        GameState gameState;
        Texture2D end, start, select, play;
        GamePadState oldpad = GamePad.GetState(PlayerIndex.One);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Window.AllowUserResizing = true;
            graphics.PreferredBackBufferHeight = 1010;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.ApplyChanges();
            GameState gameState = GameState.start;
            Content.RootDirectory = "Content";
        }
        //disahdsiuahdiusauhdi
        //penigh
        //sdfoiahnlkjncoigva
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            p1Rect = new Rectangle(800, 500, 50, 150);
            p2Rect = new Rectangle(1100, 500, 50, 150);
            fullScreen = new Rectangle(0, 0, 1920, 1080);
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
            start = this.Content.Load<Texture2D>("wipTitleScreen");
            play = this.Content.Load<Texture2D>("play");
            select = this.Content.Load<Texture2D>("select");
            // TODO: use this.Content to load your game content here
            texture = Content.Load<Texture2D>("White square");
            end = this.Content.Load<Texture2D>("end");
            healthBar = new HealthBar(Content);
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
            GamePadState pad1 = GamePad.GetState(PlayerIndex.One);
            GamePadState pad2 = GamePad.GetState(PlayerIndex.One);
            if ((pad1.Buttons.A == ButtonState.Pressed && oldpad.Buttons.A != ButtonState.Pressed) || (pad2.Buttons.A == ButtonState.Pressed && oldpad.Buttons.A != ButtonState.Pressed) && (int)gameState < 3)
            {
                gameState++;
            }
            if ((int)gameState == 4)
            {
                //code to move on to quit screen when player died
                
            }
            if((int)gameState >= 5)
            {
                gameState = 0;
            }
            Input();
            healthBar.Update();
            oldpad = pad1;
            base.Update(gameTime);
        }
        public void Input()
        {
            GamePadState p1CurrentState = GamePad.GetState(p1);
            GamePadState p2CurrentState = GamePad.GetState(p2);
            if (p1CurrentState.ThumbSticks.Left.X < 0)
            {
                p1Rect.X += -10;
            }
            if (p1CurrentState.ThumbSticks.Left.X > 0)
            {
                p1Rect.X += 10;
            }
            if (p2CurrentState.ThumbSticks.Left.X < 0)
            {
                p2Rect.X += -10;
            }
            if (p2CurrentState.ThumbSticks.Left.X > 0)
            {
                p2Rect.X += 10;
            }
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
            if (gameState == GameState.start)
            {
                spriteBatch.Draw(start, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            }
            if (gameState == GameState.quit)
            {
                spriteBatch.Draw(end, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            }
            if (gameState == GameState.play)
            {
                spriteBatch.Draw(play, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.Draw(texture, p1Rect, Color.White);
                spriteBatch.Draw(texture, p2Rect, Color.White);
                healthBar.Draw(spriteBatch);
            }
            if (gameState == GameState.select)
            {
                spriteBatch.Draw(select, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}