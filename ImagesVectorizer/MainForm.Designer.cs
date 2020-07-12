namespace ImagesVectorizer
{
    public partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.btnOpenSourceImageAndConvert = new System.Windows.Forms.Button();
            this.gbxRasterImage = new System.Windows.Forms.GroupBox();
            this.wbRasterImage = new System.Windows.Forms.WebBrowser();
            this.gbxVectorImage = new System.Windows.Forms.GroupBox();
            this.wbVectorImage = new System.Windows.Forms.WebBrowser();
            this.ofdOpenSourceImage = new System.Windows.Forms.OpenFileDialog();
            this.gbxRasterImage.SuspendLayout();
            this.gbxVectorImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenSourceImageAndConvert
            // 
            this.btnOpenSourceImageAndConvert.Location = new System.Drawing.Point(12, 243);
            this.btnOpenSourceImageAndConvert.Name = "btnOpenSourceImageAndConvert";
            this.btnOpenSourceImageAndConvert.Size = new System.Drawing.Size(530, 37);
            this.btnOpenSourceImageAndConvert.TabIndex = 3;
            this.btnOpenSourceImageAndConvert.Text = "Открыть файл и преобразовать";
            this.btnOpenSourceImageAndConvert.UseVisualStyleBackColor = true;
            this.btnOpenSourceImageAndConvert.Click += new System.EventHandler(this.btnOpenFileAndConvert_Click);
            // 
            // gbxRasterImage
            // 
            this.gbxRasterImage.Controls.Add(this.wbRasterImage);
            this.gbxRasterImage.Location = new System.Drawing.Point(12, 12);
            this.gbxRasterImage.Name = "gbxRasterImage";
            this.gbxRasterImage.Size = new System.Drawing.Size(262, 225);
            this.gbxRasterImage.TabIndex = 0;
            this.gbxRasterImage.TabStop = false;
            this.gbxRasterImage.Text = "Растровое изображение";
            // 
            // wbRasterImage
            // 
            this.wbRasterImage.AllowWebBrowserDrop = false;
            this.wbRasterImage.Location = new System.Drawing.Point(6, 19);
            this.wbRasterImage.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbRasterImage.Name = "wbRasterImage";
            this.wbRasterImage.ScriptErrorsSuppressed = true;
            this.wbRasterImage.Size = new System.Drawing.Size(250, 200);
            this.wbRasterImage.TabIndex = 1;
            // 
            // gbxVectorImage
            // 
            this.gbxVectorImage.Controls.Add(this.wbVectorImage);
            this.gbxVectorImage.Location = new System.Drawing.Point(280, 12);
            this.gbxVectorImage.Name = "gbxVectorImage";
            this.gbxVectorImage.Size = new System.Drawing.Size(262, 225);
            this.gbxVectorImage.TabIndex = 2;
            this.gbxVectorImage.TabStop = false;
            this.gbxVectorImage.Text = "Векторное изображение";
            // 
            // wbVectorImage
            // 
            this.wbVectorImage.AllowWebBrowserDrop = false;
            this.wbVectorImage.Location = new System.Drawing.Point(6, 19);
            this.wbVectorImage.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbVectorImage.Name = "wbVectorImage";
            this.wbVectorImage.ScriptErrorsSuppressed = true;
            this.wbVectorImage.Size = new System.Drawing.Size(250, 200);
            this.wbVectorImage.TabIndex = 3;
            // 
            // ofdOpenSourceImage
            // 
            this.ofdOpenSourceImage.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            this.ofdOpenSourceImage.Filter = "Изображение PNG (*.png)|*.png|Изображение JPG (*.jpg)|*.jpg|Изображeние BMP (*.bmp)|*.bmp";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 288);
            this.Controls.Add(this.btnOpenSourceImageAndConvert);
            this.Controls.Add(this.gbxVectorImage);
            this.Controls.Add(this.gbxRasterImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Images Vectorizer";
            this.gbxRasterImage.ResumeLayout(false);
            this.gbxVectorImage.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Button btnOpenSourceImageAndConvert;
        private System.Windows.Forms.GroupBox gbxRasterImage;
        private System.Windows.Forms.GroupBox gbxVectorImage;
        private System.Windows.Forms.WebBrowser wbRasterImage;
        private System.Windows.Forms.WebBrowser wbVectorImage;
        private System.Windows.Forms.OpenFileDialog ofdOpenSourceImage;
    }
}

