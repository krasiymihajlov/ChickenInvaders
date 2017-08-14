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
    using Space_Invaders.Common.Constants.Weapons;
    using Space_Invaders.Interfaces.Core;
    using Space_Invaders.Interfaces.IO.InputCommands;
    using Space_Invaders.Interfaces.Models.Players;
    using Space_Invaders.Interfaces.Models.Weapons;
    using Space_Invaders.IO.InputCommands;
    using Space_Invaders.Models.Players;
    using System.Collections.Generic;

    public class Engine : Game, IEngine
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private List<IEntity> entities;
        private IPlayer player;
        private IWeapon weapon;
        private IInitializer initializer;
        private IInputCommand inputCommand;
        private IEnemyArmy enemyArmy;
        private bool weapontVisibility;

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

            this.inputCommand.KeyPressed += this.player.OnKeyPressed;

            this.weapon = new Bullet(0, 0, new Rectangle(this.player.Rectangle.X, this.player.Rectangle.Y,
                WeaponConstants.WeaponWidth, WeaponConstants.WeaponHeight));

            //this.player.LoadWeapon(this.Content, GraphicsDevice, "Pictures/Bulet");

            this.enemyArmy = new InvaderArmy();


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
            this.entities = new List<IEntity> { this.player, this.weapon, this.enemyArmy };

            //var viewWidth= this.GraphicsDevice.Viewport.Width;

            this.player.Load(this.Content, this.GraphicsDevice, "Pictures/Ship1");
            this.weapon.Load(this.Content, this.GraphicsDevice, "Pictures/Bulet");
            this.enemyArmy.Load(this.Content, this.GraphicsDevice, "Pictures/Enemy2");

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
                entity.SendWeaponState(this.weapontVisibility);    //Give the bool param 
                entity.Update(gameTime, currentKeyboardState);   // Update Player

                if (currentKeyboardState.IsKeyDown(Keys.Space) && this.weapontVisibility)
                {
                    this.weapon.GetNewRectangleCoordinates(this.player.GetWeaponStartCoordinates());
                }
                
                this.weapontVisibility = entity.GetWeaponState();  // Update current Bullet State
            }

            this.enemyArmy.GetBulletRectangle(this.weapon.Rectangle);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.WhiteSmoke);

            this.spriteBatch.Begin();
            foreach (var entity in this.entities)
            {
                entity.Draw(this.spriteBatch);
            }

            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
