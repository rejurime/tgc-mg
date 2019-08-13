using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TGC.MG.Viewer.GameModel
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

        private Matrix world = Matrix.CreateTranslation(Vector3.Zero);
        private Matrix view = Matrix.CreateLookAt(new Vector3(0, 400, 400), Vector3.Zero, Vector3.UnitY);
        private Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 1f, 600f);

        private Model Model { get; set; }

        private Vector3 position;
        private float angle;

        private Effect Effect { get; set; }

        private Model Model2 { get; set; }

        private Model Model3 { get; set; }

        private Vector3 position2;

        /// <summary>
        /// Initializes a new instance of the <see cref="TTGC.MG.Viewer.GameModel.TGCGame"/> class.
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

            Model = Content.Load<Model>(ContentFolder3D + "tgcito/tgcito-classic");
            Model2 = Content.Load<Model>(ContentFolder3D + "bb8/bb8");
            Model3 = Content.Load<Model>(ContentFolder3D + "teapot");
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

            if (kstate.IsKeyDown(Keys.Up))
                //_ballPosition.Y -= BallSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Down))
                //_ballPosition.Y += BallSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                //_ballPosition.X -= BallSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                //_ballPosition.X += BallSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += new Vector3(0, 10f, 0);
            angle += 0.02f;
            world = Matrix.CreateRotationY(angle) * Matrix.CreateTranslation(position);

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

            //DrawModel(Model, world, view, projection);
            //DrawModelWithEffect(model, world, view, projection);
            //DrawModel(Model2, world, view, projection);
            DrawModel(Model3, world, view, projection);

            base.Draw(gameTime);
        }

        private void DrawModel(Model model, Matrix world, Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;
                }

                mesh.Draw();
            }
        }

        private void DrawModelWithEffect(Model model, Matrix world, Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (ModelMeshPart part in mesh.MeshParts)
                {
                    part.Effect = Effect;
                    Effect.Parameters["World"].SetValue(world * mesh.ParentBone.Transform);
                    Effect.Parameters["View"].SetValue(view);
                    Effect.Parameters["Projection"].SetValue(projection);
                }
                mesh.Draw();
            }
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }
    }
}
