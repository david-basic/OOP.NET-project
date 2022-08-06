using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class ImageChange : Form
    {
        public ImageChange(PictureBox picture)
        {
            InitializeComponent();
            SetImage(picture);
        }

        private void SetImage(PictureBox picture)
        {
            imgImage.Image = picture.Image;
        }

        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Images|*.bmp;*.jpg;*.png|All files|*.*",
                InitialDirectory = Application.StartupPath
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imgImage.ImageLocation = ofd.FileName;
            }
        }

        public PictureBox GetNewImage()
        {
            return imgImage;
        }

        public string GetNewImagePath()
        {
            return imgImage.ImageLocation.Trim();
        }
    }
}
