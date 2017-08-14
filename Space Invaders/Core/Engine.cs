namespace Space_Invaders.Core
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Space_Invaders.Common.Constants.Entities;
    using Space_Invaders.Common.Constants.Graphics;
    using Space_Invaders.Common.Constants.Weapons;
    using Space_Invaders.Interfaces.Core;
    using Space_Invaders.Interfaces.Globals;
    using Space_Invaders.Interfaces.IO.InputCommands;
    using Space_Invaders.Interfaces.Models.Enemies;
    using Space_Invaders.Interfaces.Models.Players;
    using Space_Invaders.Interfaces.Models.Weapons;
    using Space_Invaders.IO.InputCommands;
    using Space_Invaders.Models.Enimies;
    using Space_Invaders.Models.Players;
    using Space_Invaders.Models.Weapons;

    public class Engine : Game, IEngine
    {
        private readonly IInputCommand inputCommand;
        private KeyboardState currentKeyboardState;
        private IEnemyArmy enemyArmy;

        private List<IEntity> entities;
        private GraphicsDeviceManager graphics;
        private IInitializer initializer;
        private bool isGamePaused;
        private Texture2D pausedTexture;
        private IPlayer player;
        private KeyboardState previousKeyboardState;
        private SpriteBatch spriteBatch;
        private IWeapon weapon;
        private bool weapontVisibility;

        Texture2D background;
        Rectangle mainFrame;


        public Engine()
            : this(new Initilizer(), new InputCommand())
        {
        }

        public Engine(IInitializer initializer, IInputCommand inputCommand)
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";

            this.initializer = initializer;
            this.inputCommand = inputCommand;
        }

        /// <summary>
        ///     Allows the game to perform any initialization it needs to before starting to run.
        ///     This is where it can query for any required services and load any non-graphic
        ///     related content.  Calling base.Initialize will enumerate through any components
        ///     and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // MUST BE DONE FROM HERE
            this.player = new Exterminator(EntityConstants.ShipXStartCoordinates,
                EntityConstants.ShipYStartCoordinates, "R21");

            this.inputCommand.KeyPressed += this.player.OnKeyPressed;

            this.weapon = new Bullet(WeaponConstants.StartXCoordinates, WeaponConstants.StartYCoordinates);
            this.enemyArmy = new InvaderArmy();

            this.entities = new List<IEntity> { this.player, this.weapon, this.enemyArmy };

            this.graphics.IsFullScreen = false;
            this.graphics.PreferredBackBufferWidth = 1024;
            this.graphics.PreferredBackBufferHeight = 640;
            this.graphics.ApplyChanges();

            // TO HERE

            //this.initializer.SetGameMouse(this, GraphicsConstants.IS_MOUSE_VISIBLE);
            //this.initializer.SetGraphicsWindowSize(this.graphics,
            //                                       GraphicsConstants.PREFFER_BUFFER_WIDTH,
            //                                       GraphicsConstants.PREFFER_BUFFER_HEIGHT);

            base.Initialize();
        }

        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            //var viewWidth= this.GraphicsDevice.Viewport.Width;

            this.player.Load(this.Content, this.GraphicsDevice, "Pictures/Ship1");
            this.weapon.Load(this.Content, this.GraphicsDevice, "Pictures/Bulet");
            this.enemyArmy.Load(this.Content, this.GraphicsDevice, "Pictures/Enemy2");
            this.pausedTexture = this.Content.Load<Texture2D>("Pictures/paused");
            // Load the background content.
         
            this.background = Content.Load<Texture2D>("Pictures/Enemy1"); // backgroudn
 
            this.mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height); // background

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        ///     UnloadContent will be called once per game and is the place to unload
        ///     game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        ///     Allows the game to run logic such as updating the world,
        ///     checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (this.IsActive)
            {
                this.previousKeyboardState = this.currentKeyboardState;
                this.currentKeyboardState = Keyboard.GetState();
                this.inputCommand.GetKeyboardState(this.currentKeyboardState, gameTime);

                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                    this.currentKeyboardState.IsKeyDown(Keys.Escape))
                {
                    this.Exit();
                }

                if (this.currentKeyboardState.IsKeyUp(Keys.P) && this.previousKeyboardState.IsKeyDown(Keys.P))
                {
                    this.isGamePaused = !this.isGamePaused;
                }

                if (!this.isGamePaused)
                {
                    foreach (var entity in this.entities)
                    {
                        entity.SendWeaponState(this.weapontVisibility); //Give the bool param
                        entity.Update(gameTime, this.currentKeyboardState); // Update Player

                        if (this.currentKeyboardState.IsKeyDown(Keys.Space) && this.weapontVisibility)
                        {
                            this.weapon.GetNewRectangleCoordinates(this.player.GetWeaponStartCoordinates());
                        }

                        this.weapontVisibility = entity.GetWeaponState(); // Update current Bullet State
                    }

                    this.enemyArmy.GetBulletRectangle(this.weapon.Rectangle);

                    base.Update(gameTime);
                }
            }
        }

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
 
            this.GraphicsDevice.Clear(Color.WhiteSmoke);
            

            this.spriteBatch.Begin();

            this.spriteBatch.Draw(background, mainFrame, Color.White); // backgroud Load
            foreach (var entity in this.entities)
            {
                entity.Draw(this.spriteBatch);
            }

            if (this.isGamePaused)
            {
                this.spriteBatch.Draw(this.pausedTexture,
                    new Vector2((float)GraphicsConstants.ViewportWidth / 2 - (float)this.pausedTexture.Width / 2,
                        (float)GraphicsConstants.ViewportHeight / 2 - (float)this.pausedTexture.Height / 2),
                    Color.AliceBlue);
            }
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}