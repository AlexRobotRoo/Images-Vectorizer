using System;
using System.IO;
using System.Windows.Forms;

namespace ImagesVectorizer
{
    public partial class frmMain : Form
    {
        private ImagesVectorizer imagesVectorizer;

        public frmMain()
        {
            InitializeComponent();

            imagesVectorizer = new ImagesVectorizer();
        }

        private void btnOpenFileAndConvert_Click(object sender, EventArgs e)
        {
            if (ofdOpenSourceImage.ShowDialog() == DialogResult.OK)
            {
                string sourceImageFullName = ofdOpenSourceImage.FileName;
                string resultImageFullName = Path.Combine(Path.GetDirectoryName(ofdOpenSourceImage.FileName), Path.GetFileNameWithoutExtension(ofdOpenSourceImage.FileName) + ".svg");

                imagesVectorizer.Process(sourceImageFullName, resultImageFullName);

                wbRasterImage.Navigate(sourceImageFullName);
                wbVectorImage.Navigate(resultImageFullName);
            }
        }
    }
}
