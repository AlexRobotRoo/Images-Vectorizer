using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace ImagesVectorizer
{
    public class ImagesVectorizer
    {
        private int VECTOR_IMAGE_ITEM_WIDTH_THRESHOLD, VECTOR_IMAGE_ITEM_HEIGHT_THRESHOLD;
        private float VECTOR_IMAGE_ITEM_RMS_THRESHOLD;

        private Color[][] rasterImagePixels;
        private List<Rectangle> vectorImageItems;

        public ImagesVectorizer()
        {
            VECTOR_IMAGE_ITEM_WIDTH_THRESHOLD = VECTOR_IMAGE_ITEM_HEIGHT_THRESHOLD = 2;
            VECTOR_IMAGE_ITEM_RMS_THRESHOLD = 6.0f;

            rasterImagePixels = null;
            vectorImageItems = new List<Rectangle>();
        }

        private bool IsItemDivisible(Rectangle _imagePart)
        {
            if (_imagePart.Width < VECTOR_IMAGE_ITEM_WIDTH_THRESHOLD || _imagePart.Height < VECTOR_IMAGE_ITEM_HEIGHT_THRESHOLD ||
                ImageUtilities.GetRMSError(rasterImagePixels, _imagePart) < VECTOR_IMAGE_ITEM_RMS_THRESHOLD)
                return false;

            return true;
        }

        private List<Rectangle> DivideIntoItems(Rectangle _imagePart)
        {
            List<Rectangle> imagePartItems = new List<Rectangle>();
            PointF imagePartGravityCenter = ImageUtilities.GetGravityCenter(rasterImagePixels, _imagePart);
            Point imagePartCenter = new Point();

            imagePartGravityCenter.X = 1.0f - 0.5f * (imagePartGravityCenter.X + 0.5f);
            imagePartGravityCenter.Y = 1.0f - 0.5f * (imagePartGravityCenter.Y + 0.5f);
            imagePartCenter.X = ((int)(imagePartGravityCenter.X * _imagePart.Width) & 0xFFFF) + _imagePart.X;
            imagePartCenter.Y = ((int)(imagePartGravityCenter.Y * _imagePart.Height) & 0xFFFF) + _imagePart.Y;

            imagePartItems.Add(new Rectangle(_imagePart.X, _imagePart.Y, imagePartCenter.X - _imagePart.X, imagePartCenter.Y - _imagePart.Y));
            imagePartItems.Add(new Rectangle(_imagePart.X, imagePartCenter.Y, imagePartCenter.X - _imagePart.X, _imagePart.Height - (imagePartCenter.Y - _imagePart.Y)));
            imagePartItems.Add(new Rectangle(_imagePart.X + (imagePartCenter.X - _imagePart.X), _imagePart.Y, _imagePart.Width - (imagePartCenter.X - _imagePart.X), imagePartCenter.Y - _imagePart.Y));
            imagePartItems.Add(new Rectangle(_imagePart.X + (imagePartCenter.X - _imagePart.X), imagePartCenter.Y, _imagePart.Width - (imagePartCenter.X - _imagePart.X), _imagePart.Height - (imagePartCenter.Y - _imagePart.Y)));

            return imagePartItems;
        }

        private void GetAllItemsRecursively(Rectangle _imagePart)
        {
            if (IsItemDivisible(_imagePart))
            {
                List<Rectangle> imagePartItems = DivideIntoItems(_imagePart);

                for (int i = 0; i < imagePartItems.Count; i++)
                    if (imagePartItems[i].Width < 1 || imagePartItems[i].Height < 1)
                        return;

                for (int i = 0; i < imagePartItems.Count; i++)
                    GetAllItemsRecursively(imagePartItems[i]);
            }
            else
            {
                vectorImageItems.Add(_imagePart);
            }
        }

        private void GenerateResultFile(string _vectorImageFullName)
        {
            string resultFileContents = string.Empty;

            resultFileContents += "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine;
            resultFileContents += string.Format("<svg version=\"1.1\" baseProfile=\"full\" xmlns=\"http://www.w3.org/2000/svg\" width=\"{0}\" height=\"{1}\">", rasterImagePixels[0].Length.ToString(), rasterImagePixels.Length.ToString()) + Environment.NewLine;
            resultFileContents += string.Join(Environment.NewLine, vectorImageItems.Select(currentItem =>
            {
                Color currentItemAverageColor = ImageUtilities.GetAverageColor(rasterImagePixels, currentItem);
                string currentItemAverageColorInHexFormat = "#" + currentItemAverageColor.R.ToString("x2") + currentItemAverageColor.G.ToString("x2") + currentItemAverageColor.B.ToString("x2");

                return string.Format("    <rect x=\"{0}\" y=\"{1}\" width=\"{2}\" height=\"{3}\" fill=\"{4}\" stroke=\"{5}\"/>",
                                     currentItem.X.ToString(), currentItem.Y.ToString(), currentItem.Width.ToString(), currentItem.Height.ToString(),
                                     currentItemAverageColorInHexFormat, currentItemAverageColorInHexFormat);
            }));
            resultFileContents += Environment.NewLine + "</svg>";

            File.WriteAllText(_vectorImageFullName, resultFileContents, Encoding.UTF8);
        }

        public void Process(string _rasterImageFullName, string _vectorImageFullName)
        {
            Bitmap sourceImage = (Bitmap)Image.FromFile(_rasterImageFullName);
            rasterImagePixels = ImageUtilities.GetPixels(sourceImage);
            
            vectorImageItems.Clear();

            GetAllItemsRecursively(new Rectangle(0, 0, sourceImage.Width, sourceImage.Height));
            GenerateResultFile(_vectorImageFullName);
        }
    }
}