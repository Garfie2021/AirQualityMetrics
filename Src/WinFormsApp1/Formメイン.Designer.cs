namespace WinFormsApp1
{
    partial class Formメイン
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formメイン));
            txtConnectionString = new TextBox();
            txtZipFolderPath = new TextBox();
            label1 = new Label();
            label3 = new Label();
            btnSelectFolder = new Button();
            btnClearData = new Button();
            btnExtractZip = new Button();
            btnCsvFileImport = new Button();
            label4 = new Label();
            txtWorkFolderPath = new TextBox();
            btnSelectFolder_Work = new Button();
            btnCulcSummary = new Button();
            textBox1 = new TextBox();
            groupBox1 = new GroupBox();
            chkZip解凍ファイル = new CheckBox();
            chkサマリーデータ = new CheckBox();
            chk変換後データ = new CheckBox();
            chkインポートデータ = new CheckBox();
            groupBox2 = new GroupBox();
            txtStartRow = new TextBox();
            label2 = new Label();
            btnインポートしたデータを検証 = new Button();
            btn変換したデータを検証 = new Button();
            btnImportDataConvert = new Button();
            cmbYear = new ComboBox();
            groupBox6 = new GroupBox();
            btnMapURL生成 = new Button();
            btnインポートしたデータを検証_測定局一覧_都道府県 = new Button();
            btnCSVファイルインポート実行_測定局一覧_都道府県 = new Button();
            btn測定局一覧都道府県データファイルパス = new Button();
            txt測定局一覧都道府県データファイルパス = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            btn変換したデータを検証_測定局一覧 = new Button();
            btn正規テーブルへ変換_測定局一覧 = new Button();
            btnインポートしたデータを検証_測定局一覧 = new Button();
            btnファイル選択_測定局一覧CSVファイルパス = new Button();
            btnCSVファイルインポート実行_測定局一覧 = new Button();
            txt測定局一覧データファイルパス = new TextBox();
            label7 = new Label();
            label5 = new Label();
            label6 = new Label();
            groupBox4 = new GroupBox();
            btn計算結果を確認 = new Button();
            btnサマリー計算結果を検証 = new Button();
            label11 = new Label();
            btn更新_cmbYear = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // txtConnectionString
            // 
            txtConnectionString.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtConnectionString.Location = new Point(131, 9);
            txtConnectionString.Name = "txtConnectionString";
            txtConnectionString.Size = new Size(1145, 23);
            txtConnectionString.TabIndex = 1;
            // 
            // txtZipFolderPath
            // 
            txtZipFolderPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtZipFolderPath.Location = new Point(202, 17);
            txtZipFolderPath.Name = "txtZipFolderPath";
            txtZipFolderPath.Size = new Size(976, 23);
            txtZipFolderPath.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 4;
            label1.Text = "ConnectionString";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 22);
            label3.Name = "label3";
            label3.Size = new Size(142, 15);
            label3.TabIndex = 6;
            label3.Text = "Zipファイル保存Folder Path";
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectFolder.Location = new Point(1183, 15);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(75, 23);
            btnSelectFolder.TabIndex = 7;
            btnSelectFolder.Text = "フォルダ選択";
            btnSelectFolder.UseVisualStyleBackColor = true;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // btnClearData
            // 
            btnClearData.Location = new Point(418, 17);
            btnClearData.Name = "btnClearData";
            btnClearData.Size = new Size(84, 23);
            btnClearData.TabIndex = 8;
            btnClearData.Text = "削除実行";
            btnClearData.UseVisualStyleBackColor = true;
            btnClearData.Click += btnClearData_Click;
            // 
            // btnExtractZip
            // 
            btnExtractZip.Location = new Point(9, 72);
            btnExtractZip.Name = "btnExtractZip";
            btnExtractZip.Size = new Size(212, 23);
            btnExtractZip.TabIndex = 9;
            btnExtractZip.Text = "ZipファイルをWorkフォルダ配下に展開";
            btnExtractZip.UseVisualStyleBackColor = true;
            btnExtractZip.Click += btnExtractZip_Click;
            // 
            // btnCsvFileImport
            // 
            btnCsvFileImport.Location = new Point(227, 72);
            btnCsvFileImport.Name = "btnCsvFileImport";
            btnCsvFileImport.Size = new Size(139, 23);
            btnCsvFileImport.TabIndex = 10;
            btnCsvFileImport.Text = "CSVファイルをインポート";
            btnCsvFileImport.UseVisualStyleBackColor = true;
            btnCsvFileImport.Click += btnCsvFileImport_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 47);
            label4.Name = "label4";
            label4.Size = new Size(185, 15);
            label4.TabIndex = 12;
            label4.Text = "Zipファイル展開先Work Folder Path";
            // 
            // txtWorkFolderPath
            // 
            txtWorkFolderPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtWorkFolderPath.Location = new Point(202, 43);
            txtWorkFolderPath.Name = "txtWorkFolderPath";
            txtWorkFolderPath.Size = new Size(976, 23);
            txtWorkFolderPath.TabIndex = 11;
            // 
            // btnSelectFolder_Work
            // 
            btnSelectFolder_Work.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectFolder_Work.Location = new Point(1183, 44);
            btnSelectFolder_Work.Name = "btnSelectFolder_Work";
            btnSelectFolder_Work.Size = new Size(75, 23);
            btnSelectFolder_Work.TabIndex = 15;
            btnSelectFolder_Work.Text = "フォルダ選択";
            btnSelectFolder_Work.UseVisualStyleBackColor = true;
            btnSelectFolder_Work.Click += btnSelectFolder_Work_Click;
            // 
            // btnCulcSummary
            // 
            btnCulcSummary.Location = new Point(227, 22);
            btnCulcSummary.Name = "btnCulcSummary";
            btnCulcSummary.Size = new Size(76, 23);
            btnCulcSummary.TabIndex = 19;
            btnCulcSummary.Text = "計算実行";
            btnCulcSummary.UseVisualStyleBackColor = true;
            btnCulcSummary.Click += btnCulcSummary_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox1.Location = new Point(791, 315);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(462, 302);
            textBox1.TabIndex = 20;
            textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkZip解凍ファイル);
            groupBox1.Controls.Add(chkサマリーデータ);
            groupBox1.Controls.Add(chk変換後データ);
            groupBox1.Controls.Add(chkインポートデータ);
            groupBox1.Controls.Add(btnClearData);
            groupBox1.Location = new Point(6, 38);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(785, 51);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "0.データ削除";
            // 
            // chkZip解凍ファイル
            // 
            chkZip解凍ファイル.AutoSize = true;
            chkZip解凍ファイル.Location = new Point(12, 20);
            chkZip解凍ファイル.Name = "chkZip解凍ファイル";
            chkZip解凍ファイル.Size = new Size(101, 19);
            chkZip解凍ファイル.TabIndex = 12;
            chkZip解凍ファイル.Text = "Zip解凍ファイル";
            chkZip解凍ファイル.UseVisualStyleBackColor = true;
            // 
            // chkサマリーデータ
            // 
            chkサマリーデータ.AutoSize = true;
            chkサマリーデータ.Location = new Point(325, 20);
            chkサマリーデータ.Name = "chkサマリーデータ";
            chkサマリーデータ.Size = new Size(87, 19);
            chkサマリーデータ.TabIndex = 11;
            chkサマリーデータ.Text = "サマリーデータ";
            chkサマリーデータ.UseVisualStyleBackColor = true;
            // 
            // chk変換後データ
            // 
            chk変換後データ.AutoSize = true;
            chk変換後データ.Location = new Point(231, 20);
            chk変換後データ.Name = "chk変換後データ";
            chk変換後データ.Size = new Size(88, 19);
            chk変換後データ.TabIndex = 10;
            chk変換後データ.Text = "変換後データ";
            chk変換後データ.UseVisualStyleBackColor = true;
            // 
            // chkインポートデータ
            // 
            chkインポートデータ.AutoSize = true;
            chkインポートデータ.Location = new Point(120, 20);
            chkインポートデータ.Name = "chkインポートデータ";
            chkインポートデータ.Size = new Size(96, 19);
            chkインポートデータ.TabIndex = 9;
            chkインポートデータ.Text = "インポートデータ";
            chkインポートデータ.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(txtStartRow);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtZipFolderPath);
            groupBox2.Controls.Add(btnインポートしたデータを検証);
            groupBox2.Controls.Add(btnExtractZip);
            groupBox2.Controls.Add(btn変換したデータを検証);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(btnImportDataConvert);
            groupBox2.Controls.Add(btnCsvFileImport);
            groupBox2.Controls.Add(btnSelectFolder);
            groupBox2.Controls.Add(btnSelectFolder_Work);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtWorkFolderPath);
            groupBox2.Location = new Point(6, 95);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1265, 104);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "1. 測定データ";
            // 
            // txtStartRow
            // 
            txtStartRow.Location = new Point(649, 73);
            txtStartRow.Name = "txtStartRow";
            txtStartRow.Size = new Size(100, 23);
            txtStartRow.TabIndex = 21;
            txtStartRow.Text = "1";
            txtStartRow.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.Location = new Point(588, 76);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 22;
            label2.Text = "StartRow：";
            // 
            // btnインポートしたデータを検証
            // 
            btnインポートしたデータを検証.Location = new Point(372, 72);
            btnインポートしたデータを検証.Name = "btnインポートしたデータを検証";
            btnインポートしたデータを検証.Size = new Size(166, 23);
            btnインポートしたデータを検証.TabIndex = 15;
            btnインポートしたデータを検証.Text = "インポートしたデータを検証";
            btnインポートしたデータを検証.UseVisualStyleBackColor = true;
            btnインポートしたデータを検証.Click += btnインポートしたデータを検証_Click;
            // 
            // btn変換したデータを検証
            // 
            btn変換したデータを検証.Location = new Point(877, 73);
            btn変換したデータを検証.Name = "btn変換したデータを検証";
            btn変換したデータを検証.Size = new Size(128, 23);
            btn変換したデータを検証.TabIndex = 19;
            btn変換したデータを検証.Text = "変換したデータを検証";
            btn変換したデータを検証.UseVisualStyleBackColor = true;
            btn変換したデータを検証.Click += btn変換したデータを検証_Click;
            // 
            // btnImportDataConvert
            // 
            btnImportDataConvert.Location = new Point(755, 72);
            btnImportDataConvert.Name = "btnImportDataConvert";
            btnImportDataConvert.Size = new Size(116, 23);
            btnImportDataConvert.TabIndex = 16;
            btnImportDataConvert.Text = "正規テーブルへ変換";
            btnImportDataConvert.UseVisualStyleBackColor = true;
            btnImportDataConvert.Click += btnImportDataConvert_Click;
            // 
            // cmbYear
            // 
            cmbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYear.FormattingEnabled = true;
            cmbYear.Location = new Point(80, 23);
            cmbYear.Name = "cmbYear";
            cmbYear.Size = new Size(73, 23);
            cmbYear.TabIndex = 23;
            // 
            // groupBox6
            // 
            groupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox6.Controls.Add(btnMapURL生成);
            groupBox6.Controls.Add(btnインポートしたデータを検証_測定局一覧_都道府県);
            groupBox6.Controls.Add(btnCSVファイルインポート実行_測定局一覧_都道府県);
            groupBox6.Controls.Add(btn測定局一覧都道府県データファイルパス);
            groupBox6.Controls.Add(txt測定局一覧都道府県データファイルパス);
            groupBox6.Controls.Add(label8);
            groupBox6.Controls.Add(label9);
            groupBox6.Controls.Add(label10);
            groupBox6.Controls.Add(btn変換したデータを検証_測定局一覧);
            groupBox6.Controls.Add(btn正規テーブルへ変換_測定局一覧);
            groupBox6.Controls.Add(btnインポートしたデータを検証_測定局一覧);
            groupBox6.Controls.Add(btnファイル選択_測定局一覧CSVファイルパス);
            groupBox6.Controls.Add(btnCSVファイルインポート実行_測定局一覧);
            groupBox6.Controls.Add(txt測定局一覧データファイルパス);
            groupBox6.Controls.Add(label7);
            groupBox6.Controls.Add(label5);
            groupBox6.Controls.Add(label6);
            groupBox6.Location = new Point(6, 205);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(1247, 104);
            groupBox6.TabIndex = 26;
            groupBox6.TabStop = false;
            groupBox6.Text = "2. 測定局マスタ";
            // 
            // btnMapURL生成
            // 
            btnMapURL生成.Location = new Point(1044, 68);
            btnMapURL生成.Name = "btnMapURL生成";
            btnMapURL生成.Size = new Size(116, 23);
            btnMapURL生成.TabIndex = 39;
            btnMapURL生成.Text = "URL生成";
            btnMapURL生成.UseVisualStyleBackColor = true;
            btnMapURL生成.Click += btnMapURL生成_Click;
            // 
            // btnインポートしたデータを検証_測定局一覧_都道府県
            // 
            btnインポートしたデータを検証_測定局一覧_都道府県.Location = new Point(520, 69);
            btnインポートしたデータを検証_測定局一覧_都道府県.Name = "btnインポートしたデータを検証_測定局一覧_都道府県";
            btnインポートしたデータを検証_測定局一覧_都道府県.Size = new Size(207, 23);
            btnインポートしたデータを検証_測定局一覧_都道府県.TabIndex = 38;
            btnインポートしたデータを検証_測定局一覧_都道府県.Text = "インポートしたデータを検証（都道府県）";
            btnインポートしたデータを検証_測定局一覧_都道府県.UseVisualStyleBackColor = true;
            btnインポートしたデータを検証_測定局一覧_都道府県.Click += btnインポートしたデータを検証_測定局一覧_都道府県_Click;
            // 
            // btnCSVファイルインポート実行_測定局一覧_都道府県
            // 
            btnCSVファイルインポート実行_測定局一覧_都道府県.Location = new Point(307, 69);
            btnCSVファイルインポート実行_測定局一覧_都道府県.Name = "btnCSVファイルインポート実行_測定局一覧_都道府県";
            btnCSVファイルインポート実行_測定局一覧_都道府県.Size = new Size(207, 23);
            btnCSVファイルインポート実行_測定局一覧_都道府県.TabIndex = 37;
            btnCSVファイルインポート実行_測定局一覧_都道府県.Text = "CSVファイルをインポート（都道府県）";
            btnCSVファイルインポート実行_測定局一覧_都道府県.UseVisualStyleBackColor = true;
            btnCSVファイルインポート実行_測定局一覧_都道府県.Click += btnCSVファイルインポート実行_測定局一覧_都道府県_Click;
            // 
            // btn測定局一覧都道府県データファイルパス
            // 
            btn測定局一覧都道府県データファイルパス.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn測定局一覧都道府県データファイルパス.Location = new Point(1165, 42);
            btn測定局一覧都道府県データファイルパス.Name = "btn測定局一覧都道府県データファイルパス";
            btn測定局一覧都道府県データファイルパス.Size = new Size(75, 23);
            btn測定局一覧都道府県データファイルパス.TabIndex = 36;
            btn測定局一覧都道府県データファイルパス.Text = "ファイル選択";
            btn測定局一覧都道府県データファイルパス.UseVisualStyleBackColor = true;
            btn測定局一覧都道府県データファイルパス.Click += btn測定局一覧都道府県データファイルパス_Click;
            // 
            // txt測定局一覧都道府県データファイルパス
            // 
            txt測定局一覧都道府県データファイルパス.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txt測定局一覧都道府県データファイルパス.Location = new Point(234, 42);
            txt測定局一覧都道府県データファイルパス.Name = "txt測定局一覧都道府県データファイルパス";
            txt測定局一覧都道府県データファイルパス.Size = new Size(925, 23);
            txt測定局一覧都道府県データファイルパス.TabIndex = 34;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 44);
            label8.Name = "label8";
            label8.Size = new Size(221, 15);
            label8.TabIndex = 35;
            label8.Text = "測定局一覧データ（都道府県） ファイルパス";
            // 
            // label9
            // 
            label9.Location = new Point(329, 50);
            label9.Name = "label9";
            label9.Size = new Size(220, 15);
            label9.TabIndex = 32;
            // 
            // label10
            // 
            label10.Location = new Point(183, 50);
            label10.Name = "label10";
            label10.Size = new Size(140, 15);
            label10.TabIndex = 33;
            // 
            // btn変換したデータを検証_測定局一覧
            // 
            btn変換したデータを検証_測定局一覧.Location = new Point(876, 68);
            btn変換したデータを検証_測定局一覧.Name = "btn変換したデータを検証_測定局一覧";
            btn変換したデータを検証_測定局一覧.Size = new Size(128, 23);
            btn変換したデータを検証_測定局一覧.TabIndex = 31;
            btn変換したデータを検証_測定局一覧.Text = "変換したデータを検証";
            btn変換したデータを検証_測定局一覧.UseVisualStyleBackColor = true;
            btn変換したデータを検証_測定局一覧.Click += btn変換したデータを検証_測定局一覧_Click;
            // 
            // btn正規テーブルへ変換_測定局一覧
            // 
            btn正規テーブルへ変換_測定局一覧.Location = new Point(754, 68);
            btn正規テーブルへ変換_測定局一覧.Name = "btn正規テーブルへ変換_測定局一覧";
            btn正規テーブルへ変換_測定局一覧.Size = new Size(116, 23);
            btn正規テーブルへ変換_測定局一覧.TabIndex = 28;
            btn正規テーブルへ変換_測定局一覧.Text = "正規テーブルへ変換";
            btn正規テーブルへ変換_測定局一覧.UseVisualStyleBackColor = true;
            btn正規テーブルへ変換_測定局一覧.Click += btn正規テーブルへ変換_測定局一覧_Click;
            // 
            // btnインポートしたデータを検証_測定局一覧
            // 
            btnインポートしたデータを検証_測定局一覧.Location = new Point(158, 69);
            btnインポートしたデータを検証_測定局一覧.Name = "btnインポートしたデータを検証_測定局一覧";
            btnインポートしたデータを検証_測定局一覧.Size = new Size(143, 23);
            btnインポートしたデータを検証_測定局一覧.TabIndex = 30;
            btnインポートしたデータを検証_測定局一覧.Text = "インポートしたデータを検証";
            btnインポートしたデータを検証_測定局一覧.UseVisualStyleBackColor = true;
            btnインポートしたデータを検証_測定局一覧.Click += btnインポートしたデータを検証_測定局一覧_Click;
            // 
            // btnファイル選択_測定局一覧CSVファイルパス
            // 
            btnファイル選択_測定局一覧CSVファイルパス.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnファイル選択_測定局一覧CSVファイルパス.Location = new Point(1166, 17);
            btnファイル選択_測定局一覧CSVファイルパス.Name = "btnファイル選択_測定局一覧CSVファイルパス";
            btnファイル選択_測定局一覧CSVファイルパス.Size = new Size(75, 23);
            btnファイル選択_測定局一覧CSVファイルパス.TabIndex = 29;
            btnファイル選択_測定局一覧CSVファイルパス.Text = "ファイル選択";
            btnファイル選択_測定局一覧CSVファイルパス.UseVisualStyleBackColor = true;
            btnファイル選択_測定局一覧CSVファイルパス.Click += btnファイル選択_測定局一覧CSVファイルパス_Click;
            // 
            // btnCSVファイルインポート実行_測定局一覧
            // 
            btnCSVファイルインポート実行_測定局一覧.Location = new Point(6, 69);
            btnCSVファイルインポート実行_測定局一覧.Name = "btnCSVファイルインポート実行_測定局一覧";
            btnCSVファイルインポート実行_測定局一覧.Size = new Size(143, 23);
            btnCSVファイルインポート実行_測定局一覧.TabIndex = 10;
            btnCSVファイルインポート実行_測定局一覧.Text = "CSVファイルをインポート";
            btnCSVファイルインポート実行_測定局一覧.UseVisualStyleBackColor = true;
            btnCSVファイルインポート実行_測定局一覧.Click += btnCSVファイルインポート実行_測定局一覧_Click;
            // 
            // txt測定局一覧データファイルパス
            // 
            txt測定局一覧データファイルパス.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txt測定局一覧データファイルパス.Location = new Point(164, 17);
            txt測定局一覧データファイルパス.Name = "txt測定局一覧データファイルパス";
            txt測定局一覧データファイルパス.Size = new Size(996, 23);
            txt測定局一覧データファイルパス.TabIndex = 27;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 19);
            label7.Name = "label7";
            label7.Size = new Size(149, 15);
            label7.TabIndex = 28;
            label7.Text = "測定局一覧データ ファイルパス";
            // 
            // label5
            // 
            label5.Location = new Point(330, 25);
            label5.Name = "label5";
            label5.Size = new Size(220, 15);
            label5.TabIndex = 13;
            // 
            // label6
            // 
            label6.Location = new Point(184, 25);
            label6.Name = "label6";
            label6.Size = new Size(140, 15);
            label6.TabIndex = 14;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btn計算結果を確認);
            groupBox4.Controls.Add(btnサマリー計算結果を検証);
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(btn更新_cmbYear);
            groupBox4.Controls.Add(cmbYear);
            groupBox4.Controls.Add(btnCulcSummary);
            groupBox4.Location = new Point(6, 315);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(693, 57);
            groupBox4.TabIndex = 28;
            groupBox4.TabStop = false;
            groupBox4.Text = "3. サマリーを計算";
            // 
            // btn計算結果を確認
            // 
            btn計算結果を確認.Location = new Point(452, 23);
            btn計算結果を確認.Name = "btn計算結果を確認";
            btn計算結果を確認.Size = new Size(111, 23);
            btn計算結果を確認.TabIndex = 27;
            btn計算結果を確認.Text = "計算結果を確認";
            btn計算結果を確認.UseVisualStyleBackColor = true;
            btn計算結果を確認.Click += btn計算結果を確認_Click;
            // 
            // btnサマリー計算結果を検証
            // 
            btnサマリー計算結果を検証.Location = new Point(315, 22);
            btnサマリー計算結果を検証.Name = "btnサマリー計算結果を検証";
            btnサマリー計算結果を検証.Size = new Size(111, 23);
            btnサマリー計算結果を検証.TabIndex = 26;
            btnサマリー計算結果を検証.Text = "計算結果を検証";
            btnサマリー計算結果を検証.UseVisualStyleBackColor = true;
            btnサマリー計算結果を検証.Click += btnサマリー計算結果を検証_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(9, 26);
            label11.Name = "label11";
            label11.Size = new Size(67, 15);
            label11.TabIndex = 25;
            label11.Text = "計算対象年";
            // 
            // btn更新_cmbYear
            // 
            btn更新_cmbYear.Location = new Point(159, 22);
            btn更新_cmbYear.Name = "btn更新_cmbYear";
            btn更新_cmbYear.Size = new Size(49, 23);
            btn更新_cmbYear.TabIndex = 24;
            btn更新_cmbYear.Text = "更新";
            btn更新_cmbYear.UseVisualStyleBackColor = true;
            btn更新_cmbYear.Click += btn更新_cmbYear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1288, 616);
            Controls.Add(groupBox4);
            Controls.Add(groupBox6);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(txtConnectionString);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "大気汚染データ分析";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtConnectionString;
        private TextBox txtZipFolderPath;
        private Label label1;
        private Label label3;
        private Button btnSelectFolder;
        private Button btnClearData;
        private Button btnExtractZip;
        private Button btnCsvFileImport;
        private Label label4;
        private TextBox txtWorkFolderPath;
        private Button btnSelectFolder_Work;
        private Button btnCulcSummary;
        private TextBox textBox1;
        private GroupBox groupBox1;
        private CheckBox chkサマリーデータ;
        private CheckBox chk変換後データ;
        private CheckBox chkインポートデータ;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button btnインポートしたデータを検証;
        private Button btn計算結果を確認;
        private Button btn変換したデータを検証;
        private Label label2;
        private TextBox txtStartRow;
        private GroupBox groupBox6;
        private Button btnCSVファイルインポート実行_測定局一覧;
        private Label label5;
        private Label label6;
        private Button btnファイル選択_測定局一覧CSVファイルパス;
        private Label label7;
        private TextBox txt測定局一覧データファイルパス;
        private Button btn変換したデータを検証_測定局一覧;
        private Button button2;
        private Button btnインポートしたデータを検証_測定局一覧;
        private Button btn正規テーブルへ変換_測定局一覧;
        private Button btn測定局一覧都道府県データファイルパス;
        private TextBox txt測定局一覧都道府県データファイルパス;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button btnインポートしたデータを検証_測定局一覧_都道府県;
        private Button btnCSVファイルインポート実行_測定局一覧_都道府県;
        private ComboBox cmbYear;
        private GroupBox groupBox4;
        private Button btn更新_cmbYear;
        private Label label11;
        private Button btnサマリー計算結果を検証;
        private Button btnMapURL生成;
        private Button btnImportDataConvert;
        private CheckBox chkZip解凍ファイル;
    }
}