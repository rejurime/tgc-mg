using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TGC.MG.Viewer.GameModel
{
    /// <summary>
    /// Animated sprite will handle the texture atlas, and take care of the drawing for us.
    /// </summary>
    public class TGCAnimatedSprite
    {
        // Texture stores the texture atlas for our animation.
        public Texture2D Texture { get; set; }
        // Rows is the number of rows in the atlas.
        public int Rows { get; set; }
        // Columns is the number of columns in the atlas.
        public int Columns { get; set; }
        // Frame of the animation we are currently on.
        private int CurrentFrame { get; set; }
        // How many frames there are total.
        private int TotalFrames { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TGCMG.Model.TGCAnimatedSprite"/> class.
        /// </summary>
        /// <param name="texture">Texture atlas for our animation.</param>
        /// <param name="rows">Rows is the number of rows in the atlas.</param>
        /// <param name="columns">Columns is the number of columns in the atlas.</param>
        public TGCAnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            TotalFrames = Rows * Columns;
        }

        /// <summary>
        /// Draw the specified part of the texture that is used in the current frame.
        /// </summary>
        /// <param name="spriteBatch">Sprite batch.</param>
        /// <param name="location">Location.</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //In this method, the first thing we need to do is determine which part of the texture we are going to draw to draw only the current frame.
            //So we start off by calculating the width and height of the frame.
            //We then need to calculate which row and column the current frame is located at.
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)CurrentFrame / (float)Columns);
            int column = CurrentFrame % Columns;

            // In the second section, we calculate a "source rectangle", which is a rectangle within the texture (the source) that we want to draw.
            // At this point, we also calculate a "destination rectangle" which is a rectangle that represents where the texture will be drawn.
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            // Finally, we draw the correct part of the texture on the screen with a call one of the SpriteBatch.Draw() methods.
            // This is a version of this method that we haven't seen yet, but takes a texture, a source rectangle, a destination rectangle, and a color.
            // This will draw only the part of the texture that is used in the current frame.
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        /// <summary>
        /// This simply increments the frame, and if it needs to start back over at the beginning, it does.
        /// </summary>
        public void Update()
        {
            CurrentFrame++;
            if (CurrentFrame == TotalFrames)
                CurrentFrame = 0;
        }
    }
}
