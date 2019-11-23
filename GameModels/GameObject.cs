using Microsoft.Xna.Framework;

namespace TGC.MG.Viewer.GameModels
{
    public class GameObject

    //public abstract class GameObject
    {
        public Vector3 Coordinates;
        public Vector3 Rotation;
        public Vector3 Velocity;
        public float Scale;

        public GameObject()
        {
            Coordinates = Vector3.Zero;
            Rotation = Vector3.Zero;
            Velocity = Vector3.Zero;
            Scale = 1f;
        }

        public GameObject(Vector3 coordinates, Vector3 rotation, Vector3 velocity, float scale)
        {
            Coordinates = coordinates;
            Rotation = rotation;
            Velocity = velocity;
            Scale = scale;
        }
    }
}
