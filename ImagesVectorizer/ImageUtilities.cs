using System;
using System.Collections.Generic;
using System.Drawing;

namespace ImagesVectorizer
{
    public static class ImageUtilities
    {
        public static Color[][] GetPixels(Bitmap _sourceImage)
        {
            Color[][] pixels = new Color[_sourceImage.Height][];
            for (int i = 0; i < pixels.Length; i++)
                pixels[i] = new Color[_sourceImage.Width];

            for (int i = 0; i < _sourceImage.Height; i++)
                for (int j = 0; j < _sourceImage.Width; j++)
                    pixels[i][j] = _sourceImage.GetPixel(j, i);

            return pixels;
        }

        private static Color[] GetPixels(Color[][] _sourceImagePixels, Rectangle _imagePart)
        {
            List<Color> pixels = new List<Color>();

            for (int i = _imagePart.Top; i < _imagePart.Bottom; i++)
                for (int j = _imagePart.Left; j < _imagePart.Right; j++)
                    pixels.Add(_sourceImagePixels[i][j]);

            return pixels.ToArray();
        }

        public static PointF GetGravityCenter(Color[][] _sourceImagePixels, Rectangle _imagePart)
        {
            PointF gravityCenter = new PointF();
            float averageIntensity = 0.0f;
            Color[] subimagePixels = GetPixels(_sourceImagePixels, _imagePart);

            for (int i = 0; i < subimagePixels.Length; i++)
            {
                float currentPixelIntensity = (subimagePixels[i].R + subimagePixels[i].B + 2.0f * subimagePixels[i].G) / 1024.0f;

                averageIntensity += currentPixelIntensity;
                gravityCenter.X += currentPixelIntensity * ((float)i % _imagePart.Width);
                gravityCenter.Y += currentPixelIntensity * ((float)i / _imagePart.Width);
            }

            gravityCenter.X /= averageIntensity;
            gravityCenter.Y /= averageIntensity;
            gravityCenter.X /= _imagePart.Width;
            gravityCenter.Y /= _imagePart.Height;

            return gravityCenter;
        }

        public static float GetRMSError(Color[][] _sourceImagePixels, Rectangle _imagePart)
        {
            float rms = 0.0f;
            float averageGreenColorIntensity = 0.0f;
            Color[] subimagePixels = GetPixels(_sourceImagePixels, _imagePart);

            for (int i = 0; i < subimagePixels.Length; i++)
                averageGreenColorIntensity += subimagePixels[i].G;

            averageGreenColorIntensity /= subimagePixels.Length;

            for (int i = 0; i < subimagePixels.Length; i++)
                rms += (float)Math.Pow((double)subimagePixels[i].G - averageGreenColorIntensity, 2.0);

            rms /= subimagePixels.Length;

            return (float)Math.Sqrt(rms);
        }

        public static Color GetAverageColor(Color[][] _sourceImagePixels, Rectangle _imagePart)
        {
            int averageRedColor = 0, averageGreenColor = 0, averageBlueColor = 0;
            Color[] subimagePixels = GetPixels(_sourceImagePixels, _imagePart);

            for (int i = 0; i < subimagePixels.Length; i++)
            {
                averageRedColor += subimagePixels[i].R;
                averageGreenColor += subimagePixels[i].G;
                averageBlueColor += subimagePixels[i].B;
            }

            averageRedColor /= subimagePixels.Length;
            averageGreenColor /= subimagePixels.Length;
            averageBlueColor /= subimagePixels.Length;

            return Color.FromArgb(averageRedColor, averageGreenColor, averageBlueColor);
        }
    }
}