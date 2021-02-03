
namespace CSV
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.jobGridView = new System.Windows.Forms.DataGridView();
            this.cmbRegion = new System.Windows.Forms.ComboBox();
            this.cmbJob = new System.Windows.Forms.ComboBox();
            this.tbSalary = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenCSV = new System.Windows.Forms.Button();
            this.openCSV = new System.Windows.Forms.OpenFileDialog();
            this.tboxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.jobGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSalary)).BeginInit();
            this.SuspendLayout();
            // 
            // jobGridView
            // 
            this.jobGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jobGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jobGridView.Location = new System.Drawing.Point(12, 74);
            this.jobGridView.Name = "jobGridView";
            this.jobGridView.ReadOnly = true;
            this.jobGridView.RowTemplate.Height = 25;
            this.jobGridView.Size = new System.Drawing.Size(918, 382);
            this.jobGridView.TabIndex = 0;
            // 
            // cmbRegion
            // 
            this.cmbRegion.FormattingEnabled = true;
            this.cmbRegion.Location = new System.Drawing.Point(18, 12);
            this.cmbRegion.Name = "cmbRegion";
            this.cmbRegion.Size = new System.Drawing.Size(125, 23);
            this.cmbRegion.TabIndex = 1;
            this.cmbRegion.SelectedIndexChanged += new System.EventHandler(this.cmbRegion_SelectedIndexChanged);
            // 
            // cmbJob
            // 
            this.cmbJob.FormattingEnabled = true;
            this.cmbJob.Location = new System.Drawing.Point(160, 12);
            this.cmbJob.Name = "cmbJob";
            this.cmbJob.Size = new System.Drawing.Size(129, 23);
            this.cmbJob.TabIndex = 2;
            this.cmbJob.SelectedIndexChanged += new System.EventHandler(this.cmbRegion_SelectedIndexChanged);
            // 
            // tbSalary
            // 
            this.tbSalary.Location = new System.Drawing.Point(306, 12);
            this.tbSalary.Name = "tbSalary";
            this.tbSalary.Size = new System.Drawing.Size(134, 45);
            this.tbSalary.TabIndex = 3;
            this.tbSalary.Scroll += new System.EventHandler(this.tbSalary_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(446, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // btnOpenCSV
            // 
            this.btnOpenCSV.Location = new System.Drawing.Point(828, 19);
            this.btnOpenCSV.Name = "btnOpenCSV";
            this.btnOpenCSV.Size = new System.Drawing.Size(71, 29);
            this.btnOpenCSV.TabIndex = 5;
            this.btnOpenCSV.Text = "Открыть";
            this.btnOpenCSV.UseVisualStyleBackColor = true;
            this.btnOpenCSV.Click += new System.EventHandler(this.btnOpenCSV_Click);
            // 
            // openCSV
            // 
            this.openCSV.FileName = "openFileDialog1";
            // 
            // tboxSearch
            // 
            this.tboxSearch.Location = new System.Drawing.Point(527, 17);
            this.tboxSearch.Name = "tboxSearch";
            this.tboxSearch.Size = new System.Drawing.Size(138, 23);
            this.tboxSearch.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(690, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(82, 31);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 468);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tboxSearch);
            this.Controls.Add(this.btnOpenCSV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSalary);
            this.Controls.Add(this.cmbJob);
            this.Controls.Add(this.cmbRegion);
            this.Controls.Add(this.jobGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.jobGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSalary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView jobGridView;
        private System.Windows.Forms.ComboBox cmbRegion;
        private System.Windows.Forms.ComboBox cmbJob;
        private System.Windows.Forms.TrackBar tbSalary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenCSV;
        private System.Windows.Forms.OpenFileDialog openCSV;
        private System.Windows.Forms.TextBox tboxSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}

