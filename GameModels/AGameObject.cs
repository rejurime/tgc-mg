using Microsoft.Xna.Framework;

namespace TGC.MG.Viewer.GameModels
{
    public class AGameObject

    //public abstract class AGameObject
    {
        public Vector3 Coordinates;
        public Vector3 Rotation;
        public Vector3 Velocity;
        public float Scale;

        public AGameObject()
        {
            Coordinates = Vector3.Zero;
            Rotation = Vector3.Zero;
            Velocity = Vector3.Zero;
            Scale = 1f;
        }

        public AGameObject(Vector3 coordinates, Vector3 rotation, Vector3 velocity, float scale)
        {
            Coordinates = coordinates;
            Rotation = rotation;
            Velocity = velocity;
            Scale = scale;
        }
    }
}
