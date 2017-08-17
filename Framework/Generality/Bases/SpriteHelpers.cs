using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Framework.Generality.Bases
{
    public class SpriteHelpers
    {
        public SpriteHelpers()
        {

        }
        public Texture2D TranspatentSprite(GraphicsDevice device, Texture2D source, int width, int height, Color transparentColor)
        {
            Texture2D result = new Texture2D(device, width, height);

            int totalPixels = width * height;
            Color[] data = new Color[totalPixels];

            source.GetData<Color>(data);

            for (int i = 0; i < totalPixels; i++)
            {
                if (data[i] == transparentColor)
                {
                    data[i] = new Color(0, 0, 0, 0);
                }
            }
            result.SetData<Color>(data);
            return result;
        }
    }
}
