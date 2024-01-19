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
            cmbSelectType = new ComboBox();
            cmbYear = new ComboBox();
            label6 = new Label();
            txt固定測定局コード = new TextBox();
            label8 = new Label();
            chk固定測定局コード = new CheckBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView対象都道府県).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "対象都道府県";
            // 
            // dataGridView対象都道府県
            // 
            dataGridView対象都道府県.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dataGridView対象都道府県.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView対象都道府県.Location = new Point(12, 45);
            dataGridView対象都道府県.Name = "dataGridView対象都道府県";
            dataGridView対象都道府県.RowTemplate.Height = 25;
            dataGridView対象都道府県.Size = new Size(336, 476);
            dataGridView対象都道府県.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(252, 570);
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
            btnキャンセル.DialogResult = DialogResult.Cancel;
            btnキャンセル.Location = new Point(347, 570);
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
            label2.Location = new Point(365, 121);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 4;
            label2.Text = "PM2.5";
            // 
            // txtMaxPM25
            // 
            txtMaxPM25.Location = new Point(411, 118);
            txtMaxPM25.Name = "txtMaxPM25";
            txtMaxPM25.Size = new Size(100, 23);
            txtMaxPM25.TabIndex = 5;
            txtMaxPM25.Text = "80000";
            txtMaxPM25.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(517, 121);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 6;
            label3.Text = "以下";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(517, 150);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 9;
            label4.Text = "以下";
            // 
            // txtMaxNOx2
            // 
            txtMaxNOx2.Location = new Point(411, 147);
            txtMaxNOx2.Name = "txtMaxNOx2";
            txtMaxNOx2.Size = new Size(100, 23);
            txtMaxNOx2.TabIndex = 8;
            txtMaxNOx2.Text = "50";
            txtMaxNOx2.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(365, 150);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 7;
            label5.Text = "NOx2";
            // 
            // cmbSelectType
            // 
            cmbSelectType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectType.FormattingEnabled = true;
            cmbSelectType.Location = new Point(438, 48);
            cmbSelectType.Name = "cmbSelectType";
            cmbSelectType.Size = new Size(121, 23);
            cmbSelectType.TabIndex = 1;
            // 
            // cmbYear
            // 
            cmbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYear.FormattingEnabled = true;
            cmbYear.Location = new Point(438, 77);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new Size(73, 23);
            cmbYear.TabIndex = 26;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(365, 80);
            label6.Name = "label6";
            label6.Size = new Size(67, 15);
            label6.TabIndex = 27;
            label6.Text = "計算対象年";
            // 
            // txt固定測定局コード
            // 
            txt固定測定局コード.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txt固定測定局コード.Location = new Point(9, 13);
            txt固定測定局コード.Multiline = true;
            txt固定測定局コード.Name = "txt固定測定局コード";
            txt固定測定局コード.Size = new Size(143, 502);
            txt固定測定局コード.TabIndex = 29;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(365, 51);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 30;
            label8.Text = "抽出区分";
            // 
            // chk固定測定局コード
            // 
            chk固定測定局コード.AutoSize = true;
            chk固定測定局コード.Location = new Point(13, 12);
            chk固定測定局コード.Name = "chk固定測定局コード";
            chk固定測定局コード.Size = new Size(110, 19);
            chk固定測定局コード.TabIndex = 31;
            chk固定測定局コード.Text = "固定測定局コード";
            chk固定測定局コード.UseVisualStyleBackColor = true;
            chk固定測定局コード.CheckedChanged += chk固定測定局コード_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(txt固定測定局コード);
            groupBox1.Location = new Point(13, 37);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(160, 527);
            groupBox1.TabIndex = 32;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox2.Controls.Add(dataGridView対象都道府県);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(cmbSelectType);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtMaxNOx2);
            groupBox2.Controls.Add(txtMaxPM25);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(cmbYear);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(188, 37);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(583, 527);
            groupBox2.TabIndex = 33;
            groupBox2.TabStop = false;
            // 
            // Form詳細条件
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 601);
            Controls.Add(chk固定測定局コード);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnキャンセル);
            Controls.Add(btnOK);
            Name = "Form詳細条件";
            Text = "Form詳細条件";
            Load += Form詳細条件_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView対象都道府県).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
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
        private ComboBox cmbSelectType;
        private ComboBox cmbYear;
        private Label label6;
        private TextBox txt固定測定局コード;
        private Label label8;
        private CheckBox chk固定測定局コード;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}