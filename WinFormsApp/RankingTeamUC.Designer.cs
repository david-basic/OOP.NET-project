namespace WinFormsApp
{
    partial class RankingTeamUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankingTeamUC));
            this.lblHomeTeam = new System.Windows.Forms.Label();
            this.lblAwayTeam = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.imgStadium = new System.Windows.Forms.PictureBox();
            this.lblMatchLocation = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMatchAttendance = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgStadium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHomeTeam
            // 
            this.lblHomeTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHomeTeam.Location = new System.Drawing.Point(0, 0);
            this.lblHomeTeam.Name = "lblHomeTeam";
            this.lblHomeTeam.Size = new System.Drawing.Size(320, 50);
            this.lblHomeTeam.TabIndex = 0;
            this.lblHomeTeam.Text = "HomeTeam";
            this.lblHomeTeam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAwayTeam
            // 
            this.lblAwayTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAwayTeam.Location = new System.Drawing.Point(380, 0);
            this.lblAwayTeam.Name = "lblAwayTeam";
            this.lblAwayTeam.Size = new System.Drawing.Size(320, 50);
            this.lblAwayTeam.TabIndex = 1;
            this.lblAwayTeam.Text = "AwayTeam";
            this.lblAwayTeam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(320, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "vs.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgStadium
            // 
            this.imgStadium.Image = ((System.Drawing.Image)(resources.GetObject("imgStadium.Image")));
            this.imgStadium.Location = new System.Drawing.Point(10, 53);
            this.imgStadium.Name = "imgStadium";
            this.imgStadium.Size = new System.Drawing.Size(70, 70);
            this.imgStadium.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgStadium.TabIndex = 3;
            this.imgStadium.TabStop = false;
            // 
            // lblMatchLocation
            // 
            this.lblMatchLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatchLocation.Location = new System.Drawing.Point(80, 63);
            this.lblMatchLocation.Name = "lblMatchLocation";
            this.lblMatchLocation.Size = new System.Drawing.Size(230, 50);
            this.lblMatchLocation.TabIndex = 4;
            this.lblMatchLocation.Text = "MatchLocation";
            this.lblMatchLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(620, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lblMatchAttendance
            // 
            this.lblMatchAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatchAttendance.Location = new System.Drawing.Point(390, 63);
            this.lblMatchAttendance.Name = "lblMatchAttendance";
            this.lblMatchAttendance.Size = new System.Drawing.Size(230, 50);
            this.lblMatchAttendance.TabIndex = 6;
            this.lblMatchAttendance.Text = "99, 999";
            this.lblMatchAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RankingTeamUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblMatchAttendance);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblMatchLocation);
            this.Controls.Add(this.imgStadium);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAwayTeam);
            this.Controls.Add(this.lblHomeTeam);
            this.Name = "RankingTeamUC";
            this.Size = new System.Drawing.Size(700, 140);
            this.Load += new System.EventHandler(this.RankingTeamUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgStadium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHomeTeam;
        private System.Windows.Forms.Label lblAwayTeam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox imgStadium;
        private System.Windows.Forms.Label lblMatchLocation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMatchAttendance;
    }
}
