using Microsoft.Xna.Framework;
using System;

namespace TGC.MG.Viewer.Cameras
{
    /// <summary>
    /// Camara estatica. http://dreamstatecoding.blogspot.com/2019/03/monogame-static-camera-tutorial-and-code.html
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

        /// <summary>
        /// Configura la posicion de la camara, hacia donde apunta y con el vector arriba (0,1,0).
        /// </summary>
        /// <param name="pos">Posicion de la camara</param>
        /// <param name="lookAt">Punto hacia el cual se quiere ver</param>
        public StaticCamera(Vector3 pos, Vector3 lookAt, float aspectRatio) : this(pos, lookAt, aspectRatio, Vector3.UnitY)
        {
        }

        /// <summary>
        /// Configura la posicion de la camara, hacia donde apunta y cual es el vector arriba.
        /// </summary>
        /// <param name="pos">Posicion de la camara</param>
        /// <param name="lookAt">Punto hacia el cual se quiere ver</param>
        /// <param name="upVector">Vector direccion hacia arriba</param>
        public StaticCamera(Vector3 pos, Vector3 lookAt, float aspectRatio, Vector3 upVector)
        {
            Position = pos;
            LookAt = lookAt;
            UpVector = upVector;
            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView((float)Math.PI / 4, aspectRatio, 1, 100);
        }

        public StaticCamera(float aspectRatio, float fieldOfViewDegrees, float nearPlane, float farPlane)
    : this(aspectRatio, fieldOfViewDegrees, nearPlane, farPlane, Vector3.Zero, -Vector3.UnitZ)
        { }

        public StaticCamera(float aspectRatio, float fieldOfViewDegrees, float nearPlane, float farPlane, Vector3 position, Vector3 target)
        {
            FieldOfView = fieldOfViewDegrees * 0.0174532925f;
            Position = position;
            LookAt = Vector3.Normalize(target - position);
            ViewMatrix = Matrix.CreateLookAt(Position, LookAt, Vector3.Up);
            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(FieldOfView, aspectRatio, nearPlane, farPlane);
        }

        /// <summary>
        /// Devuelve la matriz View en base a los valores de la camara. Es invocado en cada update de render.
        /// </summary>
        public Matrix GetViewMatrix()
        {
            return Matrix.CreateLookAt(Position, LookAt, UpVector);
        }

        internal void UpdateFieldOfView(float aspectRatio)
        {
            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView((float)Math.PI / 4, aspectRatio, 1.0f, 64.0f);
        }

        internal void UpdateModelView()
        {
            Matrix modelview = GetViewMatrix();
        }
    }
}
