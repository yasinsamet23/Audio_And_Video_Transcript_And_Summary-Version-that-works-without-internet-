namespace Audio_And_Video_Transcript_And_Summary
{
    partial class MainForm
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
            btnSelect = new Button();
            btnConvert = new Button();
            txtConvertedText = new TextBox();
            btnSummarize = new Button();
            txtSummarize = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            pgbConvertTime = new ProgressBar();
            pgvSummarizeTime = new ProgressBar();
            lblSelectedFile = new Label();
            SuspendLayout();
            // 
            // btnSelect
            // 
            btnSelect.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnSelect.Location = new Point(1, 12);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(245, 41);
            btnSelect.TabIndex = 1;
            btnSelect.Text = "Select The Video Or Voice File";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnConvert
            // 
            btnConvert.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnConvert.Location = new Point(5, 72);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(158, 38);
            btnConvert.TabIndex = 3;
            btnConvert.Text = "Convert To Text";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // txtConvertedText
            // 
            txtConvertedText.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtConvertedText.Location = new Point(1, 116);
            txtConvertedText.Multiline = true;
            txtConvertedText.Name = "txtConvertedText";
            txtConvertedText.ScrollBars = ScrollBars.Vertical;
            txtConvertedText.Size = new Size(1012, 273);
            txtConvertedText.TabIndex = 4;
            
            // 
            // btnSummarize
            // 
            btnSummarize.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnSummarize.Location = new Point(5, 395);
            btnSummarize.Name = "btnSummarize";
            btnSummarize.Size = new Size(211, 46);
            btnSummarize.TabIndex = 6;
            btnSummarize.Text = "Summarize The Text";
            btnSummarize.UseVisualStyleBackColor = true;
            btnSummarize.Click += btnSummarize_Click;
            // 
            // txtSummarize
            // 
            txtSummarize.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtSummarize.Location = new Point(1, 447);
            txtSummarize.Multiline = true;
            txtSummarize.Name = "txtSummarize";
            txtSummarize.ReadOnly = true;
            txtSummarize.ScrollBars = ScrollBars.Vertical;
            txtSummarize.Size = new Size(1012, 239);
            txtSummarize.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // pgbConvertTime
            // 
            pgbConvertTime.Location = new Point(377, 34);
            pgbConvertTime.Name = "pgbConvertTime";
            pgbConvertTime.Size = new Size(125, 29);
            pgbConvertTime.TabIndex = 8;
            // 
            // pgvSummarizeTime
            // 
            pgvSummarizeTime.Location = new Point(377, 395);
            pgvSummarizeTime.Name = "pgvSummarizeTime";
            pgvSummarizeTime.Size = new Size(125, 29);
            pgvSummarizeTime.TabIndex = 9;
            // 
            // lblSelectedFile
            // 
            lblSelectedFile.AutoSize = true;
            lblSelectedFile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblSelectedFile.Location = new Point(216, 72);
            lblSelectedFile.Name = "lblSelectedFile";
            lblSelectedFile.Size = new Size(0, 28);
            lblSelectedFile.TabIndex = 10;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 774);
            Controls.Add(lblSelectedFile);
            Controls.Add(pgvSummarizeTime);
            Controls.Add(pgbConvertTime);
            Controls.Add(txtSummarize);
            Controls.Add(btnSummarize);
            Controls.Add(txtConvertedText);
            Controls.Add(btnConvert);
            Controls.Add(btnSelect);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnSelect;
        private Button btnConvert;
        private TextBox txtConvertedText;
        private Button btnSummarize;
        private TextBox txtSummarize;
        private OpenFileDialog openFileDialog1;
        private ProgressBar pgbConvertTime;
        private ProgressBar pgvSummarizeTime;
        private Label lblSelectedFile;
    }
}
