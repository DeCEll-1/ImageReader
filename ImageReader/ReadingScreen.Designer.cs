namespace ImageReader
{
    partial class ReadingScreen
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
            this.pb_Main = new System.Windows.Forms.PictureBox();
            this.pnl_Background = new System.Windows.Forms.Panel();
            this.lbl_LoadedPages = new System.Windows.Forms.Label();
            this.lbl_Load = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tv_Folders = new System.Windows.Forms.TreeView();
            this.btn_SelectDirectory = new System.Windows.Forms.Button();
            this.fbd_OpenFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_Collapse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Main)).BeginInit();
            this.pnl_Background.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_Main
            // 
            this.pb_Main.InitialImage = global::ImageReader.Properties.Resources.testTexture;
            this.pb_Main.Location = new System.Drawing.Point(191, 3);
            this.pb_Main.Name = "pb_Main";
            this.pb_Main.Size = new System.Drawing.Size(300, 450);
            this.pb_Main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Main.TabIndex = 2;
            this.pb_Main.TabStop = false;
            this.pb_Main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_Main_MouseDown);
            // 
            // pnl_Background
            // 
            this.pnl_Background.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnl_Background.Controls.Add(this.btn_Collapse);
            this.pnl_Background.Controls.Add(this.lbl_LoadedPages);
            this.pnl_Background.Controls.Add(this.lbl_Load);
            this.pnl_Background.Controls.Add(this.label2);
            this.pnl_Background.Controls.Add(this.label1);
            this.pnl_Background.Controls.Add(this.tv_Folders);
            this.pnl_Background.Controls.Add(this.pb_Main);
            this.pnl_Background.Controls.Add(this.btn_SelectDirectory);
            this.pnl_Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Background.Location = new System.Drawing.Point(0, 0);
            this.pnl_Background.Name = "pnl_Background";
            this.pnl_Background.Size = new System.Drawing.Size(700, 450);
            this.pnl_Background.TabIndex = 0;
            this.pnl_Background.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_Main_MouseDown);
            // 
            // lbl_LoadedPages
            // 
            this.lbl_LoadedPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_LoadedPages.AutoSize = true;
            this.lbl_LoadedPages.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_LoadedPages.Location = new System.Drawing.Point(641, 107);
            this.lbl_LoadedPages.Name = "lbl_LoadedPages";
            this.lbl_LoadedPages.Size = new System.Drawing.Size(0, 16);
            this.lbl_LoadedPages.TabIndex = 3;
            // 
            // lbl_Load
            // 
            this.lbl_Load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Load.AutoSize = true;
            this.lbl_Load.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_Load.Location = new System.Drawing.Point(641, 79);
            this.lbl_Load.Name = "lbl_Load";
            this.lbl_Load.Size = new System.Drawing.Size(0, 16);
            this.lbl_Load.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(557, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Loaded Pages:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(557, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Status:";
            // 
            // tv_Folders
            // 
            this.tv_Folders.Dock = System.Windows.Forms.DockStyle.Left;
            this.tv_Folders.Location = new System.Drawing.Point(0, 0);
            this.tv_Folders.Name = "tv_Folders";
            this.tv_Folders.Size = new System.Drawing.Size(256, 450);
            this.tv_Folders.TabIndex = 0;
            this.tv_Folders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Folders_AfterSelect);
            this.tv_Folders.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_Folders_MouseDown);
            this.tv_Folders.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tv_Folders_MouseMove);
            this.tv_Folders.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tv_Folders_MouseUp);
            // 
            // btn_SelectDirectory
            // 
            this.btn_SelectDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SelectDirectory.Location = new System.Drawing.Point(560, 12);
            this.btn_SelectDirectory.Name = "btn_SelectDirectory";
            this.btn_SelectDirectory.Size = new System.Drawing.Size(128, 64);
            this.btn_SelectDirectory.TabIndex = 1;
            this.btn_SelectDirectory.Text = "Open Folder";
            this.btn_SelectDirectory.UseVisualStyleBackColor = true;
            this.btn_SelectDirectory.Click += new System.EventHandler(this.btn_SelectDirectory_Click);
            // 
            // btn_Collapse
            // 
            this.btn_Collapse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Collapse.Location = new System.Drawing.Point(3, 415);
            this.btn_Collapse.Name = "btn_Collapse";
            this.btn_Collapse.Size = new System.Drawing.Size(32, 32);
            this.btn_Collapse.TabIndex = 4;
            this.btn_Collapse.Text = "<";
            this.btn_Collapse.UseVisualStyleBackColor = true;
            this.btn_Collapse.Click += new System.EventHandler(this.btn_Collapse_Click);
            // 
            // ReadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.pnl_Background);
            this.Name = "ReadingScreen";
            this.Text = "ReadingScreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReadingScreen_Load);
            this.ResizeEnd += new System.EventHandler(this.ReadingScreen_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Main)).EndInit();
            this.pnl_Background.ResumeLayout(false);
            this.pnl_Background.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pb_Main;
        private System.Windows.Forms.Panel pnl_Background;
        private System.Windows.Forms.FolderBrowserDialog fbd_OpenFolder;
        private System.Windows.Forms.TreeView tv_Folders;
        private System.Windows.Forms.Button btn_SelectDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Load;
        private System.Windows.Forms.Label lbl_LoadedPages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Collapse;
    }
}