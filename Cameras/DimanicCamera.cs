using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TGC.MG.Viewer.Cameras
{
    public class DimanicCamera : StaticCamera
    {
        public void setLookAt(Vector3 aLookAt)
        {
            LookAt = aLookAt;
            //Hardcoder
            ViewMatrix = Matrix.CreateLookAt(Position, LookAt, Vector3.UnitY);
        }

        public Vector3 getLookAt()
        {
            return LookAt;
        }

        public void setPosition(Vector3 aPosition)
        {
            Position = aPosition;
            //Hardcoder
            ViewMatrix = Matrix.CreateLookAt(Position, LookAt, Vector3.UnitY);
        }

        public Vector3 getPosition()
        {
            return Position;
        }

        /// Configura la posicion de la camara, hacia donde apunta y cual es el vector arriba.
        /// </summary>
        /// <param name="pos">Posicion de la camara</param>
        /// <param name="lookAt">Punto hacia el cual se quiere ver</param>
        /// <param name="aspectRatio">Ancho dividido por la altura</param>
        /// <param name="upVector">Vector direccion hacia arriba</param>
        public DimanicCamera(float aspectRatio, float fieldOfViewDegrees, float nearPlane, float farPlane, Vector3 position, Vector3 lookAt, Vector3 upVector)
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
        public DimanicCamera(float aspectRatio, float fieldOfViewDegrees, float nearPlane, float farPlane, Vector3 position, Vector3 lookAt) : this(aspectRatio, fieldOfViewDegrees, nearPlane, farPlane, position, lookAt, Vector3.UnitY)
        {
        }

    }
}
