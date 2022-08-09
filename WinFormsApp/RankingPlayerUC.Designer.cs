namespace WinFormsApp
{
    partial class RankingPlayerUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankingPlayerUC));
            this.imgPlayer = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.imgYellowCard = new System.Windows.Forms.PictureBox();
            this.lblYellowCardsNumber = new System.Windows.Forms.Label();
            this.lblGoalsNumber = new System.Windows.Forms.Label();
            this.imgGoal = new System.Windows.Forms.PictureBox();
            this.imgFavourite = new System.Windows.Forms.PictureBox();
            this.imgCaptain = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgYellowCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgGoal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFavourite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCaptain)).BeginInit();
            this.SuspendLayout();
            // 
            // imgPlayer
            // 
            this.imgPlayer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.imgPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgPlayer.Image = ((System.Drawing.Image)(resources.GetObject("imgPlayer.Image")));
            this.imgPlayer.Location = new System.Drawing.Point(52, 20);
            this.imgPlayer.Name = "imgPlayer";
            this.imgPlayer.Size = new System.Drawing.Size(200, 250);
            this.imgPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPlayer.TabIndex = 0;
            this.imgPlayer.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(3, 273);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(295, 25);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "FullNamePlaceholder";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgYellowCard
            // 
            this.imgYellowCard.Image = ((System.Drawing.Image)(resources.GetObject("imgYellowCard.Image")));
            this.imgYellowCard.Location = new System.Drawing.Point(161, 354);
            this.imgYellowCard.Name = "imgYellowCard";
            this.imgYellowCard.Size = new System.Drawing.Size(50, 50);
            this.imgYellowCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgYellowCard.TabIndex = 2;
            this.imgYellowCard.TabStop = false;
            // 
            // lblYellowCardsNumber
            // 
            this.lblYellowCardsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYellowCardsNumber.Location = new System.Drawing.Point(89, 354);
            this.lblYellowCardsNumber.Name = "lblYellowCardsNumber";
            this.lblYellowCardsNumber.Size = new System.Drawing.Size(66, 50);
            this.lblYellowCardsNumber.TabIndex = 3;
            this.lblYellowCardsNumber.Text = "99";
            this.lblYellowCardsNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGoalsNumber
            // 
            this.lblGoalsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGoalsNumber.Location = new System.Drawing.Point(89, 298);
            this.lblGoalsNumber.Name = "lblGoalsNumber";
            this.lblGoalsNumber.Size = new System.Drawing.Size(66, 50);
            this.lblGoalsNumber.TabIndex = 5;
            this.lblGoalsNumber.Text = "99";
            this.lblGoalsNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgGoal
            // 
            this.imgGoal.Image = ((System.Drawing.Image)(resources.GetObject("imgGoal.Image")));
            this.imgGoal.Location = new System.Drawing.Point(161, 298);
            this.imgGoal.Name = "imgGoal";
            this.imgGoal.Size = new System.Drawing.Size(50, 50);
            this.imgGoal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgGoal.TabIndex = 4;
            this.imgGoal.TabStop = false;
            // 
            // imgFavourite
            // 
            this.imgFavourite.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.imgFavourite.Image = ((System.Drawing.Image)(resources.GetObject("imgFavourite.Image")));
            this.imgFavourite.Location = new System.Drawing.Point(260, 20);
            this.imgFavourite.Name = "imgFavourite";
            this.imgFavourite.Size = new System.Drawing.Size(40, 40);
            this.imgFavourite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgFavourite.TabIndex = 7;
            this.imgFavourite.TabStop = false;
            // 
            // imgCaptain
            // 
            this.imgCaptain.Location = new System.Drawing.Point(5, 20);
            this.imgCaptain.Name = "imgCaptain";
            this.imgCaptain.Size = new System.Drawing.Size(40, 40);
            this.imgCaptain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgCaptain.TabIndex = 8;
            this.imgCaptain.TabStop = false;
            // 
            // RankingPlayerUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.imgCaptain);
            this.Controls.Add(this.imgFavourite);
            this.Controls.Add(this.lblGoalsNumber);
            this.Controls.Add(this.imgGoal);
            this.Controls.Add(this.lblYellowCardsNumber);
            this.Controls.Add(this.imgYellowCard);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.imgPlayer);
            this.Name = "RankingPlayerUC";
            this.Size = new System.Drawing.Size(303, 420);
            this.Load += new System.EventHandler(this.RankingPlayerUC_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RankingPlayerUC_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgYellowCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgGoal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFavourite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCaptain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgPlayer;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox imgYellowCard;
        private System.Windows.Forms.Label lblYellowCardsNumber;
        private System.Windows.Forms.Label lblGoalsNumber;
        private System.Windows.Forms.PictureBox imgGoal;
        private System.Windows.Forms.PictureBox imgFavourite;
        private System.Windows.Forms.PictureBox imgCaptain;
    }
}
