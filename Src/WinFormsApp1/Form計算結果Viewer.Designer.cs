namespace WinFormsApp1
{
    partial class Form計算結果Viewer
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
            dataGridView1 = new DataGridView();
            cmbSelectType = new ComboBox();
            btn更新 = new Button();
            label11 = new Label();
            cmbYear = new ComboBox();
            btnCSVファイル出力 = new Button();
            btnHTMLファイル出力 = new Button();
            btn詳細条件 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(2, 31);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(797, 390);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.ColumnHeaderMouseClick += dataGridView1_ColumnHeaderMouseClick;
            // 
            // cmbSelectType
            // 
            cmbSelectType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectType.FormattingEnabled = true;
            cmbSelectType.Location = new Point(12, 5);
            cmbSelectType.Name = "cmbSelectType";
            cmbSelectType.Size = new Size(121, 23);
            cmbSelectType.TabIndex = 1;
            // 
            // btn更新
            // 
            btn更新.Location = new Point(478, 2);
            btn更新.Name = "btn更新";
            btn更新.Size = new Size(75, 23);
            btn更新.TabIndex = 2;
            btn更新.Text = "更新";
            btn更新.UseVisualStyleBackColor = true;
            btn更新.Click += btn更新_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(170, 6);
            label11.Name = "label11";
            label11.Size = new Size(67, 15);
            label11.TabIndex = 27;
            label11.Text = "計算対象年";
            // 
            // cmbYear
            // 
            cmbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYear.FormattingEnabled = true;
            cmbYear.Location = new Point(241, 3);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new Size(73, 23);
            cmbYear.TabIndex = 26;
            // 
            // btnCSVファイル出力
            // 
            btnCSVファイル出力.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCSVファイル出力.Location = new Point(2, 424);
            btnCSVファイル出力.Name = "btnCSVファイル出力";
            btnCSVファイル出力.Size = new Size(75, 23);
            btnCSVファイル出力.TabIndex = 28;
            btnCSVファイル出力.Text = "CSVファイル出力";
            btnCSVファイル出力.UseVisualStyleBackColor = true;
            btnCSVファイル出力.Click += btnCSVファイル出力_Click;
            // 
            // btnHTMLファイル出力
            // 
            btnHTMLファイル出力.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnHTMLファイル出力.Location = new Point(95, 426);
            btnHTMLファイル出力.Name = "btnHTMLファイル出力";
            btnHTMLファイル出力.Size = new Size(126, 23);
            btnHTMLファイル出力.TabIndex = 29;
            btnHTMLファイル出力.Text = "HTMLファイル出力";
            btnHTMLファイル出力.UseVisualStyleBackColor = true;
            btnHTMLファイル出力.Click += btnHTMLファイル出力_Click;
            // 
            // btn詳細条件
            // 
            btn詳細条件.Location = new Point(338, 4);
            btn詳細条件.Name = "btn詳細条件";
            btn詳細条件.Size = new Size(75, 23);
            btn詳細条件.TabIndex = 30;
            btn詳細条件.Text = "詳細条件";
            btn詳細条件.UseVisualStyleBackColor = true;
            btn詳細条件.Click += btn詳細条件_Click;
            // 
            // Form計算結果Viewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn詳細条件);
            Controls.Add(btnHTMLファイル出力);
            Controls.Add(btnCSVファイル出力);
            Controls.Add(label11);
            Controls.Add(cmbYear);
            Controls.Add(btn更新);
            Controls.Add(cmbSelectType);
            Controls.Add(dataGridView1);
            Name = "Form計算結果Viewer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form計算結果Viewer";
            WindowState = FormWindowState.Maximized;
            Load += Form計算結果Viewer_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox cmbSelectType;
        private Button btn更新;
        private Label label11;
        private ComboBox cmbYear;
        private Button btnCSVファイル出力;
        private Button btnHTMLファイル出力;
        private Button button1;
        private Button btn詳細条件;
    }
}