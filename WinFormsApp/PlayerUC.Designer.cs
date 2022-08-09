namespace WinFormsApp
{
    partial class PlayerUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerUC));
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblShirtNumber = new System.Windows.Forms.Label();
            this.imgPlayer = new System.Windows.Forms.PictureBox();
            this.lblChangeImage = new System.Windows.Forms.Label();
            this.imgCaptain = new System.Windows.Forms.PictureBox();
            this.imgFavourite = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCaptain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFavourite)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPosition
            // 
            resources.ApplyResources(this.lblPosition, "lblPosition");
            this.lblPosition.Name = "lblPosition";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // lblShirtNumber
            // 
            resources.ApplyResources(this.lblShirtNumber, "lblShirtNumber");
            this.lblShirtNumber.Name = "lblShirtNumber";
            // 
            // imgPlayer
            // 
            resources.ApplyResources(this.imgPlayer, "imgPlayer");
            this.imgPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgPlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgPlayer.Name = "imgPlayer";
            this.imgPlayer.TabStop = false;
            this.imgPlayer.Click += new System.EventHandler(this.ImgPlayer_Click);
            // 
            // lblChangeImage
            // 
            resources.ApplyResources(this.lblChangeImage, "lblChangeImage");
            this.lblChangeImage.BackColor = System.Drawing.Color.Transparent;
            this.lblChangeImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChangeImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblChangeImage.Name = "lblChangeImage";
            // 
            // imgCaptain
            // 
            resources.ApplyResources(this.imgCaptain, "imgCaptain");
            this.imgCaptain.Name = "imgCaptain";
            this.imgCaptain.TabStop = false;
            // 
            // imgFavourite
            // 
            resources.ApplyResources(this.imgFavourite, "imgFavourite");
            this.imgFavourite.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.imgFavourite.Name = "imgFavourite";
            this.imgFavourite.TabStop = false;
            // 
            // PlayerUC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblChangeImage);
            this.Controls.Add(this.imgFavourite);
            this.Controls.Add(this.imgCaptain);
            this.Controls.Add(this.imgPlayer);
            this.Controls.Add(this.lblShirtNumber);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblPosition);
            this.Name = "PlayerUC";
            this.Load += new System.EventHandler(this.PlayerUC_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PlayerUC_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCaptain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFavourite)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblShirtNumber;
        private System.Windows.Forms.PictureBox imgPlayer;
        private System.Windows.Forms.Label lblChangeImage;
        private System.Windows.Forms.PictureBox imgCaptain;
        private System.Windows.Forms.PictureBox imgFavourite;
    }
}
