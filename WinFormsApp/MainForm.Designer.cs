namespace WinFormsApp
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageMainPage = new System.Windows.Forms.TabPage();
            this.pnlStartingSetup = new System.Windows.Forms.Panel();
            this.btnSaveInitialSetup = new System.Windows.Forms.Button();
            this.pnlPlayerFavPlayerChoice = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAllPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuAddFavourite = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToFavouritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFavouritePlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuRemoveFavouritePlayers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeFromFavouritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChosenFavTeams = new System.Windows.Forms.TextBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.ddlTeams = new System.Windows.Forms.ComboBox();
            this.lblTeams = new System.Windows.Forms.Label();
            this.tabRanking = new System.Windows.Forms.TabPage();
            this.pnlRanking = new System.Windows.Forms.Panel();
            this.btnSortByFavourite = new System.Windows.Forms.Button();
            this.btnSortByYellowCards = new System.Windows.Forms.Button();
            this.btnSortByGoals = new System.Windows.Forms.Button();
            this.lblTeamRanking = new System.Windows.Forms.Label();
            this.lblPlayersRanking = new System.Windows.Forms.Label();
            this.pnlPlayerAndTeamRankings = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPlayersRanking = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTeamsRanking = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pRintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.pnlSettingsTab = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.ddlLanguageChoice = new System.Windows.Forms.ComboBox();
            this.lblLanguageChoice = new System.Windows.Forms.Label();
            this.ddlChampionshipChoice = new System.Windows.Forms.ComboBox();
            this.lblChampionshipChoice = new System.Windows.Forms.Label();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.imgLeft = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageMainPage.SuspendLayout();
            this.pnlStartingSetup.SuspendLayout();
            this.pnlPlayerFavPlayerChoice.SuspendLayout();
            this.contextMenuAddFavourite.SuspendLayout();
            this.contextMenuRemoveFavouritePlayers.SuspendLayout();
            this.tabRanking.SuspendLayout();
            this.pnlRanking.SuspendLayout();
            this.pnlPlayerAndTeamRankings.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.pnlSettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel.Controls.Add(this.tabControl, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.imgLogo, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.imgLeft, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.tabPageMainPage);
            this.tabControl.Controls.Add(this.tabRanking);
            this.tabControl.Controls.Add(this.settingsTab);
            this.tabControl.HotTrack = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabPageMainPage
            // 
            resources.ApplyResources(this.tabPageMainPage, "tabPageMainPage");
            this.tabPageMainPage.Controls.Add(this.pnlStartingSetup);
            this.tabPageMainPage.Name = "tabPageMainPage";
            this.tabPageMainPage.UseVisualStyleBackColor = true;
            // 
            // pnlStartingSetup
            // 
            resources.ApplyResources(this.pnlStartingSetup, "pnlStartingSetup");
            this.pnlStartingSetup.Controls.Add(this.btnSaveInitialSetup);
            this.pnlStartingSetup.Controls.Add(this.pnlPlayerFavPlayerChoice);
            this.pnlStartingSetup.Controls.Add(this.label2);
            this.pnlStartingSetup.Controls.Add(this.txtChosenFavTeams);
            this.pnlStartingSetup.Controls.Add(this.btnChoose);
            this.pnlStartingSetup.Controls.Add(this.ddlTeams);
            this.pnlStartingSetup.Controls.Add(this.lblTeams);
            this.pnlStartingSetup.Name = "pnlStartingSetup";
            // 
            // btnSaveInitialSetup
            // 
            resources.ApplyResources(this.btnSaveInitialSetup, "btnSaveInitialSetup");
            this.btnSaveInitialSetup.Name = "btnSaveInitialSetup";
            this.btnSaveInitialSetup.UseVisualStyleBackColor = true;
            this.btnSaveInitialSetup.Click += new System.EventHandler(this.BtnSaveInitialSetup_Click);
            // 
            // pnlPlayerFavPlayerChoice
            // 
            resources.ApplyResources(this.pnlPlayerFavPlayerChoice, "pnlPlayerFavPlayerChoice");
            this.pnlPlayerFavPlayerChoice.Controls.Add(this.pnlAllPlayers, 1, 0);
            this.pnlPlayerFavPlayerChoice.Controls.Add(this.pnlFavouritePlayers, 0, 0);
            this.pnlPlayerFavPlayerChoice.Name = "pnlPlayerFavPlayerChoice";
            // 
            // pnlAllPlayers
            // 
            resources.ApplyResources(this.pnlAllPlayers, "pnlAllPlayers");
            this.pnlAllPlayers.BackColor = System.Drawing.SystemColors.Control;
            this.pnlAllPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAllPlayers.ContextMenuStrip = this.contextMenuAddFavourite;
            this.pnlAllPlayers.Name = "pnlAllPlayers";
            // 
            // contextMenuAddFavourite
            // 
            resources.ApplyResources(this.contextMenuAddFavourite, "contextMenuAddFavourite");
            this.contextMenuAddFavourite.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToFavouritesToolStripMenuItem});
            this.contextMenuAddFavourite.Name = "contextMenuAddFavourite";
            // 
            // addToFavouritesToolStripMenuItem
            // 
            resources.ApplyResources(this.addToFavouritesToolStripMenuItem, "addToFavouritesToolStripMenuItem");
            this.addToFavouritesToolStripMenuItem.Name = "addToFavouritesToolStripMenuItem";
            this.addToFavouritesToolStripMenuItem.Click += new System.EventHandler(this.AddToFavourites_Click);
            // 
            // pnlFavouritePlayers
            // 
            resources.ApplyResources(this.pnlFavouritePlayers, "pnlFavouritePlayers");
            this.pnlFavouritePlayers.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFavouritePlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFavouritePlayers.ContextMenuStrip = this.contextMenuRemoveFavouritePlayers;
            this.pnlFavouritePlayers.Name = "pnlFavouritePlayers";
            // 
            // contextMenuRemoveFavouritePlayers
            // 
            resources.ApplyResources(this.contextMenuRemoveFavouritePlayers, "contextMenuRemoveFavouritePlayers");
            this.contextMenuRemoveFavouritePlayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeFromFavouritesToolStripMenuItem});
            this.contextMenuRemoveFavouritePlayers.Name = "contextMenuRemoveFavouritePlayers";
            // 
            // removeFromFavouritesToolStripMenuItem
            // 
            resources.ApplyResources(this.removeFromFavouritesToolStripMenuItem, "removeFromFavouritesToolStripMenuItem");
            this.removeFromFavouritesToolStripMenuItem.Name = "removeFromFavouritesToolStripMenuItem";
            this.removeFromFavouritesToolStripMenuItem.Click += new System.EventHandler(this.RemoveFromFavourites_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtChosenFavTeams
            // 
            resources.ApplyResources(this.txtChosenFavTeams, "txtChosenFavTeams");
            this.txtChosenFavTeams.Name = "txtChosenFavTeams";
            this.txtChosenFavTeams.ReadOnly = true;
            // 
            // btnChoose
            // 
            resources.ApplyResources(this.btnChoose, "btnChoose");
            this.btnChoose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.BtnChoose_Click);
            // 
            // ddlTeams
            // 
            resources.ApplyResources(this.ddlTeams, "ddlTeams");
            this.ddlTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTeams.FormattingEnabled = true;
            this.ddlTeams.Name = "ddlTeams";
            // 
            // lblTeams
            // 
            resources.ApplyResources(this.lblTeams, "lblTeams");
            this.lblTeams.Name = "lblTeams";
            // 
            // tabRanking
            // 
            resources.ApplyResources(this.tabRanking, "tabRanking");
            this.tabRanking.Controls.Add(this.pnlRanking);
            this.tabRanking.Controls.Add(this.menuStrip1);
            this.tabRanking.Name = "tabRanking";
            this.tabRanking.UseVisualStyleBackColor = true;
            // 
            // pnlRanking
            // 
            resources.ApplyResources(this.pnlRanking, "pnlRanking");
            this.pnlRanking.Controls.Add(this.btnSortByFavourite);
            this.pnlRanking.Controls.Add(this.btnSortByYellowCards);
            this.pnlRanking.Controls.Add(this.btnSortByGoals);
            this.pnlRanking.Controls.Add(this.lblTeamRanking);
            this.pnlRanking.Controls.Add(this.lblPlayersRanking);
            this.pnlRanking.Controls.Add(this.pnlPlayerAndTeamRankings);
            this.pnlRanking.Name = "pnlRanking";
            // 
            // btnSortByFavourite
            // 
            resources.ApplyResources(this.btnSortByFavourite, "btnSortByFavourite");
            this.btnSortByFavourite.Name = "btnSortByFavourite";
            this.btnSortByFavourite.UseVisualStyleBackColor = true;
            this.btnSortByFavourite.Click += new System.EventHandler(this.BtnSortByFavourite_Click);
            // 
            // btnSortByYellowCards
            // 
            resources.ApplyResources(this.btnSortByYellowCards, "btnSortByYellowCards");
            this.btnSortByYellowCards.Name = "btnSortByYellowCards";
            this.btnSortByYellowCards.UseVisualStyleBackColor = true;
            this.btnSortByYellowCards.Click += new System.EventHandler(this.BtnSortByYellowCards_Click);
            // 
            // btnSortByGoals
            // 
            resources.ApplyResources(this.btnSortByGoals, "btnSortByGoals");
            this.btnSortByGoals.Name = "btnSortByGoals";
            this.btnSortByGoals.UseVisualStyleBackColor = true;
            this.btnSortByGoals.Click += new System.EventHandler(this.BtnSortByGoals_Click);
            // 
            // lblTeamRanking
            // 
            resources.ApplyResources(this.lblTeamRanking, "lblTeamRanking");
            this.lblTeamRanking.Name = "lblTeamRanking";
            // 
            // lblPlayersRanking
            // 
            resources.ApplyResources(this.lblPlayersRanking, "lblPlayersRanking");
            this.lblPlayersRanking.Name = "lblPlayersRanking";
            // 
            // pnlPlayerAndTeamRankings
            // 
            resources.ApplyResources(this.pnlPlayerAndTeamRankings, "pnlPlayerAndTeamRankings");
            this.pnlPlayerAndTeamRankings.Controls.Add(this.pnlPlayersRanking, 0, 0);
            this.pnlPlayerAndTeamRankings.Controls.Add(this.pnlTeamsRanking, 1, 0);
            this.pnlPlayerAndTeamRankings.Name = "pnlPlayerAndTeamRankings";
            // 
            // pnlPlayersRanking
            // 
            resources.ApplyResources(this.pnlPlayersRanking, "pnlPlayersRanking");
            this.pnlPlayersRanking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPlayersRanking.Name = "pnlPlayersRanking";
            // 
            // pnlTeamsRanking
            // 
            resources.ApplyResources(this.pnlTeamsRanking, "pnlTeamsRanking");
            this.pnlTeamsRanking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTeamsRanking.Name = "pnlTeamsRanking";
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pRintToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // pRintToolStripMenuItem
            // 
            resources.ApplyResources(this.pRintToolStripMenuItem, "pRintToolStripMenuItem");
            this.pRintToolStripMenuItem.Name = "pRintToolStripMenuItem";
            this.pRintToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItem_Click);
            // 
            // settingsTab
            // 
            resources.ApplyResources(this.settingsTab, "settingsTab");
            this.settingsTab.Controls.Add(this.pnlSettingsTab);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // pnlSettingsTab
            // 
            resources.ApplyResources(this.pnlSettingsTab, "pnlSettingsTab");
            this.pnlSettingsTab.Controls.Add(this.btnApply);
            this.pnlSettingsTab.Controls.Add(this.ddlLanguageChoice);
            this.pnlSettingsTab.Controls.Add(this.lblLanguageChoice);
            this.pnlSettingsTab.Controls.Add(this.ddlChampionshipChoice);
            this.pnlSettingsTab.Controls.Add(this.lblChampionshipChoice);
            this.pnlSettingsTab.Name = "pnlSettingsTab";
            // 
            // btnApply
            // 
            resources.ApplyResources(this.btnApply, "btnApply");
            this.btnApply.Name = "btnApply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // ddlLanguageChoice
            // 
            resources.ApplyResources(this.ddlLanguageChoice, "ddlLanguageChoice");
            this.ddlLanguageChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLanguageChoice.FormattingEnabled = true;
            this.ddlLanguageChoice.Name = "ddlLanguageChoice";
            // 
            // lblLanguageChoice
            // 
            resources.ApplyResources(this.lblLanguageChoice, "lblLanguageChoice");
            this.lblLanguageChoice.Name = "lblLanguageChoice";
            // 
            // ddlChampionshipChoice
            // 
            resources.ApplyResources(this.ddlChampionshipChoice, "ddlChampionshipChoice");
            this.ddlChampionshipChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlChampionshipChoice.FormattingEnabled = true;
            this.ddlChampionshipChoice.Name = "ddlChampionshipChoice";
            // 
            // lblChampionshipChoice
            // 
            resources.ApplyResources(this.lblChampionshipChoice, "lblChampionshipChoice");
            this.lblChampionshipChoice.Name = "lblChampionshipChoice";
            // 
            // imgLogo
            // 
            resources.ApplyResources(this.imgLogo, "imgLogo");
            this.imgLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.TabStop = false;
            // 
            // imgLeft
            // 
            resources.ApplyResources(this.imgLeft, "imgLeft");
            this.imgLeft.Name = "imgLeft";
            this.imgLeft.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageMainPage.ResumeLayout(false);
            this.pnlStartingSetup.ResumeLayout(false);
            this.pnlStartingSetup.PerformLayout();
            this.pnlPlayerFavPlayerChoice.ResumeLayout(false);
            this.contextMenuAddFavourite.ResumeLayout(false);
            this.contextMenuRemoveFavouritePlayers.ResumeLayout(false);
            this.tabRanking.ResumeLayout(false);
            this.tabRanking.PerformLayout();
            this.pnlRanking.ResumeLayout(false);
            this.pnlRanking.PerformLayout();
            this.pnlPlayerAndTeamRankings.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.settingsTab.ResumeLayout(false);
            this.pnlSettingsTab.ResumeLayout(false);
            this.pnlSettingsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.TabPage tabPageMainPage;
        private System.Windows.Forms.TabPage tabRanking;
        private System.Windows.Forms.PictureBox imgLeft;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.Panel pnlStartingSetup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChosenFavTeams;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.ComboBox ddlTeams;
        private System.Windows.Forms.Label lblTeams;
        private System.Windows.Forms.TableLayoutPanel pnlPlayerFavPlayerChoice;
        private System.Windows.Forms.FlowLayoutPanel pnlFavouritePlayers;
        private System.Windows.Forms.FlowLayoutPanel pnlAllPlayers;
        private System.Windows.Forms.ContextMenuStrip contextMenuAddFavourite;
        private System.Windows.Forms.ToolStripMenuItem addToFavouritesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuRemoveFavouritePlayers;
        private System.Windows.Forms.ToolStripMenuItem removeFromFavouritesToolStripMenuItem;
        private System.Windows.Forms.Panel pnlSettingsTab;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ComboBox ddlLanguageChoice;
        private System.Windows.Forms.Label lblLanguageChoice;
        private System.Windows.Forms.ComboBox ddlChampionshipChoice;
        private System.Windows.Forms.Label lblChampionshipChoice;
        private System.Windows.Forms.Panel pnlRanking;
        private System.Windows.Forms.Label lblTeamRanking;
        private System.Windows.Forms.Label lblPlayersRanking;
        private System.Windows.Forms.TableLayoutPanel pnlPlayerAndTeamRankings;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pRintToolStripMenuItem;
        private System.Windows.Forms.Button btnSortByYellowCards;
        private System.Windows.Forms.Button btnSortByGoals;
        private System.Windows.Forms.FlowLayoutPanel pnlPlayersRanking;
        private System.Windows.Forms.FlowLayoutPanel pnlTeamsRanking;
        private System.Windows.Forms.Button btnSaveInitialSetup;
        private System.Windows.Forms.Button btnSortByFavourite;
    }
}