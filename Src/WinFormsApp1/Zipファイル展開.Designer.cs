namespace WinFormsApp1
{
    partial class Zipファイル展開
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
            btn実行 = new Button();
            btn全選択 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(349, 416);
            dataGridView1.TabIndex = 0;
            // 
            // btn実行
            // 
            btn実行.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn実行.Location = new Point(3, 425);
            btn実行.Name = "btn実行";
            btn実行.Size = new Size(75, 23);
            btn実行.TabIndex = 1;
            btn実行.Text = "実行";
            btn実行.UseVisualStyleBackColor = true;
            btn実行.Click += btn実行_Click;
            // 
            // btn全選択
            // 
            btn全選択.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn全選択.Location = new Point(199, 425);
            btn全選択.Name = "btn全選択";
            btn全選択.Size = new Size(75, 23);
            btn全選択.TabIndex = 2;
            btn全選択.Text = "全選択";
            btn全選択.UseVisualStyleBackColor = true;
            btn全選択.Click += btn全選択_Click;
            // 
            // Zipファイル展開
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 450);
            Controls.Add(btn全選択);
            Controls.Add(btn実行);
            Controls.Add(dataGridView1);
            Name = "Zipファイル展開";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zipファイル展開";
            Load += Zipファイル展開_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btn実行;
        private Button btn全選択;
    }
}