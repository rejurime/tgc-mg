using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TGC.MG.Viewer.Cameras;
using TGC.MG.Viewer.Geometries;

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

        private RenderableModel RenderObject { get; set; }
        private RenderableModel RenderObject2 { get; set; }
        private RenderableModel RenderObject3 { get; set; }
        private TGCTriangle Triangle { get; set; }
        private TGCTriangle Triangle2 { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TGCGame"/> class.
        /// The main game constructor is used to initialize the starting variables.
        /// </summary>
        public TGCGame()
        {
            this.Graphics = new GraphicsDeviceManager(this);
            //Graphics.IsFullScreen = true;
            this.Content.RootDirectory = ContentFolder;
            this.IsMouseVisible = true;
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
            this.SpriteBatch = new SpriteBatch(this.GraphicsDevice);

            //TODO: use this.Content to load your game content here
            this.Font = this.Content.Load<SpriteFont>(ContentFolderSpriteFonts + "Score");

            var gameObject = new GameObject(new Vector3(50, 0, 50), Vector3.Zero, Vector3.Zero, 0.5f);
            var model = this.Content.Load<Model>(ContentFolder3D + "tgcito/tgcito-classic");
            this.RenderObject = new RenderableModel(gameObject, model, this.GraphicsDevice);

            var model2 = this.Content.Load<Model>(ContentFolder3D + "bb8/bb8");
            this.RenderObject2 = new RenderableModel(model2, this.GraphicsDevice);
            this.RenderObject2.GameObject.Scale = 0.25f;
            this.RenderObject2.GameObject.Coordinates = new Vector3(-20, 20, 40);
            this.RenderObject2.GameObject.Rotation = Vector3.UnitZ;

            var gameObject3 = new GameObject(new Vector3(-50, 0, -50), new Vector3(0, MathHelper.PiOver2, 0), Vector3.Zero, 10);
            var model3 = this.Content.Load<Model>(ContentFolder3D + "teapot");
            this.RenderObject3 = new RenderableModel(gameObject3, model3, this.GraphicsDevice);

            this.Triangle = new TGCTriangle(this.GraphicsDevice, new Vector3(-40f, -40f, 40f), new Vector3(40f, 40f, 40f), new Vector3(0f, 40f, 40f), Color.DarkBlue);
            this.Triangle2 = new TGCTriangle(this.GraphicsDevice, new Vector3(-30f, -30f, 30f), Color.Blue, new Vector3(30f, 30f, 30f), Color.Red, new Vector3(0f, 30f, 30f), Color.Green);

            this.Camera = new StaticCamera(this.GraphicsDevice.Viewport.AspectRatio, MathHelper.PiOver4, 1, 300, new Vector3(100, 200, 10), Vector3.Zero);
        }

        /// <summary>
        /// This method is called multiple times per second, and is used to update your game state
        /// (updating the world, checking for collisions, gathering input, playing audio, etc.).
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Escape))
                this.Exit();

            if (kstate.IsKeyDown(Keys.Up))
                this.RenderObject.GameObject.Coordinates -= new Vector3(25, 0, 0) * (float)gameTime.ElapsedGameTime.TotalSeconds;
            // Vale la pena agregar Speed a GameObject? ObjectSpeed

            if (kstate.IsKeyDown(Keys.Down))
                this.RenderObject.GameObject.Coordinates += new Vector3(25, 0, 0) * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Space))
                this.RenderObject.GameObject.Coordinates += new Vector3(0, 10, 0) * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                this.RenderObject.GameObject.Rotation += Vector3.Up * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                this.RenderObject.GameObject.Rotation -= Vector3.Up * (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// Similar to the Update method, it is also called multiple times per second.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);
            //Graphics.GraphicsDevice.Clear(Color.Black);

            //TODO: Add your drawing code here
            this.SpriteBatch.Begin();
            this.SpriteBatch.DrawString(this.Font, "Probando el monito...", Vector2.Zero, Color.White);
            this.SpriteBatch.End();

            this.RenderObject.Draw(this.GraphicsDevice, this.Camera);
            this.RenderObject2.Draw(this.GraphicsDevice, this.Camera);
            this.RenderObject3.Draw(this.GraphicsDevice, this.Camera);

            this.Triangle.Draw(this.GraphicsDevice, this.Camera);
            this.Triangle2.Draw(this.GraphicsDevice, this.Camera);

            base.Draw(gameTime);
        }

        protected override void UnloadContent()
        {
            this.Content.Unload();
        }
    }
}
