using Space_Invaders.Interfaces.Globals;
using Space_Invaders.Interfaces.Models.Enemies;
using Space_Invaders.Models.Enimies;
using Space_Invaders.Models.Weapons;

namespace Space_Invaders.Core
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Space_Invaders.Common.Constants.Entities;
    using Space_Invaders.Common.Constants.Graphics;
    using Space_Invaders.Interfaces.Core;
    using Space_Invaders.Interfaces.IO.InputCommands;
    using Space_Invaders.Interfaces.Models.Players;
    using Space_Invaders.IO.InputCommands;
    using Space_Invaders.Models.Players;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Engine : Game, IEngine
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private List<IEntity> entities;
        private IPlayer player;
        private IInitializer initializer;
        private IInputCommand inputCommand;
        private IEnemyArmy enemyArmy;

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
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // MUST BE DONE FROM HERE
            this.player = new Exterminator(EntityConstants.ShipXStartCoordinates, 
                EntityConstants.ShipYStartCoordinates, "R21");

            this.player.Load(this.Content, this.GraphicsDevice, "Pictures/Ship1");
            this.inputCommand.KeyPressed += this.player.OnKeyPressed;

            this.player.LoadWeapon(this.Content, GraphicsDevice, "Pictures/Bulet");

            this.enemyArmy = new InvaderArmy(3, 4);
            // TO HERE

            //this.initializer.SetGameMouse(this, GraphicsConstants.IS_MOUSE_VISIBLE);
            //this.initializer.SetGraphicsWindowSize(this.graphics,
            //                                       GraphicsConstants.PREFFER_BUFFER_WIDTH,
            //                                       GraphicsConstants.PREFFER_BUFFER_HEIGHT);

            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            entities = new List<IEntity> {this.player};

            enemyArmy.Load(this.Content, this.GraphicsDevice, "Pictures/Enemy2");
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
            KeyboardState currentKeyboardState = Keyboard.GetState();
            this.inputCommand.GetKeyboardState(currentKeyboardState, gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || currentKeyboardState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach (var entity in entities)
            {
                entity.Update(gameTime, currentKeyboardState);
            }

            enemyArmy.Update(gameTime, currentKeyboardState);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.WhiteSmoke);

            // TODO: Add your drawing code here
            this.spriteBatch.Begin();
            foreach (var entity in entities)
            {
                entity.Draw(this.spriteBatch);
            }

            enemyArmy.Draw(spriteBatch);

            this.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
