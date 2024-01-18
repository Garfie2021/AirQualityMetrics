namespace WinFormsApp1
{
    partial class Form詳細条件
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
            label1 = new Label();
            dataGridView対象都道府県 = new DataGridView();
            btnOK = new Button();
            btnキャンセル = new Button();
            label2 = new Label();
            txtMaxPM25 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtMaxNOx2 = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView対象都道府県).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 12);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "対象都道府県";
            // 
            // dataGridView対象都道府県
            // 
            dataGridView対象都道府県.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dataGridView対象都道府県.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView対象都道府県.Location = new Point(13, 32);
            dataGridView対象都道府県.Name = "dataGridView対象都道府県";
            dataGridView対象都道府県.RowTemplate.Height = 25;
            dataGridView対象都道府県.Size = new Size(336, 381);
            dataGridView対象都道府県.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOK.Location = new Point(252, 419);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnキャンセル
            // 
            btnキャンセル.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnキャンセル.Location = new Point(347, 419);
            btnキャンセル.Name = "btnキャンセル";
            btnキャンセル.Size = new Size(75, 23);
            btnキャンセル.TabIndex = 3;
            btnキャンセル.Text = "キャンセル";
            btnキャンセル.UseVisualStyleBackColor = true;
            btnキャンセル.Click += btnキャンセル_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(366, 32);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 4;
            label2.Text = "PM2.5";
            // 
            // txtMaxPM25
            // 
            txtMaxPM25.Location = new Point(412, 29);
            txtMaxPM25.Name = "txtMaxPM25";
            txtMaxPM25.Size = new Size(100, 23);
            txtMaxPM25.TabIndex = 5;
            txtMaxPM25.Text = "80000";
            txtMaxPM25.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(518, 32);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 6;
            label3.Text = "以下";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(518, 61);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 9;
            label4.Text = "以下";
            // 
            // txtMaxNOx2
            // 
            txtMaxNOx2.Location = new Point(412, 58);
            txtMaxNOx2.Name = "txtMaxNOx2";
            txtMaxNOx2.Size = new Size(100, 23);
            txtMaxNOx2.TabIndex = 8;
            txtMaxNOx2.Text = "50";
            txtMaxNOx2.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(366, 61);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 7;
            label5.Text = "NOx2";
            // 
            // Form詳細条件
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(txtMaxNOx2);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(txtMaxPM25);
            Controls.Add(label2);
            Controls.Add(btnキャンセル);
            Controls.Add(btnOK);
            Controls.Add(dataGridView対象都道府県);
            Controls.Add(label1);
            Name = "Form詳細条件";
            Text = "Form詳細条件";
            Load += Form詳細条件_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView対象都道府県).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView対象都道府県;
        private Button btnOK;
        private Button btnキャンセル;
        private Label label2;
        private TextBox txtMaxPM25;
        private Label label3;
        private Label label4;
        private TextBox txtMaxNOx2;
        private Label label5;
    }
}