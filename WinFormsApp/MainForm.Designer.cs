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
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.tabControl, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.imgLogo, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.imgLeft, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(1520, 825);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageMainPage);
            this.tabControl.Controls.Add(this.tabRanking);
            this.tabControl.Controls.Add(this.settingsTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.HotTrack = true;
            this.tabControl.ItemSize = new System.Drawing.Size(58, 18);
            this.tabControl.Location = new System.Drawing.Point(63, 63);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1920, 1080);
            this.tabControl.TabIndex = 2;
            // 
            // tabPageMainPage
            // 
            this.tabPageMainPage.Controls.Add(this.pnlStartingSetup);
            this.tabPageMainPage.Location = new System.Drawing.Point(4, 22);
            this.tabPageMainPage.Name = "tabPageMainPage";
            this.tabPageMainPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMainPage.Size = new System.Drawing.Size(1912, 1054);
            this.tabPageMainPage.TabIndex = 2;
            this.tabPageMainPage.Text = "Main page";
            this.tabPageMainPage.UseVisualStyleBackColor = true;
            // 
            // pnlStartingSetup
            // 
            this.pnlStartingSetup.Controls.Add(this.btnSaveInitialSetup);
            this.pnlStartingSetup.Controls.Add(this.pnlPlayerFavPlayerChoice);
            this.pnlStartingSetup.Controls.Add(this.label2);
            this.pnlStartingSetup.Controls.Add(this.txtChosenFavTeams);
            this.pnlStartingSetup.Controls.Add(this.btnChoose);
            this.pnlStartingSetup.Controls.Add(this.ddlTeams);
            this.pnlStartingSetup.Controls.Add(this.lblTeams);
            this.pnlStartingSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStartingSetup.Location = new System.Drawing.Point(3, 3);
            this.pnlStartingSetup.Name = "pnlStartingSetup";
            this.pnlStartingSetup.Size = new System.Drawing.Size(1906, 1048);
            this.pnlStartingSetup.TabIndex = 1;
            // 
            // btnSaveInitialSetup
            // 
            this.btnSaveInitialSetup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveInitialSetup.Location = new System.Drawing.Point(87, 328);
            this.btnSaveInitialSetup.Name = "btnSaveInitialSetup";
            this.btnSaveInitialSetup.Size = new System.Drawing.Size(151, 97);
            this.btnSaveInitialSetup.TabIndex = 6;
            this.btnSaveInitialSetup.Text = "Save initial setup";
            this.btnSaveInitialSetup.UseVisualStyleBackColor = true;
            this.btnSaveInitialSetup.Click += new System.EventHandler(this.btnSaveInitialSetup_Click);
            // 
            // pnlPlayerFavPlayerChoice
            // 
            this.pnlPlayerFavPlayerChoice.ColumnCount = 2;
            this.pnlPlayerFavPlayerChoice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlPlayerFavPlayerChoice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlPlayerFavPlayerChoice.Controls.Add(this.pnlAllPlayers, 1, 0);
            this.pnlPlayerFavPlayerChoice.Controls.Add(this.pnlFavouritePlayers, 0, 0);
            this.pnlPlayerFavPlayerChoice.Location = new System.Drawing.Point(326, 3);
            this.pnlPlayerFavPlayerChoice.Name = "pnlPlayerFavPlayerChoice";
            this.pnlPlayerFavPlayerChoice.RowCount = 1;
            this.pnlPlayerFavPlayerChoice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlPlayerFavPlayerChoice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 710F));
            this.pnlPlayerFavPlayerChoice.Size = new System.Drawing.Size(1124, 710);
            this.pnlPlayerFavPlayerChoice.TabIndex = 5;
            // 
            // pnlAllPlayers
            // 
            this.pnlAllPlayers.AutoScroll = true;
            this.pnlAllPlayers.BackColor = System.Drawing.SystemColors.Control;
            this.pnlAllPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlAllPlayers.ContextMenuStrip = this.contextMenuAddFavourite;
            this.pnlAllPlayers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlAllPlayers.Location = new System.Drawing.Point(565, 3);
            this.pnlAllPlayers.Name = "pnlAllPlayers";
            this.pnlAllPlayers.Padding = new System.Windows.Forms.Padding(6);
            this.pnlAllPlayers.Size = new System.Drawing.Size(341, 704);
            this.pnlAllPlayers.TabIndex = 1;
            this.pnlAllPlayers.WrapContents = false;
            // 
            // contextMenuAddFavourite
            // 
            this.contextMenuAddFavourite.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToFavouritesToolStripMenuItem});
            this.contextMenuAddFavourite.Name = "contextMenuAddFavourite";
            this.contextMenuAddFavourite.Size = new System.Drawing.Size(166, 26);
            // 
            // addToFavouritesToolStripMenuItem
            // 
            this.addToFavouritesToolStripMenuItem.Name = "addToFavouritesToolStripMenuItem";
            this.addToFavouritesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.addToFavouritesToolStripMenuItem.Text = "Add to favourites";
            this.addToFavouritesToolStripMenuItem.Click += new System.EventHandler(this.AddToFavourites_Click);
            // 
            // pnlFavouritePlayers
            // 
            this.pnlFavouritePlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFavouritePlayers.AutoScroll = true;
            this.pnlFavouritePlayers.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFavouritePlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFavouritePlayers.ContextMenuStrip = this.contextMenuRemoveFavouritePlayers;
            this.pnlFavouritePlayers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlFavouritePlayers.Location = new System.Drawing.Point(218, 3);
            this.pnlFavouritePlayers.Name = "pnlFavouritePlayers";
            this.pnlFavouritePlayers.Padding = new System.Windows.Forms.Padding(6);
            this.pnlFavouritePlayers.Size = new System.Drawing.Size(341, 704);
            this.pnlFavouritePlayers.TabIndex = 0;
            this.pnlFavouritePlayers.WrapContents = false;
            // 
            // contextMenuRemoveFavouritePlayers
            // 
            this.contextMenuRemoveFavouritePlayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeFromFavouritesToolStripMenuItem});
            this.contextMenuRemoveFavouritePlayers.Name = "contextMenuRemoveFavouritePlayers";
            this.contextMenuRemoveFavouritePlayers.Size = new System.Drawing.Size(202, 26);
            // 
            // removeFromFavouritesToolStripMenuItem
            // 
            this.removeFromFavouritesToolStripMenuItem.Name = "removeFromFavouritesToolStripMenuItem";
            this.removeFromFavouritesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.removeFromFavouritesToolStripMenuItem.Text = "Remove from favourites";
            this.removeFromFavouritesToolStripMenuItem.Click += new System.EventHandler(this.RemoveFromFavourites_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Choose a favourite team...";
            // 
            // txtChosenFavTeams
            // 
            this.txtChosenFavTeams.Location = new System.Drawing.Point(15, 73);
            this.txtChosenFavTeams.Multiline = true;
            this.txtChosenFavTeams.Name = "txtChosenFavTeams";
            this.txtChosenFavTeams.ReadOnly = true;
            this.txtChosenFavTeams.Size = new System.Drawing.Size(305, 175);
            this.txtChosenFavTeams.TabIndex = 3;
            // 
            // btnChoose
            // 
            this.btnChoose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChoose.Location = new System.Drawing.Point(229, 29);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(91, 23);
            this.btnChoose.TabIndex = 2;
            this.btnChoose.Text = "Choose";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.BtnChoose_Click);
            // 
            // ddlTeams
            // 
            this.ddlTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTeams.FormattingEnabled = true;
            this.ddlTeams.Location = new System.Drawing.Point(15, 29);
            this.ddlTeams.Name = "ddlTeams";
            this.ddlTeams.Size = new System.Drawing.Size(207, 21);
            this.ddlTeams.TabIndex = 1;
            // 
            // lblTeams
            // 
            this.lblTeams.AutoSize = true;
            this.lblTeams.Location = new System.Drawing.Point(12, 12);
            this.lblTeams.Name = "lblTeams";
            this.lblTeams.Size = new System.Drawing.Size(42, 13);
            this.lblTeams.TabIndex = 0;
            this.lblTeams.Text = "Teams:";
            // 
            // tabRanking
            // 
            this.tabRanking.Controls.Add(this.pnlRanking);
            this.tabRanking.Controls.Add(this.menuStrip1);
            this.tabRanking.Location = new System.Drawing.Point(4, 22);
            this.tabRanking.Name = "tabRanking";
            this.tabRanking.Padding = new System.Windows.Forms.Padding(3);
            this.tabRanking.Size = new System.Drawing.Size(1912, 1054);
            this.tabRanking.TabIndex = 3;
            this.tabRanking.Text = "Ranking";
            this.tabRanking.UseVisualStyleBackColor = true;
            // 
            // pnlRanking
            // 
            this.pnlRanking.Controls.Add(this.btnSortByFavourite);
            this.pnlRanking.Controls.Add(this.btnSortByYellowCards);
            this.pnlRanking.Controls.Add(this.btnSortByGoals);
            this.pnlRanking.Controls.Add(this.lblTeamRanking);
            this.pnlRanking.Controls.Add(this.lblPlayersRanking);
            this.pnlRanking.Controls.Add(this.pnlPlayerAndTeamRankings);
            this.pnlRanking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRanking.Location = new System.Drawing.Point(3, 27);
            this.pnlRanking.Name = "pnlRanking";
            this.pnlRanking.Size = new System.Drawing.Size(1906, 1024);
            this.pnlRanking.TabIndex = 0;
            // 
            // btnSortByFavourite
            // 
            this.btnSortByFavourite.Location = new System.Drawing.Point(353, 10);
            this.btnSortByFavourite.Name = "btnSortByFavourite";
            this.btnSortByFavourite.Size = new System.Drawing.Size(125, 23);
            this.btnSortByFavourite.TabIndex = 5;
            this.btnSortByFavourite.Text = "Sort by Favourite";
            this.btnSortByFavourite.UseVisualStyleBackColor = true;
            this.btnSortByFavourite.Click += new System.EventHandler(this.btnSortByFavourite_Click);
            // 
            // btnSortByYellowCards
            // 
            this.btnSortByYellowCards.Location = new System.Drawing.Point(222, 10);
            this.btnSortByYellowCards.Name = "btnSortByYellowCards";
            this.btnSortByYellowCards.Size = new System.Drawing.Size(125, 23);
            this.btnSortByYellowCards.TabIndex = 4;
            this.btnSortByYellowCards.Text = "Sort by Yellow Cards";
            this.btnSortByYellowCards.UseVisualStyleBackColor = true;
            this.btnSortByYellowCards.Click += new System.EventHandler(this.btnSortByYellowCards_Click);
            // 
            // btnSortByGoals
            // 
            this.btnSortByGoals.Location = new System.Drawing.Point(91, 10);
            this.btnSortByGoals.Name = "btnSortByGoals";
            this.btnSortByGoals.Size = new System.Drawing.Size(125, 23);
            this.btnSortByGoals.TabIndex = 3;
            this.btnSortByGoals.Text = "Sort by Goals";
            this.btnSortByGoals.UseVisualStyleBackColor = true;
            this.btnSortByGoals.Click += new System.EventHandler(this.btnSortByGoals_Click);
            // 
            // lblTeamRanking
            // 
            this.lblTeamRanking.AutoSize = true;
            this.lblTeamRanking.Location = new System.Drawing.Point(726, 15);
            this.lblTeamRanking.Name = "lblTeamRanking";
            this.lblTeamRanking.Size = new System.Drawing.Size(85, 13);
            this.lblTeamRanking.TabIndex = 2;
            this.lblTeamRanking.Text = "Teams Ranking:";
            // 
            // lblPlayersRanking
            // 
            this.lblPlayersRanking.AutoSize = true;
            this.lblPlayersRanking.Location = new System.Drawing.Point(3, 15);
            this.lblPlayersRanking.Name = "lblPlayersRanking";
            this.lblPlayersRanking.Size = new System.Drawing.Size(82, 13);
            this.lblPlayersRanking.TabIndex = 1;
            this.lblPlayersRanking.Text = "Player Ranking:";
            // 
            // pnlPlayerAndTeamRankings
            // 
            this.pnlPlayerAndTeamRankings.ColumnCount = 2;
            this.pnlPlayerAndTeamRankings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlPlayerAndTeamRankings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlPlayerAndTeamRankings.Controls.Add(this.pnlPlayersRanking, 0, 0);
            this.pnlPlayerAndTeamRankings.Controls.Add(this.pnlTeamsRanking, 1, 0);
            this.pnlPlayerAndTeamRankings.Location = new System.Drawing.Point(3, 39);
            this.pnlPlayerAndTeamRankings.Name = "pnlPlayerAndTeamRankings";
            this.pnlPlayerAndTeamRankings.RowCount = 1;
            this.pnlPlayerAndTeamRankings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlPlayerAndTeamRankings.Size = new System.Drawing.Size(1447, 674);
            this.pnlPlayerAndTeamRankings.TabIndex = 0;
            // 
            // pnlPlayersRanking
            // 
            this.pnlPlayersRanking.AutoScroll = true;
            this.pnlPlayersRanking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPlayersRanking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlayersRanking.Location = new System.Drawing.Point(3, 3);
            this.pnlPlayersRanking.Name = "pnlPlayersRanking";
            this.pnlPlayersRanking.Size = new System.Drawing.Size(717, 668);
            this.pnlPlayersRanking.TabIndex = 0;
            // 
            // pnlTeamsRanking
            // 
            this.pnlTeamsRanking.AutoScroll = true;
            this.pnlTeamsRanking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTeamsRanking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeamsRanking.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlTeamsRanking.Location = new System.Drawing.Point(726, 3);
            this.pnlTeamsRanking.Name = "pnlTeamsRanking";
            this.pnlTeamsRanking.Size = new System.Drawing.Size(718, 668);
            this.pnlTeamsRanking.TabIndex = 1;
            this.pnlTeamsRanking.WrapContents = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pRintToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1906, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pRintToolStripMenuItem
            // 
            this.pRintToolStripMenuItem.Name = "pRintToolStripMenuItem";
            this.pRintToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.pRintToolStripMenuItem.Text = "Print";
            this.pRintToolStripMenuItem.Click += new System.EventHandler(this.pRintToolStripMenuItem_Click);
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.pnlSettingsTab);
            this.settingsTab.Location = new System.Drawing.Point(4, 22);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTab.Size = new System.Drawing.Size(1912, 1054);
            this.settingsTab.TabIndex = 5;
            this.settingsTab.Text = "Settings";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // pnlSettingsTab
            // 
            this.pnlSettingsTab.Controls.Add(this.btnApply);
            this.pnlSettingsTab.Controls.Add(this.ddlLanguageChoice);
            this.pnlSettingsTab.Controls.Add(this.lblLanguageChoice);
            this.pnlSettingsTab.Controls.Add(this.ddlChampionshipChoice);
            this.pnlSettingsTab.Controls.Add(this.lblChampionshipChoice);
            this.pnlSettingsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSettingsTab.Location = new System.Drawing.Point(3, 3);
            this.pnlSettingsTab.Name = "pnlSettingsTab";
            this.pnlSettingsTab.Size = new System.Drawing.Size(1906, 1048);
            this.pnlSettingsTab.TabIndex = 0;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnApply.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnApply.Location = new System.Drawing.Point(334, 298);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(160, 54);
            this.btnApply.TabIndex = 13;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // ddlLanguageChoice
            // 
            this.ddlLanguageChoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ddlLanguageChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLanguageChoice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ddlLanguageChoice.FormattingEnabled = true;
            this.ddlLanguageChoice.Location = new System.Drawing.Point(281, 221);
            this.ddlLanguageChoice.Name = "ddlLanguageChoice";
            this.ddlLanguageChoice.Size = new System.Drawing.Size(290, 21);
            this.ddlLanguageChoice.TabIndex = 12;
            // 
            // lblLanguageChoice
            // 
            this.lblLanguageChoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLanguageChoice.AutoSize = true;
            this.lblLanguageChoice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLanguageChoice.Location = new System.Drawing.Point(278, 205);
            this.lblLanguageChoice.Name = "lblLanguageChoice";
            this.lblLanguageChoice.Size = new System.Drawing.Size(93, 13);
            this.lblLanguageChoice.TabIndex = 11;
            this.lblLanguageChoice.Text = "Choose language:";
            // 
            // ddlChampionshipChoice
            // 
            this.ddlChampionshipChoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ddlChampionshipChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlChampionshipChoice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ddlChampionshipChoice.FormattingEnabled = true;
            this.ddlChampionshipChoice.Location = new System.Drawing.Point(281, 149);
            this.ddlChampionshipChoice.Name = "ddlChampionshipChoice";
            this.ddlChampionshipChoice.Size = new System.Drawing.Size(290, 21);
            this.ddlChampionshipChoice.TabIndex = 10;
            // 
            // lblChampionshipChoice
            // 
            this.lblChampionshipChoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblChampionshipChoice.AutoSize = true;
            this.lblChampionshipChoice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblChampionshipChoice.Location = new System.Drawing.Point(278, 133);
            this.lblChampionshipChoice.Name = "lblChampionshipChoice";
            this.lblChampionshipChoice.Size = new System.Drawing.Size(114, 13);
            this.lblChampionshipChoice.TabIndex = 9;
            this.lblChampionshipChoice.Text = "Choose championship:";
            // 
            // imgLogo
            // 
            this.imgLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
            this.imgLogo.Location = new System.Drawing.Point(3, 3);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(54, 54);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgLogo.TabIndex = 3;
            this.imgLogo.TabStop = false;
            // 
            // imgLeft
            // 
            this.imgLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgLeft.Image = ((System.Drawing.Image)(resources.GetObject("imgLeft.Image")));
            this.imgLeft.Location = new System.Drawing.Point(3, 63);
            this.imgLeft.Name = "imgLeft";
            this.imgLeft.Size = new System.Drawing.Size(54, 1080);
            this.imgLeft.TabIndex = 5;
            this.imgLeft.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(63, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1920, 54);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 825);
            this.Controls.Add(this.tableLayoutPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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