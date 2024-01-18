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
            btnCSVファイル出力 = new Button();
            btnHTMLファイル出力 = new Button();
            btn抽出条件設定 = new Button();
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
            // btn抽出条件設定
            // 
            btn抽出条件設定.Location = new Point(2, 3);
            btn抽出条件設定.Name = "btn抽出条件設定";
            btn抽出条件設定.Size = new Size(107, 23);
            btn抽出条件設定.TabIndex = 30;
            btn抽出条件設定.Text = "抽出条件設定";
            btn抽出条件設定.UseVisualStyleBackColor = true;
            btn抽出条件設定.Click += btn詳細条件_Click;
            // 
            // Form計算結果Viewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn抽出条件設定);
            Controls.Add(btnHTMLファイル出力);
            Controls.Add(btnCSVファイル出力);
            Controls.Add(dataGridView1);
            Name = "Form計算結果Viewer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form計算結果Viewer";
            WindowState = FormWindowState.Maximized;
            Load += Form計算結果Viewer_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btn更新;
        private Label label11;
        private Button btnCSVファイル出力;
        private Button btnHTMLファイル出力;
        private Button button1;
        private Button btn詳細条件;
        private Button btn抽出条件;
        private Button btn抽出条件設定;
    }
}