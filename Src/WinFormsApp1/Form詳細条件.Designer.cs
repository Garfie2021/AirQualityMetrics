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
            dataGridView対象都道府県.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView対象都道府県.Location = new Point(13, 32);
            dataGridView対象都道府県.Name = "dataGridView対象都道府県";
            dataGridView対象都道府県.RowTemplate.Height = 25;
            dataGridView対象都道府県.Size = new Size(336, 255);
            dataGridView対象都道府県.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(252, 403);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnキャンセル
            // 
            btnキャンセル.Location = new Point(347, 403);
            btnキャンセル.Name = "btnキャンセル";
            btnキャンセル.Size = new Size(75, 23);
            btnキャンセル.TabIndex = 3;
            btnキャンセル.Text = "キャンセル";
            btnキャンセル.UseVisualStyleBackColor = true;
            btnキャンセル.Click += btnキャンセル_Click;
            // 
            // Form詳細条件
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}