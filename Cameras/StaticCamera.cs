using Microsoft.Xna.Framework;
using System;

namespace TGC.MG.Viewer.Cameras
{
    /// <summary>
    /// Camara estatica.
    /// </summary>
    public class StaticCamera : ICamera
    {
        /// <summary>
        /// Posicion de la camara.
        /// </summary>
        private Vector3 Position { get; }

        /// <summary>
        /// Posicion del punto al que mira la camara.
        /// </summary>
        private Vector3 LookAt { get; }

        /// <summary>
        /// Vector direccion hacia arriba (puede diferir si la camara se invierte).
        /// </summary>
        private Vector3 UpVector { get; }

        public Matrix ProjectionMatrix { get; set; }

        private float FieldOfView { get; }
        private float NearPlane { get; }
        private float FarPlane { get; }
        public Matrix ViewMatrix { get; }

        /// Configura la posicion de la camara, hacia donde apunta y cual es el vector arriba.
        /// </summary>
        /// <param name="pos">Posicion de la camara</param>
        /// <param name="lookAt">Punto hacia el cual se quiere ver</param>
        /// <param name="aspectRatio">Ancho dividido por la altura</param>
        /// <param name="upVector">Vector direccion hacia arriba</param>
        public StaticCamera(float aspectRatio, float fieldOfViewDegrees, float nearPlane, float farPlane, Vector3 position, Vector3 lookAt, Vector3 upVector)
        {
            FieldOfView = fieldOfViewDegrees;
            Position = position;
            LookAt = Vector3.Normalize(lookAt - position);
            ViewMatrix = Matrix.CreateLookAt(Position, LookAt, upVector);
            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(FieldOfView, aspectRatio, nearPlane, farPlane);
        }

        /// <summary>
        /// Configura la posicion de la camara, hacia donde apunta y con el vector arriba (0,1,0).
        /// </summary>
        /// <param name="pos">Posicion de la camara</param>
        /// <param name="lookAt">Punto hacia el cual se quiere ver</param>
        /// <param name="aspectRatio">Ancho dividido por la altura</param>
        /// <summary>
        public StaticCamera(float aspectRatio, float fieldOfViewDegrees, float nearPlane, float farPlane, Vector3 position, Vector3 lookAt) : this(aspectRatio, fieldOfViewDegrees, nearPlane, farPlane, position, lookAt, Vector3.UnitY)
        {
        }

        /// <summary>
        /// Devuelve la matriz View en base a los valores de la camara. Es invocado en cada update de render.
        /// </summary>
        public Matrix GetViewMatrix()
        {
            return Matrix.CreateLookAt(Position, LookAt, UpVector);
        }

        /*
        internal void UpdateFieldOfView(float aspectRatio)
        {
            projectionMatrix = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, aspectRatio, 1.0f, 64.0f);
            //TODO MatrixMode deprecated in 3.2
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projectionMatrix);
        }

        internal void UpdateModelView()
        {
            Matrix4 modelview = GetViewMatrix();
            //TODO deprecated in v3.2
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
        }
        */
    }
}