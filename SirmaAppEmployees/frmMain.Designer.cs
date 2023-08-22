namespace SirmaAppEmployees
{
    partial class frmMain
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.grdResult = new System.Windows.Forms.DataGridView();
            this.colEmpl1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmpl2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOverlapDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(469, 13);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(111, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse file";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.OnBrowseClick);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFile.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtFile.Location = new System.Drawing.Point(13, 13);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(450, 22);
            this.txtFile.TabIndex = 2;
            // 
            // grdResult
            // 
            this.grdResult.AllowUserToAddRows = false;
            this.grdResult.AllowUserToDeleteRows = false;
            this.grdResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEmpl1,
            this.colEmpl2,
            this.colProject,
            this.colOverlapDays});
            this.grdResult.Location = new System.Drawing.Point(13, 42);
            this.grdResult.Name = "grdResult";
            this.grdResult.ReadOnly = true;
            this.grdResult.RowHeadersWidth = 25;
            this.grdResult.RowTemplate.Height = 24;
            this.grdResult.Size = new System.Drawing.Size(567, 338);
            this.grdResult.TabIndex = 3;
            // 
            // colEmpl1
            // 
            this.colEmpl1.DataPropertyName = "FirstEmployee";
            this.colEmpl1.HeaderText = "Employee1";
            this.colEmpl1.MinimumWidth = 6;
            this.colEmpl1.Name = "colEmpl1";
            this.colEmpl1.ReadOnly = true;
            // 
            // colEmpl2
            // 
            this.colEmpl2.DataPropertyName = "SecondEmployee";
            this.colEmpl2.HeaderText = "Employee2";
            this.colEmpl2.MinimumWidth = 6;
            this.colEmpl2.Name = "colEmpl2";
            this.colEmpl2.ReadOnly = true;
            // 
            // colProject
            // 
            this.colProject.DataPropertyName = "ProjectID";
            this.colProject.HeaderText = "Project";
            this.colProject.MinimumWidth = 6;
            this.colProject.Name = "colProject";
            this.colProject.ReadOnly = true;
            // 
            // colOverlapDays
            // 
            this.colOverlapDays.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOverlapDays.DataPropertyName = "OverlappingDays";
            this.colOverlapDays.HeaderText = "Overlapping Days";
            this.colOverlapDays.MinimumWidth = 6;
            this.colOverlapDays.Name = "colOverlapDays";
            this.colOverlapDays.ReadOnly = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 392);
            this.Controls.Add(this.grdResult);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmMain";
            this.Text = "Employees";
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.DataGridView grdResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmpl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOverlapDays;
    }
}

