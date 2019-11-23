using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TGC.MG.Viewer.Cameras;

namespace TGC.MG.Viewer.GameModels
{
    public class Renderable
    {
        public Model Model;
        public BasicEffect BasicEffect;
        public GameObject GameObject;

        public Renderable(GameObject gameObject, Model model, GraphicsDevice graphicsDevice)
        {
            GameObject = gameObject;
            Model = model;

            BasicEffect = new BasicEffect(graphicsDevice)
            {
                AmbientLightColor = Vector3.One,
                DiffuseColor = Vector3.One,
                SpecularColor = Vector3.One,
                LightingEnabled = true
            };
        }

        public void Draw(GraphicsDevice graphicsDevice, ICamera camera)
        {
            var t2 = Matrix.CreateTranslation(GameObject.Coordinates.X, GameObject.Coordinates.Y, GameObject.Coordinates.Z);
            var r1 = Matrix.CreateRotationX(GameObject.Rotation.X);
            var r2 = Matrix.CreateRotationY(GameObject.Rotation.Y);
            var r3 = Matrix.CreateRotationZ(GameObject.Rotation.Z);
            var s = Matrix.CreateScale(GameObject.Scale);

            var world = r1 * r2 * r3 * s * t2;

            /*
            BasicEffect.World = r1 * r2 * r3 * s * t2;
            BasicEffect.View = camera.ViewMatrix;
            BasicEffect.Projection = camera.ProjectionMatrix;

            BasicEffect.EnableDefaultLighting();

            foreach (var pass in BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                DrawModel(Model, world, view, projection);
                //DrawModelWithEffect(Model, world, view, projection);
            }*/

            //position += new Vector3(0, 10f, 0);
            //angle += 0.02f;
            //world = Matrix.CreateRotationY(angle) * Matrix.CreateTranslation(position);

            DrawModel(Model, world, camera.ViewMatrix, camera.ProjectionMatrix);
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

        /*
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
        }*/
    }
}
