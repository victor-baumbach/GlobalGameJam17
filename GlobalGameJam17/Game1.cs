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
        char[] user = new char[levelSize];
        int keyboardInputPossition = 0;

        //Screen adjustment 
        int screenWidth = 800, screenHeight =600;
        enum gameState { mainMenu, playing}
        gameState currentGameState = gameState.mainMenu;
        enum playState { viewing, inputing, winning, loosing};
        playState currentPlayState = playState.viewing;

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

                    switch (currentPlayState)
                    {
                        case playState.viewing:
                            //The incorrect order of the wave is played. A suggestion as to how to do that would be to play the array alphabetically.
                            break;
                        case playState.inputing:
                            //handle user input
                            char characterInput = userInput.getKeyPress();
                            if (characterInput != ' ')
                            {
                                user[keyboardInputPossition] = characterInput;
                                keyboardInputPossition++;
                            }

                            //when the user is done inputting their solution (they have filled array 'user')
                            if (keyboardInputPossition + 1 == levelSize)
                            {
                                //test if the user's input matches the solution
                                bool testFailed = false;
                                int k = 0;
                                while (k < levelSize)
                                {
                                    if (level[k] != user[k])
                                    {
                                        //If there is an instance where the user's input does not match the correct response then the test is failed.
                                        testFailed = true;
                                        break;
                                    }
                                    k++;
                                }
                                if (testFailed)
                                {
                                    //Game Over
                                    currentPlayState = playState.loosing;
                                }
                                else
                                {
                                    //Win!
                                    currentPlayState = playState.winning;
                                }
                            }
                            break;
                        case playState.loosing:
                            //The player looses a round, the mexicans should look unhappy/cross with the player for a brief period.
                            //after a bit it should revert to the viewing playerState.
                            break;
                        case playState.winning:
                            //The player successfully completes the round, the mexicans should cheer and score should be added to the score counter.
                            //The player should progress to the next level. After the Mexicans give a fully animated complete wave to the player.
                            //Maybe a new puzzle/level should be generated here as well while the mexicans smile at the player.
                            break;
                    }

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
