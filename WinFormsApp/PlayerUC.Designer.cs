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
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(6, 371);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(291, 21);
            this.lblPosition.TabIndex = 0;
            this.lblPosition.Text = "Forward";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(4, 346);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(295, 25);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "FullNamePlaceholder";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShirtNumber
            // 
            this.lblShirtNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShirtNumber.Location = new System.Drawing.Point(108, 285);
            this.lblShirtNumber.Name = "lblShirtNumber";
            this.lblShirtNumber.Size = new System.Drawing.Size(87, 61);
            this.lblShirtNumber.TabIndex = 2;
            this.lblShirtNumber.Text = "99";
            this.lblShirtNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgPlayer
            // 
            this.imgPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgPlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgPlayer.Image = ((System.Drawing.Image)(resources.GetObject("imgPlayer.Image")));
            this.imgPlayer.Location = new System.Drawing.Point(52, 20);
            this.imgPlayer.Name = "imgPlayer";
            this.imgPlayer.Size = new System.Drawing.Size(200, 250);
            this.imgPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPlayer.TabIndex = 3;
            this.imgPlayer.TabStop = false;
            this.imgPlayer.Click += new System.EventHandler(this.ImgPlayer_Click);
            // 
            // lblChangeImage
            // 
            this.lblChangeImage.BackColor = System.Drawing.Color.Transparent;
            this.lblChangeImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChangeImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblChangeImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeImage.Location = new System.Drawing.Point(80, 262);
            this.lblChangeImage.Name = "lblChangeImage";
            this.lblChangeImage.Size = new System.Drawing.Size(143, 23);
            this.lblChangeImage.TabIndex = 4;
            this.lblChangeImage.Text = "Click image to change...";
            this.lblChangeImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgCaptain
            // 
            this.imgCaptain.Location = new System.Drawing.Point(5, 20);
            this.imgCaptain.Name = "imgCaptain";
            this.imgCaptain.Size = new System.Drawing.Size(40, 40);
            this.imgCaptain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgCaptain.TabIndex = 5;
            this.imgCaptain.TabStop = false;
            // 
            // imgFavourite
            // 
            this.imgFavourite.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.imgFavourite.Image = ((System.Drawing.Image)(resources.GetObject("imgFavourite.Image")));
            this.imgFavourite.Location = new System.Drawing.Point(260, 20);
            this.imgFavourite.Name = "imgFavourite";
            this.imgFavourite.Size = new System.Drawing.Size(40, 40);
            this.imgFavourite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgFavourite.TabIndex = 6;
            this.imgFavourite.TabStop = false;
            // 
            // PlayerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
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
            this.Size = new System.Drawing.Size(303, 420);
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
