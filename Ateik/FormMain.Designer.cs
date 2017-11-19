namespace Ateik
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.btnLoadImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbDimensions = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.changePose = new System.Windows.Forms.ToolStripDropDownButton();
            this.rotateCW = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateCCW = new System.Windows.Forms.ToolStripMenuItem();
            this.flipHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.flipVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripButton();
            this.statusbar = new System.Windows.Forms.StatusStrip();
            this.lblInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel = new System.Windows.Forms.Panel();
            this.toolbar.SuspendLayout();
            this.statusbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadImage,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.cmbDimensions,
            this.toolStripSeparator2,
            this.changePose,
            this.btnSettings,
            this.toolStripSeparator3,
            this.btnExit});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolbar.Size = new System.Drawing.Size(467, 25);
            this.toolbar.TabIndex = 1;
            this.toolbar.Text = "toolBar";
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Image = global::Ateik.Properties.Resources.person16;
            this.btnLoadImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(51, 22);
            this.btnLoadImage.Text = "Foto";
            this.btnLoadImage.ToolTipText = "Pasirinkti fotografiją";
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(84, 22);
            this.toolStripLabel1.Text = "Plotis : aukštis";
            // 
            // cmbDimensions
            // 
            this.cmbDimensions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDimensions.Name = "cmbDimensions";
            this.cmbDimensions.Size = new System.Drawing.Size(75, 25);
            this.cmbDimensions.ToolTipText = "Pasirinkti rezultato išmatavimus (pikseliais)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // changePose
            // 
            this.changePose.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotateCW,
            this.rotateCCW,
            this.flipHorizontal,
            this.flipVertical});
            this.changePose.Enabled = false;
            this.changePose.Image = global::Ateik.Properties.Resources.pose16;
            this.changePose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.changePose.Name = "changePose";
            this.changePose.Size = new System.Drawing.Size(64, 22);
            this.changePose.Text = "Poza";
            this.changePose.ToolTipText = "Keisti pozą";
            // 
            // rotateCW
            // 
            this.rotateCW.Image = global::Ateik.Properties.Resources.rotatecw16;
            this.rotateCW.Name = "rotateCW";
            this.rotateCW.Size = new System.Drawing.Size(235, 22);
            this.rotateCW.Text = "sukti pagal laikrodžio rodyklę";
            this.rotateCW.Click += new System.EventHandler(this.rotateCW_Click);
            // 
            // rotateCCW
            // 
            this.rotateCCW.Image = global::Ateik.Properties.Resources.rotatecc16;
            this.rotateCCW.Name = "rotateCCW";
            this.rotateCCW.Size = new System.Drawing.Size(235, 22);
            this.rotateCCW.Text = "sukti prieš laikrodžio rodyklę";
            this.rotateCCW.Click += new System.EventHandler(this.rotateCCW_Click);
            // 
            // flipHorizontal
            // 
            this.flipHorizontal.Image = global::Ateik.Properties.Resources.fliph16;
            this.flipHorizontal.Name = "flipHorizontal";
            this.flipHorizontal.Size = new System.Drawing.Size(235, 22);
            this.flipHorizontal.Text = "atspindėti horizontaliai";
            this.flipHorizontal.Click += new System.EventHandler(this.flipHorizontal_Click);
            // 
            // flipVertical
            // 
            this.flipVertical.Image = global::Ateik.Properties.Resources.flipv16;
            this.flipVertical.Name = "flipVertical";
            this.flipVertical.Size = new System.Drawing.Size(235, 22);
            this.flipVertical.Text = "atspindėti vertikaliai";
            this.flipVertical.Click += new System.EventHandler(this.flipVertical_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Image = global::Ateik.Properties.Resources.tools16;
            this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(88, 22);
            this.btnSettings.Text = "Nustatymai";
            this.btnSettings.ToolTipText = "Keisti nustatymus";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::Ateik.Properties.Resources.quit;
            this.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(52, 22);
            this.btnExit.Text = "Išeiti";
            this.btnExit.ToolTipText = "Baigti, uždaryti programą";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // statusbar
            // 
            this.statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInfo});
            this.statusbar.Location = new System.Drawing.Point(0, 293);
            this.statusbar.Name = "statusbar";
            this.statusbar.Padding = new System.Windows.Forms.Padding(2, 0, 15, 0);
            this.statusbar.Size = new System.Drawing.Size(467, 22);
            this.statusbar.TabIndex = 2;
            this.statusbar.Text = "statusBar";
            // 
            // lblInfo
            // 
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(39, 17);
            this.lblInfo.Text = "Info...";
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 25);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(467, 268);
            this.panel.TabIndex = 3;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 315);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.statusbar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ateik";
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.statusbar.ResumeLayout(false);
            this.statusbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton btnLoadImage;
        private System.Windows.Forms.ToolStripComboBox cmbDimensions;
        private System.Windows.Forms.ToolStripButton btnExit;
        private System.Windows.Forms.StatusStrip statusbar;
        private System.Windows.Forms.ToolStripStatusLabel lblInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolStripButton btnSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton changePose;
        private System.Windows.Forms.ToolStripMenuItem rotateCW;
        private System.Windows.Forms.ToolStripMenuItem rotateCCW;
        private System.Windows.Forms.ToolStripMenuItem flipHorizontal;
        private System.Windows.Forms.ToolStripMenuItem flipVertical;
        //private ewalControl.ImageClipper imgClipper;
    }
}

