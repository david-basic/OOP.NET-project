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
    public partial class PlayerUC : UserControl
    {
        Bitmap emptyStar = Properties.ResourcesImages.emptyStar;
        Bitmap fullStar = Properties.ResourcesImages.fullStar;
        Bitmap captain = Properties.ResourcesImages.captain;
        Bitmap defaultImage = Properties.ResourcesImages.defaultPlayer;

        private List<string> imagePath = new List<string>();
        private Dictionary<string, string> namePathCollection = new Dictionary<string, string>();

        string filePathImagesPaths = $"{Application.StartupPath}/MyAppFiles/ImagesPaths.txt";

        public string FullName { get; set; }
        public bool Captain { get; set; }
        public long ShirtNumber { get; set; }
        public string Position { get; set; }
        public bool Favourite { get; set; }

        public PlayerUC()
        {
            InitializeComponent();
        }

        public PlayerUC(string fullName, bool captain, long shirtNumber, string position, bool favourite)
        {
            InitializeComponent();

            FullName = fullName;
            Captain = captain;
            ShirtNumber = shirtNumber;
            Position = position;
            Favourite = favourite;
        }

        private void PlayerUC_Load(object sender, EventArgs e)
        {
            if (Captain)
            {
                imgCaptain.Image = captain;
            }
            else
            {
                imgCaptain.Image = null;
            }

            lblShirtNumber.Text = ShirtNumber.ToString();
            lblName.Text = FullName;
            lblPosition.Text = Position;

            if (Favourite)
            {
                imgFavourite.Image = fullStar;
            }
            else
            {
                imgFavourite.Image = emptyStar;
            }

            if (File.Exists(filePathImagesPaths))
            {
                string[] tempPathsCollection = File.ReadAllLines(filePathImagesPaths);
                tempPathsCollection.ToList().ForEach(p => namePathCollection.Add(p.Split('|')[1], p.Split('|')[0]));

                foreach (var item in namePathCollection)
                {
                    if (item.Key == FullName)
                    {
                        imgPlayer.ImageLocation = item.Value;
                    }
                    else
                    {
                        imgPlayer.Image = defaultImage;
                    }
                }
            }
        }

        private void ImgPlayer_Click(object sender, EventArgs e)
        {
            PictureBox image = sender as PictureBox;

            ChangeImage(image);
        }

        private void ChangeImage(PictureBox image)
        {
            Bitmap oldImage = (Bitmap)imgPlayer.Image;
            var imageChanging = new ImageChange(image);

            imageChanging.StartPosition = FormStartPosition.CenterScreen;

            if (imageChanging.ShowDialog() == DialogResult.OK)
            {
                PictureBox newImage = imageChanging.GetNewImage();
                imgPlayer.Image = newImage.Image;

                string newImgLocation = imageChanging.GetNewImagePath();

                // !!!!
                // WIP u VSCode imas natuknice sto i kako
                // !!!!
                if (newImgLocation != null)
                {
                    if (imgPlayer.Image != oldImage)
                    {
                        if (File.Exists(filePathImagesPaths))
                        {
                            string[] temPathsCollection = File.ReadAllLines(filePathImagesPaths);
                            temPathsCollection.ToList().ForEach(p => imagePath.Add(p));
                            imagePath.Add($"{Path.GetFullPath(imageChanging.GetNewImagePath())}|{FullName}");
                            SaveToFile(filePathImagesPaths, imagePath);
                        }
                        else
                        {
                            imagePath.Add($"{Path.GetFullPath(imageChanging.GetNewImagePath())}|{FullName}");
                            SaveToFile(filePathImagesPaths, imagePath);
                        }
                    }
                }
                // !!!!
            }
        }

        private void PlayerUC_Paint(object sender, PaintEventArgs e)
        {
            if (Favourite)
            {
                imgFavourite.Image = fullStar;
            }
            else
            {
                imgFavourite.Image = emptyStar;
            }
        }

        private void SaveToFile(string path, List<string> content)
        {
            FileInfo file = new FileInfo(path);
            file.Directory.Create();
            File.WriteAllLines(file.FullName, content);
        }

        public override bool Equals(object obj)
        {
            return obj is PlayerUC uC &&
                   FullName == uC.FullName &&
                   ShirtNumber == uC.ShirtNumber;
        }

        public override int GetHashCode()
        {
            int hashCode = 1319128817;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullName);
            hashCode = hashCode * -1521134295 + ShirtNumber.GetHashCode();
            return hashCode;
        }
    }
}
