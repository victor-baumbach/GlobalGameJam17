#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

namespace GlobalGameJam17
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 

   
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;
        Texture2D background;
        private Texture2D SpriteWalk;

        animatedSpriteStrip testSprite;

        private SpriteFont font;
        private int score = 0;
        string word = "Y";
        const int levelSize = 5;
        char[] level = new char[levelSize];

        //Screen adjustment 
        int screenWidth = 800, screenHeight =600;
        enum gameState { mainMenu, playing}
        gameState currentGameState = gameState.mainMenu;

        cButton btnPlay;

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
            // TODO: Add your initialization logic here

            base.Initialize();
            const int levelSize = 5;
            char[] level = new char[levelSize];

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            //sets games window to full screen
            //graphics.IsFullScreen = true;

            graphics.ApplyChanges();

            IsMouseVisible = true;
        
            btnPlay = new cButton(Content.Load<Texture2D>("Button"), graphics.GraphicsDevice);

            btnPlay.setPosition(new Vector2(350, 300));

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D SpriteWalk = Content.Load<Texture2D>("walkingCapGuy");
            testSprite = new animatedSpriteStrip(SpriteWalk, 0.1f, true);
            background = Content.Load<Texture2D>("wave");
            font = Content.Load<SpriteFont>("Text");

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
            MouseState mouse = Mouse.GetState();

            bool generateLevel = true;

            if (generateLevel == true)
            {
                for (int i = 0; i < levelSize; i++)
                {
                    level[i] = Word_generator.GenerateChar();
                }
            }
            for (int j = 0; j < levelSize; j++)
            {
                Console.WriteLine(level);
            }
            Console.WriteLine();
            // TODO: Add your update logic here
           

            switch (currentGameState)
            {
                case gameState.mainMenu:
                    
                    if(btnPlay.isClicked == true) currentGameState = gameState.playing; btnPlay.Update(mouse);

                    break;

                case gameState.playing:

                    break;
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
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            switch (currentGameState)
            {
                case gameState.mainMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("background"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    btnPlay.Draw(spriteBatch);

                    break;

                case gameState.playing:
                #region level
                Vector2 spritePosition = new Vector2(100, 100);
                // TODO: Add your drawing code here
                spriteBatch.Draw(background, spritePosition, Color.White);
                spriteBatch.DrawString(font, "Text", new Vector2(100, 100), Color.Black);
                spriteBatch.DrawString(font, word, new Vector2(100, 150), Color.Black);

                // Draw the sprite.
                Vector2 pos;
                pos.X = 500.0f;
                pos.Y = 250.0f;
                testSprite.Draw(gameTime, spriteBatch, pos, SpriteEffects.None);
                #endregion
                    break;
            }
            
            spriteBatch.End();

            base.Draw(gameTime);

        }
    }
}
