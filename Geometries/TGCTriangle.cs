using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TGC.MG.Viewer.Cameras;
using TGC.MG.Viewer.GameModels;

namespace TGC.MG.Viewer.Geometries
{
    public class TGCTriangle
    {
        /// <summary>
		/// Array of vertex positions and colors.
		/// </summary>
        VertexPositionColor[] Verts { get; set; }
        BasicEffect Effect { get; set; }
        VertexBuffer Buffer { get; set; }

		public TGCTriangle(GraphicsDevice device, Vector3 vertice1, Vector3 vertice2, Vector3 vertice3, Color colorVertice): this(device, vertice1, colorVertice, vertice2, colorVertice, vertice3, colorVertice)
		{
        }

        public TGCTriangle(GraphicsDevice device, Vector3 vertice1, Color colorVertice1, Vector3 vertice2, Color colorVertice2, Vector3 vertice3, Color colorVertice3)
		{
            var vertsSize = 3;
            this.Verts = new VertexPositionColor[vertsSize];
            this.Verts[0].Position = vertice1;
            this.Verts[0].Color = colorVertice1;
            this.Verts[1].Position = vertice2;
            this.Verts[1].Color = colorVertice2;
            this.Verts[2].Position = vertice3;
            this.Verts[2].Color = colorVertice3;

            this.Effect = new BasicEffect(device);

            this.Buffer = new VertexBuffer(device, VertexPositionColor.VertexDeclaration, vertsSize, BufferUsage.WriteOnly);
            this.Buffer.SetData(this.Verts);
		}

        public void Draw(GraphicsDevice graphicsDevice, ICamera camera)
        {
            this.Effect.Projection = camera.ProjectionMatrix;
            this.Effect.View = camera.ViewMatrix;
            this.Effect.World = Matrix.Identity;
            this.Effect.VertexColorEnabled = true;

            foreach (var pass in Effect.CurrentTechnique.Passes)
			{
				pass.Apply ();

				graphicsDevice.DrawUserPrimitives (
					// We’ll be rendering one triangles
					PrimitiveType.TriangleList,
					// The array of verts that we want to render
					this.Verts,
					// The offset, which is 0 since we want to start at the beginning of the floorVerts array
					0,
					// The number of triangles to draw
					1);
			}
        }
    }
}
