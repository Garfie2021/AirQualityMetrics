using System.Net;
using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Formメイン : Form
    {
        DataTable _DataTable;
        DataTable _DataTable測定局一覧;
        DataTable _DataTable測定局一覧_都道府県;

        public Formメイン()
        {
            InitializeComponent();

            _DataTable = new DataTable();
            _DataTable.Columns.Add("MeasurementStationCode", typeof(string));
            _DataTable.Columns.Add("ImportDate", typeof(string));
            _DataTable.Columns.Add("ImportTime", typeof(string));
            _DataTable.Columns.Add("SO2_ppm", typeof(string));
            _DataTable.Columns.Add("NO_ppm", typeof(string));
            _DataTable.Columns.Add("NO2_ppm", typeof(string));
            _DataTable.Columns.Add("NOx_ppm", typeof(string));
            _DataTable.Columns.Add("CO_ppm", typeof(string));
            _DataTable.Columns.Add("Ox_ppm", typeof(string));
            _DataTable.Columns.Add("NMHC_ppmC", typeof(string));
            _DataTable.Columns.Add("CH4_ppmC", typeof(string));
            _DataTable.Columns.Add("THC_ppmC", typeof(string));
            _DataTable.Columns.Add("SPM_mg_per_m3", typeof(string));
            _DataTable.Columns.Add("PM25_ug_per_m3", typeof(string));
            _DataTable.Columns.Add("SP_mg_per_m3", typeof(string));
            _DataTable.Columns.Add("WD_16Dir", typeof(string));
            _DataTable.Columns.Add("WS_m_per_s", typeof(string));
            _DataTable.Columns.Add("TEMP_C", typeof(string));
            _DataTable.Columns.Add("HUM_percent", typeof(string));

            _DataTable測定局一覧 = new DataTable();
            _DataTable測定局一覧.Columns.Add("MeasurementStationCode", typeof(string));
            _DataTable測定局一覧.Columns.Add("StationName", typeof(string));
            _DataTable測定局一覧.Columns.Add("Address", typeof(string));
            _DataTable測定局一覧.Columns.Add("SO2", typeof(string));
            _DataTable測定局一覧.Columns.Add("NO", typeof(string));
            _DataTable測定局一覧.Columns.Add("NO2", typeof(string));
            _DataTable測定局一覧.Columns.Add("NOX", typeof(string));
            _DataTable測定局一覧.Columns.Add("CO", typeof(string));
            _DataTable測定局一覧.Columns.Add("OX", typeof(string));
            _DataTable測定局一覧.Columns.Add("NMHC", typeof(string));
            _DataTable測定局一覧.Columns.Add("CH4", typeof(string));
            _DataTable測定局一覧.Columns.Add("THC", typeof(string));
            _DataTable測定局一覧.Columns.Add("SPM", typeof(string));
            _DataTable測定局一覧.Columns.Add("PM25", typeof(string));
            _DataTable測定局一覧.Columns.Add("SP", typeof(string));
            _DataTable測定局一覧.Columns.Add("WD", typeof(string));
            _DataTable測定局一覧.Columns.Add("WS", typeof(string));
            _DataTable測定局一覧.Columns.Add("TEMP", typeof(string));
            _DataTable測定局一覧.Columns.Add("HUM", typeof(string));
            _DataTable測定局一覧.Columns.Add("ContactInfo", typeof(string));
            _DataTable測定局一覧.Columns.Add("StationType", typeof(string));

            _DataTable測定局一覧_都道府県 = new DataTable();
            _DataTable測定局一覧_都道府県.Columns.Add("MeasurementStationCode", typeof(string));
            _DataTable測定局一覧_都道府県.Columns.Add("都道府県", typeof(string));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtConnectionString.Text = ConfigurationManager.AppSettings["ConnectionString"];
            txtZipFolderPath.Text = ConfigurationManager.AppSettings["FolderPath"];
            txtWorkFolderPath.Text = ConfigurationManager.AppSettings["WorkFolderPath"];
            txt測定局一覧データファイルパス.Text = ConfigurationManager.AppSettings["測定局一覧データファイルパス"];
            txt測定局一覧都道府県データファイルパス.Text = ConfigurationManager.AppSettings["測定局一覧都道府県データファイルパス"];
            //txtWorkFolderPath.Text = Path.Combine(Directory.GetCurrentDirectory(), "");
            //txt測定局一覧データファイルパス.Text = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\..\そらまめくん_測定局\そらまめくん測定局一覧.csv");
            //txt測定局一覧都道府県データファイルパス.Text = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\..\そらまめくん_測定局\そらまめくん測定局一覧_都道府県.csv");

            cmbYear更新();
        }

        #region 0. データ削除
        private void btnClearData_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("テーブルのデータをクリアしますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                string connectionString = txtConnectionString.Text; // 接続文字列

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    if (chkZip解凍ファイル.Checked)
                    {
                        // workディレクトリが存在する場合は削除
                        if (Directory.Exists(txtWorkFolderPath.Text))
                        {
                            Directory.Delete(txtWorkFolderPath.Text, true); // true でディレクトリ内のすべてのファイルを削除
                        }

                        // workディレクトリを新規作成
                        Directory.CreateDirectory(txtWorkFolderPath.Text);
                    }

                    if (chkインポートデータ.Checked)
                    {
                        using (SqlCommand cmd = new SqlCommand(@"
                            TRUNCATE TABLE tImport_MeasurementData;
                            TRUNCATE TABLE tImport_MeasurementStation;
                            TRUNCATE TABLE tImport_MeasurementStation_都道府県;",
                            conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    if (chk変換後データ.Checked)
                    {
                        using (SqlCommand cmd = new SqlCommand(@"
                            TRUNCATE TABLE tMeasurementData;
                            TRUNCATE TABLE tMeasurementStation;",
                            conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    if (chkサマリーデータ.Checked)
                    {
                        using (SqlCommand cmd = new SqlCommand("TRUNCATE TABLE tSummary", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("データをクリアしました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"エラー: {ex.Message}");
            }
        }
        #endregion 0. データ削除

        #region 1. 測定データ
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    // ダイアログの初期設定（オプション）
                    folderBrowserDialog.Description = "フォルダを選択してください。";
                    folderBrowserDialog.SelectedPath = Path.GetFullPath(txtZipFolderPath.Text);

                    // ダイアログを表示
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        // 選択されたフォルダのパスをテキストボックスに設定
                        txtZipFolderPath.Text = folderBrowserDialog.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btnSelectFolder_Work_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    // ダイアログの初期設定（オプション）
                    folderBrowserDialog.Description = "フォルダを選択してください。";
                    folderBrowserDialog.SelectedPath = Path.GetFullPath(txtWorkFolderPath.Text);

                    // ダイアログを表示
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        // 選択されたフォルダのパスをテキストボックスに設定
                        txtWorkFolderPath.Text = folderBrowserDialog.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btnExtractZip_Click(object sender, EventArgs e)
        {
            var Zipファイル展開 = new Zipファイル展開(txtZipFolderPath.Text, txtWorkFolderPath.Text);
            Zipファイル展開.ShowDialog();
        }

        private async void btnCsvFileImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("CSVファイルのインポートを開始しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                var processingDialog = new ProcessingDialog();
                var task = Task.Run(async () =>
                {
                    try
                    {
                        using (var conn = new SqlConnection(txtConnectionString.Text))
                        {
                            await conn.OpenAsync();

                            // データは消す
                            using (var cmd = new SqlCommand("TRUNCATE TABLE tImport_MeasurementData", conn))
                            {
                                await cmd?.ExecuteNonQueryAsync();
                            }

                            _DataTable.Clear();
                            var csvFiles = Directory.GetFiles(txtWorkFolderPath.Text, "*.csv");
                            int fileCnt = 0;

                            foreach (var csvFilePath in csvFiles)
                            {
                                fileCnt++;
                                using (var sr = new StreamReader(csvFilePath))
                                {
                                    await sr.ReadLineAsync();// ヘッダ行を読み飛ばす

                                    string? line;
                                    while ((line = await sr.ReadLineAsync()) != null)
                                    {
                                        var fields = line.Split(',');   // CSVの行をコンマで分割
                                        fields[0] = fields[0].PadLeft(8, '0');
                                        _DataTable.Rows.Add(fields);    // _DataTableに行を追加
                                    }
                                }

                                // 100ファイルごとまたは最後のファイルの場合、バッチ処理を実行
                                if (fileCnt % 10 == 0 || fileCnt == csvFiles.Length)
                                {
                                    using (var bulkCopy = new SqlBulkCopy(conn))
                                    {
                                        bulkCopy.DestinationTableName = "tImport_MeasurementData";

                                        // 列のマッピングを設定
                                        bulkCopy.ColumnMappings.Add(0, "MeasurementStationCode");
                                        bulkCopy.ColumnMappings.Add(1, "ImportDate");
                                        bulkCopy.ColumnMappings.Add(2, "ImportTime");
                                        bulkCopy.ColumnMappings.Add(3, "SO2_ppm");
                                        bulkCopy.ColumnMappings.Add(4, "NO_ppm");
                                        bulkCopy.ColumnMappings.Add(5, "NO2_ppm");
                                        bulkCopy.ColumnMappings.Add(6, "NOx_ppm");
                                        bulkCopy.ColumnMappings.Add(7, "CO_ppm");
                                        bulkCopy.ColumnMappings.Add(8, "Ox_ppm");
                                        bulkCopy.ColumnMappings.Add(9, "NMHC_ppmC");
                                        bulkCopy.ColumnMappings.Add(10, "CH4_ppmC");
                                        bulkCopy.ColumnMappings.Add(11, "THC_ppmC");
                                        bulkCopy.ColumnMappings.Add(12, "SPM_mg_per_m3");
                                        bulkCopy.ColumnMappings.Add(13, "PM25_ug_per_m3");
                                        bulkCopy.ColumnMappings.Add(14, "SP_mg_per_m3");
                                        bulkCopy.ColumnMappings.Add(15, "WD_16Dir");
                                        bulkCopy.ColumnMappings.Add(16, "WS_m_per_s");
                                        bulkCopy.ColumnMappings.Add(17, "TEMP_C");
                                        bulkCopy.ColumnMappings.Add(18, "HUM_percent");

                                        await bulkCopy.WriteToServerAsync(_DataTable);
                                        _DataTable.Clear();
                                    }

                                    processingDialog.Invoke(new Action(() =>
                                    {
                                        processingDialog.StatusText = $"処理済ファイル {fileCnt} / 全ファイル {csvFiles.Length}";// UIを更新
                                    }));
                                }
                            }
                        }
                    }
                    finally
                    {
                        processingDialog.Invoke(new Action(() =>
                        {
                            processingDialog.Close(); // バックグラウンド処理が完了したら閉じる
                        }));
                    }
                });

                processingDialog.ShowDialog(); // 処理中ダイアログを表示

                await task; // バックグラウンド処理が完了するまで待機

                MessageBox.Show("CSVファイルのインポートが完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private async void btnインポートしたデータを検証_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("インポートしたデータの検証を開始しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                var processingDialog = new ProcessingDialog();
                int fileTotalLineCnt = 0;
                var uniqueValues = new HashSet<string>();
                var csvFiles = Directory.GetFiles(txtWorkFolderPath.Text, "*.csv");
                int tImportPlane_TotalRowCount = 0;
                int tImportPlane_StationCode_UniqueCount = 0;
                var task = Task.Run(() =>
                {
                    try
                    {
                        foreach (var file in csvFiles)
                        {
                            var lines = File.ReadAllLines(file);
                            fileTotalLineCnt += lines.Length - 1; // ヘッダ行を除く行数をカウント

                            bool isFirstLine = true;
                            foreach (var line in lines)
                            {
                                if (isFirstLine)
                                {
                                    isFirstLine = false; // 最初の行をスキップ
                                    continue;
                                }

                                var columns = line.Split(',');
                                if (columns.Length > 0)
                                {
                                    uniqueValues.Add(columns[0]);
                                }
                            }
                        }

                        using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                        {
                            conn.Open();

                            // 行数を取得
                            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tImport_MeasurementData", conn))
                            {
                                tImportPlane_TotalRowCount = (int)cmd.ExecuteScalar();
                            }

                            // ユニークなMeasurementStationCodeの数を取得
                            using (var cmd = new SqlCommand("SELECT COUNT(DISTINCT MeasurementStationCode) FROM tImport_MeasurementData", conn))
                            {
                                tImportPlane_StationCode_UniqueCount = (int)cmd.ExecuteScalar();
                            }
                        }
                    }
                    finally
                    {
                        processingDialog.Invoke(new Action(() =>
                        {
                            processingDialog.Close(); // バックグラウンド処理が完了したら閉じる
                        }));
                    }
                });

                processingDialog.ShowDialog(); // 処理中ダイアログを表示

                await task; // バックグラウンド処理が完了するまで待機

                MessageBox.Show(@$"fileCnt:{csvFiles.Length}
file_StationCode_UniqueCount:{uniqueValues.Count} => tImportPlane_StationCode_UniqueCount:{tImportPlane_StationCode_UniqueCount}
fileTotalLineCnt:{fileTotalLineCnt} => tImportPlane_TotalRowCount:{tImportPlane_TotalRowCount}
", "検証結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private async void btnImportDataConvert_Click(object sender, EventArgs e)
        {
            int startRow = 0;
            int endRow = 0;

            try
            {
                if (MessageBox.Show("インポートしたデータを変換しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                var processingDialog = new ProcessingDialog();
                var task = Task.Run(async () =>
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                        {
                            await conn.OpenAsync();

                            // tImportPlane テーブルの最大Idを取得
                            long maxId;
                            using (SqlCommand cmd = new SqlCommand("SELECT MAX(Id) FROM tImport_MeasurementData", conn))
                            {
                                maxId = (long)await cmd?.ExecuteScalarAsync();
                            }

                            // n件ずつループ実行
                            for (startRow = int.Parse(txtStartRow.Text); startRow <= maxId; startRow = endRow + 1)
                            {
                                endRow = startRow + 99999;
                                processingDialog.Invoke(new Action(() =>
                                {
                                    processingDialog.StatusText = $"RowCntMax:{maxId}  startRow:{startRow} / endRow:{endRow}";// UIを更新
                                }));

                                using (SqlCommand cmd = new SqlCommand("InsertMeasurementData", conn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandTimeout = Int32.MaxValue; // 最大限のタイムアウト値を設定

                                    // パラメータの設定
                                    cmd.Parameters.Add(new SqlParameter("@StartRow", startRow));
                                    cmd.Parameters.Add(new SqlParameter("@EndRow", endRow));

                                    // ストアドプロシージャの実行
                                    await cmd.ExecuteNonQueryAsync();
                                }
                            }
                        }
                    }
                    finally
                    {
                        processingDialog.Invoke(new Action(() =>
                        {
                            processingDialog.Close(); // バックグラウンド処理が完了したら閉じる
                        }));
                    }
                });

                processingDialog.ShowDialog(); // 処理中ダイアログを表示

                await task; // バックグラウンド処理が完了するまで待機

                MessageBox.Show("インポートしたデータの変換が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\n startRow:{startRow} endRow:{endRow}");
            }
        }

        private void btn変換したデータを検証_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("変換したデータの検証を開始しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                int tImportPlane_TotalRowCount = 0;
                using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                {
                    conn.Open();

                    // 行数を取得
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tImport_MeasurementData", conn))
                    {
                        tImportPlane_TotalRowCount = (int)cmd.ExecuteScalar();
                    }
                }

                int tImport_TotalRowCount = 0;
                using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                {
                    conn.Open();

                    // 行数を取得
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tMeasurementData", conn))
                    {
                        tImport_TotalRowCount = (int)cmd.ExecuteScalar();
                    }
                }

                MessageBox.Show(@$"tImportPlane_TotalRowCount:{tImportPlane_TotalRowCount} => tImport_TotalRowCount:{tImport_TotalRowCount}", "検証結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        #endregion 1. 測定データ

        #region 2. 測定局マスタ

        private void btnファイル選択_測定局一覧CSVファイルパス_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\.."); // 初期ディレクトリを設定
                    openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*"; // ファイルの種類を指定

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // ファイルパスをテキストボックスにセット
                        txt測定局一覧都道府県データファイルパス.Text = openFileDialog.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btn測定局一覧都道府県データファイルパス_Click(object sender, EventArgs e)
        {

        }

        private async void btnCSVファイルインポート実行_測定局一覧_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("CSVファイルのインポートを開始しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                _DataTable測定局一覧.Clear();

                using (var conn = new SqlConnection(txtConnectionString.Text))
                {
                    await conn.OpenAsync();

                    // データは消す
                    using (SqlCommand cmd = new SqlCommand(@$"DELETE FROM tImport_MeasurementStation", conn))
                    {
                        await cmd?.ExecuteNonQueryAsync();
                    }
                }

                using (StreamReader sr = new StreamReader(txt測定局一覧データファイルパス.Text))
                {
                    await sr.ReadLineAsync();// ヘッダ行を読み飛ばす

                    string? line;
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        var fields = line.Split(',');
                        fields[0] = fields[0].PadLeft(8, '0');
                        _DataTable測定局一覧.Rows.Add(fields);
                    }
                }

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(txtConnectionString.Text))
                {
                    bulkCopy.DestinationTableName = "tImport_MeasurementStation";

                    // 列のマッピングを設定
                    bulkCopy.ColumnMappings.Add(0, "MeasurementStationCode");
                    bulkCopy.ColumnMappings.Add(1, "StationName");
                    bulkCopy.ColumnMappings.Add(2, "Address");
                    bulkCopy.ColumnMappings.Add(3, "SO2");
                    bulkCopy.ColumnMappings.Add(4, "NO");
                    bulkCopy.ColumnMappings.Add(5, "NO2");
                    bulkCopy.ColumnMappings.Add(6, "NOX");
                    bulkCopy.ColumnMappings.Add(7, "CO");
                    bulkCopy.ColumnMappings.Add(8, "OX");
                    bulkCopy.ColumnMappings.Add(9, "NMHC");
                    bulkCopy.ColumnMappings.Add(10, "CH4");
                    bulkCopy.ColumnMappings.Add(11, "THC");
                    bulkCopy.ColumnMappings.Add(12, "SPM");
                    bulkCopy.ColumnMappings.Add(13, "PM25");
                    bulkCopy.ColumnMappings.Add(14, "SP");
                    bulkCopy.ColumnMappings.Add(15, "WD");
                    bulkCopy.ColumnMappings.Add(16, "WS");
                    bulkCopy.ColumnMappings.Add(17, "TEMP");
                    bulkCopy.ColumnMappings.Add(18, "HUM");
                    bulkCopy.ColumnMappings.Add(19, "ContactInfo");
                    bulkCopy.ColumnMappings.Add(20, "StationType");

                    await bulkCopy.WriteToServerAsync(_DataTable測定局一覧);
                }

                MessageBox.Show("CSVファイルのインポートが完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btnインポートしたデータを検証_測定局一覧_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("インポートしたデータの検証を開始しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                int fileTotalLineCnt = 0;
                var uniqueValues = new HashSet<string>();
                var lines = File.ReadAllLines(txt測定局一覧データファイルパス.Text);
                fileTotalLineCnt += lines.Length - 1; // ヘッダ行を除く行数をカウント

                bool isFirstLine = true;
                foreach (var line in lines)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false; // 最初の行をスキップ
                        continue;
                    }

                    var columns = line.Split(',');
                    if (columns.Length > 0)
                    {
                        uniqueValues.Add(columns[0]);
                    }
                }

                int tImportPlane_TotalRowCount = 0;
                int tImportPlane_StationCode_UniqueCount = 0;
                using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                {
                    conn.Open();

                    // 行数を取得
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tImport_MeasurementStation", conn))
                    {
                        tImportPlane_TotalRowCount = (int)cmd.ExecuteScalar();
                    }

                    // ユニークなMeasurementStationCodeの数を取得
                    using (var cmd = new SqlCommand("SELECT COUNT(DISTINCT MeasurementStationCode) FROM tImport_MeasurementStation", conn))
                    {
                        tImportPlane_StationCode_UniqueCount = (int)cmd.ExecuteScalar();
                    }
                }

                MessageBox.Show(@$"file_StationCode_UniqueCount:{uniqueValues.Count} => tImportPlane_StationCode_UniqueCount:{tImportPlane_StationCode_UniqueCount}
fileTotalLineCnt:{fileTotalLineCnt} => tImportPlane_TotalRowCount:{tImportPlane_TotalRowCount}
", "検証結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private async void btnCSVファイルインポート実行_測定局一覧_都道府県_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("CSVファイルのインポートを開始しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                {
                    conn.Open();

                    // データは消す
                    using (var cmd = new SqlCommand("TRUNCATE TABLE tImport_MeasurementStation_都道府県", conn))
                    {
                        await cmd?.ExecuteNonQueryAsync();
                    }
                }

                _DataTable測定局一覧_都道府県.Clear();

                using (StreamReader sr = new StreamReader(txt測定局一覧都道府県データファイルパス.Text))
                {
                    await sr.ReadLineAsync(); // ヘッダ行を読み飛ばす

                    string? line;
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        var fields = line.Split(',');
                        fields[0] = fields[0].PadLeft(8, '0');
                        _DataTable測定局一覧_都道府県.Rows.Add(fields[0].Trim(), fields[2].Trim());
                    }
                }

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(txtConnectionString.Text))
                {
                    bulkCopy.DestinationTableName = "tImport_MeasurementStation_都道府県";

                    // 列のマッピングを設定
                    bulkCopy.ColumnMappings.Add(0, "MeasurementStationCode");
                    bulkCopy.ColumnMappings.Add(1, "都道府県");

                    await bulkCopy.WriteToServerAsync(_DataTable測定局一覧_都道府県);
                }

                MessageBox.Show("CSVファイルのインポートが完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btnインポートしたデータを検証_測定局一覧_都道府県_Click(object sender, EventArgs e)
        {
            try
            {
                int tImport_MeasurementStation_Count = 0;
                int tImport_MeasurementStation_都道府県_Count = 0;
                using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                {
                    conn.Open();

                    // 行数を取得
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tImport_MeasurementStation", conn))
                    {
                        tImport_MeasurementStation_Count = (int)cmd.ExecuteScalar();
                    }

                    // 行数を取得
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tImport_MeasurementStation_都道府県", conn))
                    {
                        tImport_MeasurementStation_都道府県_Count = (int)cmd.ExecuteScalar();
                    }
                }

                MessageBox.Show(@$"tImport_MeasurementStation 行数:{tImport_MeasurementStation_Count} => tImport_MeasurementStation_都道府県 行数:{tImport_MeasurementStation_都道府県_Count}
", "検証結果", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private async void btn正規テーブルへ変換_測定局一覧_Click(object sender, EventArgs e)
        {
            int startRow = 0;
            int endRow = 0;

            try
            {
                if (MessageBox.Show("インポートしたデータを変換しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                {
                    await conn.OpenAsync();

                    // tImportテーブルのデータは消す
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM tMeasurementStation", conn))
                    {
                        await cmd?.ExecuteNonQueryAsync();
                    }

                    // tImportPlane テーブルの最大Idを取得
                    long maxId;
                    using (SqlCommand cmd = new SqlCommand("SELECT MAX(Id) FROM tImport_MeasurementStation", conn))
                    {
                        maxId = (long)await cmd?.ExecuteScalarAsync();
                    }

                    //_ProcessingDialog.Invoke(new Action(() =>
                    //{
                    //    _ProcessingDialog.StatusText = $"RowCntMax:{maxId}";// UIを更新
                    //}));

                    // n件ずつループ実行
                    for (startRow = int.Parse(txtStartRow.Text); startRow <= maxId; startRow = endRow + 1)
                    {
                        endRow = startRow + 99999;
                        //_ProcessingDialog.Invoke(new Action(() =>
                        //{
                        //    _ProcessingDialog.StatusText = $"startRow:{startRow} / endRow:{endRow}";// UIを更新
                        //}));

                        using (SqlCommand cmd = new SqlCommand("InsertMeasurementStation", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = Int32.MaxValue; // 最大限のタイムアウト値を設定

                            // パラメータの設定
                            //cmd.Parameters.Add(new SqlParameter("@StartRow", startRow));
                            //cmd.Parameters.Add(new SqlParameter("@EndRow", endRow));

                            // ストアドプロシージャの実行
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                }

                MessageBox.Show("インポートしたデータの変換が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\n startRow:{startRow} endRow:{endRow}");
            }
        }

        private void btn変換したデータを検証_測定局一覧_Click(object sender, EventArgs e)
        {
            try
            {
                int tImport_MeasurementStation_Count = 0;
                int tImport_MeasurementStation_都道府県_Count = 0;
                int tMeasurementStation_Count = 0;
                using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                {
                    conn.Open();

                    // 行数を取得
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tImport_MeasurementStation", conn))
                    {
                        tImport_MeasurementStation_Count = (int)cmd.ExecuteScalar();
                    }

                    // 行数を取得
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tImport_MeasurementStation_都道府県", conn))
                    {
                        tImport_MeasurementStation_都道府県_Count = (int)cmd.ExecuteScalar();
                    }

                    // 行数を取得
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tMeasurementStation", conn))
                    {
                        tMeasurementStation_Count = (int)cmd.ExecuteScalar();
                    }
                }

                MessageBox.Show(@$"tImport_MeasurementStation 行数:{tImport_MeasurementStation_Count} => tImport_MeasurementStation_都道府県 行数:{tImport_MeasurementStation_都道府県_Count} => tMeasurementStation_Count 行数:{tMeasurementStation_Count}", "検証結果", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btnMapURL生成_Click(object sender, EventArgs e)
        {
            var stationCode = string.Empty;
            var prefecture = string.Empty;
            var address = string.Empty;
            try
            {
                if (MessageBox.Show("Map URL を生成しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                var stationData = new List<Tuple<string, string, string>>();

                using (var conn = new SqlConnection(txtConnectionString.Text))
                {
                    conn.Open();

                    // tMeasurementStation テーブルから都道府県と住所を取得してリストに保存
                    using (var selectCommand = new SqlCommand("SELECT MeasurementStationCode, [都道府県], Address FROM tMeasurementStation", conn))
                    {
                        using (var reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                stationCode = reader.GetString(0);
                                prefecture = reader.GetString(1);
                                address = reader.GetString(2);
                                stationData.Add(new Tuple<string, string, string>(stationCode, prefecture, address));
                            }
                        }
                    }

                    // Google Map URL を更新
                    foreach (var item in stationData)
                    {
                        var combinedAddress = item.Item2 + item.Item3;
                        var encodedAddress = WebUtility.UrlEncode(combinedAddress);

                        using (var updateCommand = new SqlCommand("UPDATE tMeasurementStation SET MapURL = @MapURL WHERE MeasurementStationCode = @StationCode", conn))
                        {
                            updateCommand.Parameters.AddWithValue("@MapURL", $"https://www.google.com/maps/search/?api=1&query={encodedAddress}");
                            updateCommand.Parameters.AddWithValue("@StationCode", item.Item1);

                            updateCommand.ExecuteNonQuery();
                        }
                    }

                    // そらまめくん URL を更新
                    foreach (var item in stationData)
                    {
                        var combinedAddress = item.Item2 + " " + item.Item3;
                        var encodedAddress = WebUtility.UrlEncode(combinedAddress);

                        using (var updateCommand = new SqlCommand("UPDATE tMeasurementStation SET そらまめくんURL = @そらまめくんURL WHERE MeasurementStationCode = @StationCode", conn))
                        {
                            updateCommand.Parameters.AddWithValue("@そらまめくんURL", @$"https://soramame.env.go.jp/preview/table/{item.Item1}/7day/SO2/-");
                            updateCommand.Parameters.AddWithValue("@StationCode", item.Item1);

                            updateCommand.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Map URL を生成しました。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラーが発生しました: " + ex.Message + $"\r\n stationCode:{stationCode} \r\n prefecture:{prefecture} \r\n address:{address}");
            }
        }
        #endregion 2. 測定局マスタ

        #region 3. サマリーを計算
        private void btn更新_cmbYear_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("更新しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                cmbYear更新();

                MessageBox.Show("更新しました。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("エラーが発生しました: " + ex.Message);
            }
        }

        private void cmbYear更新()
        {
            using (SqlConnection connection = new SqlConnection(txtConnectionString.Text))
            {
                using (SqlCommand command = new SqlCommand("SELECT DISTINCT YEAR(ImportDate) AS Year FROM tMeasurementData ORDER BY Year", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        cmbYear.Items.Clear();

                        while (reader.Read())
                        {
                            cmbYear.Items.Add(reader["Year"].ToString());
                        }
                    }
                }
            }

            cmbYear.SelectedIndex = cmbYear.Items.Count - 1;
        }

        private async void btnCulcSummary_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbYear.Text))
                {
                    MessageBox.Show("年月日が選択されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("サマリーを計算しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                var processingDialog = new ProcessingDialog();
                var year = int.Parse(cmbYear.Text);
                var task = Task.Run(async () =>
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                        {
                            await conn.OpenAsync();

                            // データは消す
                            using (SqlCommand cmd = new SqlCommand(@$"DELETE FROM tSummary WHERE Year={year}", conn))
                            {
                                await cmd?.ExecuteNonQueryAsync();
                            }

                            using (SqlCommand cmd = new SqlCommand("InsertSummary", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Year", year);

                                // ストアドプロシージャの実行
                                await cmd.ExecuteNonQueryAsync();
                            }
                        }
                    }
                    finally
                    {
                        processingDialog.Invoke(new Action(() =>
                        {
                            processingDialog.Close(); // バックグラウンド処理が完了したら閉じる
                        }));
                    }
                });

                processingDialog.ShowDialog(); // 処理中ダイアログを表示

                await task; // バックグラウンド処理が完了するまで待機

                MessageBox.Show("サマリーを計算が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btnサマリー計算結果を検証_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("サマリー計算結果の検証を開始しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                string result = "【tSummaryテーブル】\r\n";

                using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                {
                    conn.Open();

                    using (var cmd = new SqlCommand("SELECT [Year], count(*) FROM [tSummary] group by [Year]", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result += $"Year: {reader["Year"]}, Count: {reader[1]}\r\n";
                            }
                        }
                    }

                    result += "\r\n【tMeasurementDataテーブル】\r\n";

                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*), [Year] FROM 
                        (
                            SELECT 
                                [MeasurementStationCode], 
                                YEAR([ImportDate]) AS [Year] 
                            FROM [tMeasurementData] 
                            GROUP BY [MeasurementStationCode], YEAR([ImportDate])
                        ) t
                        GROUP BY [Year]
                        ", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result += $"Year: {reader["Year"]}, Count: {reader[0]}\r\n";
                            }
                        }
                    }

                    result += "\r\n【tSummary・tMeasurementStationテーブル】\r\n";

                    using (var cmd = new SqlCommand(@"
                        SELECT count(*)
                        FROM tSummary ts
	                        LEFT JOIN tMeasurementStation tms ON ts.MeasurementStationCode = tms.MeasurementStationCode
                        WHERE tms.MeasurementStationCode IS NULL;
                        ", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result += $"MeasurementStationCode不一致（測定局一覧に無い、データは有る）: Count: {reader[0]}\r\n";
                            }
                        }
                    }

                    using (var cmd = new SqlCommand(@"
                        SELECT COUNT(*)
                        FROM tMeasurementStation tms
	                        LEFT JOIN tSummary ts ON tms.MeasurementStationCode = ts.MeasurementStationCode
                        WHERE ts.MeasurementStationCode IS NULL;
                        ", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result += $"MeasurementStationCode不一致（測定局一覧に有り、データは無い）: Count: {reader[0]}\r\n";
                            }
                        }
                    }
                }


                // result には両方のクエリの結果が含まれています
                MessageBox.Show(result, "検証結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btn計算結果を確認_Click(object sender, EventArgs e)
        {
            var viewer = new Form計算結果Viewer(txtConnectionString.Text, cmbYear.Items.Cast<string>(), int.Parse(cmbYear.Text));
            viewer.Show();
        }

        #endregion 3. サマリーを計算

        private void btn水道水_Click(object sender, EventArgs e)
        {
            var f水道水 = new F水道水();
            f水道水.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigurationManager.AppSettings["ConnectionString"] = txtConnectionString.Text;
            ConfigurationManager.AppSettings["FolderPath"] = txtZipFolderPath.Text;
        }

    }
}
