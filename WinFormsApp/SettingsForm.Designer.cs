namespace WinFormsApp
{
    partial class SettingsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.lblChampionshipChoice = new System.Windows.Forms.Label();
            this.ddlChampionshipChoice = new System.Windows.Forms.ComboBox();
            this.ddlLanguageChoice = new System.Windows.Forms.ComboBox();
            this.lblLanguageChoice = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblChampionshipChoice
            // 
            resources.ApplyResources(this.lblChampionshipChoice, "lblChampionshipChoice");
            this.lblChampionshipChoice.Name = "lblChampionshipChoice";
            // 
            // ddlChampionshipChoice
            // 
            resources.ApplyResources(this.ddlChampionshipChoice, "ddlChampionshipChoice");
            this.ddlChampionshipChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlChampionshipChoice.FormattingEnabled = true;
            this.ddlChampionshipChoice.Name = "ddlChampionshipChoice";
            // 
            // ddlLanguageChoice
            // 
            resources.ApplyResources(this.ddlLanguageChoice, "ddlLanguageChoice");
            this.ddlLanguageChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLanguageChoice.FormattingEnabled = true;
            this.ddlLanguageChoice.Name = "ddlLanguageChoice";
            this.ddlLanguageChoice.SelectionChangeCommitted += new System.EventHandler(this.Language_SelectionChangeCommitted);
            // 
            // lblLanguageChoice
            // 
            resources.ApplyResources(this.lblLanguageChoice, "lblLanguageChoice");
            this.lblLanguageChoice.Name = "lblLanguageChoice";
            // 
            // btnContinue
            // 
            resources.ApplyResources(this.btnContinue, "btnContinue");
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.BtnContinue_Click);
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.ddlLanguageChoice);
            this.Controls.Add(this.lblLanguageChoice);
            this.Controls.Add(this.ddlChampionshipChoice);
            this.Controls.Add(this.lblChampionshipChoice);
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChampionshipChoice;
        private System.Windows.Forms.ComboBox ddlChampionshipChoice;
        private System.Windows.Forms.ComboBox ddlLanguageChoice;
        private System.Windows.Forms.Label lblLanguageChoice;
        private System.Windows.Forms.Button btnContinue;
    }
}