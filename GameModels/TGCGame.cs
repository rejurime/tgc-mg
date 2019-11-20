using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TGC.MG.Viewer.Cameras;

namespace TGC.MG.Viewer.GameModels
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TGCGame : Game
    {
        // The folder which the game will search for content.
        private const string ContentFolder = "Content";
        private const string ContentFolder2D = "2D/";
        private const string ContentFolder3D = "3D/";
        private const string ContentFolderEffect = "Effect/";
        private const string ContentFolderSpriteFonts = "SpriteFonts/";

        private SpriteBatch SpriteBatch { get; set; }
        private GraphicsDeviceManager Graphics { get; set; }

        private SpriteFont Font { get; set; }

        private ICamera Camera { get; set; }

        private Renderable RenderObject { get; set; }

        //https://github.com/rejurime/tgc-opentk/blob/master/TGC.OpenTK/Game.cs
        //https://github.com/rejurime/tgc-opentk/tree/master/TGC.OpenTK/Geometries
        //https://github.com/rejurime/tgc-opentk/tree/master/TGC.OpenTK/Shaders
        //-------
        /// <summary>
        /// Initializes a new instance of the <see cref="TGCGame"/> class.
        /// The main game constructor is used to initialize the starting variables.
        /// </summary>
        public TGCGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            //Graphics.IsFullScreen = true;
            Content.RootDirectory = ContentFolder;
            IsMouseVisible = true;
        }

        /// <summary>
        /// This method is called after the constructor, but before the main game loop (Update/Draw).
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where you can query any required services and load any non-graphic related content.
        /// Calling base.Initialize will enumerate through any components and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// This method is used to load your game content.
        /// It is called only once per game, after Initialize method, but before the main game loop methods.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            //TODO: use this.Content to load your game content here
            Font = Content.Load<SpriteFont>(ContentFolderSpriteFonts + "Score");

            var gameObject = new AGameObject();
            var model = Content.Load<Model>(ContentFolder3D + "tgcito/tgcito-classic");
            RenderObject = new Renderable(gameObject, model, GraphicsDevice);

            //Model2 = Content.Load<Model>(ContentFolder3D + "bb8/bb8");
            //Model3 = Content.Load<Model>(ContentFolder3D + "teapot");

            Camera = new StaticCamera(GraphicsDevice.Viewport.AspectRatio, (float)Math.PI / 4, 1, 200, new Vector3(1, -10, 0), Vector3.Zero);
            //Camera = new StaticCamera(GraphicsDevice.Viewport.AspectRatio, (float)Math.PI / 4, 1, 200, Vector3.Zero, -Vector3.UnitZ)
        }

        /// <summary>
        /// This method is called multiple times per second, and is used to update your game state
        /// (updating the world, checking for collisions, gathering input, playing audio, etc.).
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            /*
            if (kstate.IsKeyDown(Keys.Up))
                //_ballPosition.Y -= BallSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (kstate.IsKeyDown(Keys.Down))
                    //_ballPosition.Y += BallSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                    if (kstate.IsKeyDown(Keys.Left))
                        //_ballPosition.X -= BallSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                        if (kstate.IsKeyDown(Keys.Right))
                            //_ballPosition.X += BallSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            */

            RenderObject.GameObject.Coordinates += new Vector3(0, 0.5f, 0);
            RenderObject.GameObject.Rotation += new Vector3(0, 0.02f, 0);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// Similar to the Update method, it is also called multiple times per second.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            Graphics.GraphicsDevice.Clear(Color.Black);

            //TODO: Add your drawing code here
            SpriteBatch.Begin();
            SpriteBatch.DrawString(Font, "Probando el monito...", Vector2.Zero, Color.White);
            SpriteBatch.End();

            RenderObject.Draw(GraphicsDevice, Camera);

            base.Draw(gameTime);
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }
    }
}
