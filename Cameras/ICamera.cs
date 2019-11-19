using Microsoft.Xna.Framework;

namespace TGC.MG.Viewer.Cameras
{
    public interface ICamera
    {
        Matrix ViewMatrix { get; }
        Matrix ProjectionMatrix { get; }
        //void Update(GameTime gameTime);
    }
}
