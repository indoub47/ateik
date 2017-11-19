namespace Ateik
{
    partial class FormSettings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.dgvSizes = new System.Windows.Forms.DataGridView();
            this.width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nudTopMarginHeight = new System.Windows.Forms.NumericUpDown();
            this.nudBottomMarginHeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chbShowSight = new System.Windows.Forms.CheckBox();
            this.chbPlaySound = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSizes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopMarginHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBottomMarginHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSizes
            // 
            this.dgvSizes.AllowUserToResizeRows = false;
            this.dgvSizes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSizes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSizes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSizes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.width,
            this.height});
            this.dgvSizes.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvSizes.Location = new System.Drawing.Point(0, 0);
            this.dgvSizes.MultiSelect = false;
            this.dgvSizes.Name = "dgvSizes";
            this.dgvSizes.RowHeadersWidth = 39;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#";
            dataGridViewCellStyle3.NullValue = "0";
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.dgvSizes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSizes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSizes.Size = new System.Drawing.Size(250, 167);
            this.dgvSizes.TabIndex = 0;
            // 
            // width
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "#";
            dataGridViewCellStyle1.NullValue = "0";
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.width.DefaultCellStyle = dataGridViewCellStyle1;
            this.width.HeaderText = "Plotis, px";
            this.width.Name = "width";
            // 
            // height
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#";
            dataGridViewCellStyle2.NullValue = "0";
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.height.DefaultCellStyle = dataGridViewCellStyle2;
            this.height.HeaderText = "Aukštis, px";
            this.height.Name = "height";
            // 
            // nudTopMarginHeight
            // 
            this.nudTopMarginHeight.Location = new System.Drawing.Point(167, 184);
            this.nudTopMarginHeight.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudTopMarginHeight.Name = "nudTopMarginHeight";
            this.nudTopMarginHeight.Size = new System.Drawing.Size(52, 20);
            this.nudTopMarginHeight.TabIndex = 1;
            // 
            // nudBottomMarginHeight
            // 
            this.nudBottomMarginHeight.Location = new System.Drawing.Point(167, 210);
            this.nudBottomMarginHeight.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudBottomMarginHeight.Name = "nudBottomMarginHeight";
            this.nudBottomMarginHeight.Size = new System.Drawing.Size(52, 20);
            this.nudBottomMarginHeight.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Viršutinės paraštės aukštis, %";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Apatinės paraštės aukštis, %";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(144, 276);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(23, 276);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chbShowSight
            // 
            this.chbShowSight.AutoSize = true;
            this.chbShowSight.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbShowSight.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbShowSight.Location = new System.Drawing.Point(131, 244);
            this.chbShowSight.Name = "chbShowSight";
            this.chbShowSight.Size = new System.Drawing.Size(88, 17);
            this.chbShowSight.TabIndex = 7;
            this.chbShowSight.Text = "Rodyti taikiklį";
            this.chbShowSight.UseVisualStyleBackColor = true;
            // 
            // chbPlaySound
            // 
            this.chbPlaySound.AutoSize = true;
            this.chbPlaySound.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbPlaySound.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbPlaySound.Location = new System.Drawing.Point(23, 244);
            this.chbPlaySound.Name = "chbPlaySound";
            this.chbPlaySound.Size = new System.Drawing.Size(88, 17);
            this.chbPlaySound.TabIndex = 8;
            this.chbPlaySound.Text = "Skleisti garsą";
            this.chbPlaySound.UseVisualStyleBackColor = true;
            // 
            // fSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 316);
            this.Controls.Add(this.chbPlaySound);
            this.Controls.Add(this.chbShowSight);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudBottomMarginHeight);
            this.Controls.Add(this.nudTopMarginHeight);
            this.Controls.Add(this.dgvSizes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fSettings";
            this.Text = "fSettings";
            this.Load += new System.EventHandler(this.fSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSizes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTopMarginHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBottomMarginHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSizes;
        private System.Windows.Forms.NumericUpDown nudTopMarginHeight;
        private System.Windows.Forms.NumericUpDown nudBottomMarginHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn width;
        private System.Windows.Forms.DataGridViewTextBoxColumn height;
        private System.Windows.Forms.CheckBox chbShowSight;
        private System.Windows.Forms.CheckBox chbPlaySound;
    }
}