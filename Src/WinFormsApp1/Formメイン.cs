using System.Net;
using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Form���C�� : Form
    {
        DataTable _DataTable;
        DataTable _DataTable����ǈꗗ;
        DataTable _DataTable����ǈꗗ_�s���{��;

        public Form���C��()
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

            _DataTable����ǈꗗ = new DataTable();
            _DataTable����ǈꗗ.Columns.Add("MeasurementStationCode", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("StationName", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("Address", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("SO2", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("NO", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("NO2", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("NOX", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("CO", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("OX", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("NMHC", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("CH4", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("THC", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("SPM", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("PM25", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("SP", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("WD", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("WS", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("TEMP", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("HUM", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("ContactInfo", typeof(string));
            _DataTable����ǈꗗ.Columns.Add("StationType", typeof(string));

            _DataTable����ǈꗗ_�s���{�� = new DataTable();
            _DataTable����ǈꗗ_�s���{��.Columns.Add("MeasurementStationCode", typeof(string));
            _DataTable����ǈꗗ_�s���{��.Columns.Add("�s���{��", typeof(string));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtConnectionString.Text = ConfigurationManager.AppSettings["ConnectionString"];
            txtZipFolderPath.Text = ConfigurationManager.AppSettings["FolderPath"];
            txtWorkFolderPath.Text = ConfigurationManager.AppSettings["WorkFolderPath"];
            txt����ǈꗗ�f�[�^�t�@�C���p�X.Text = ConfigurationManager.AppSettings["����ǈꗗ�f�[�^�t�@�C���p�X"];
            txt����ǈꗗ�s���{���f�[�^�t�@�C���p�X.Text = ConfigurationManager.AppSettings["����ǈꗗ�s���{���f�[�^�t�@�C���p�X"];
            //txtWorkFolderPath.Text = Path.Combine(Directory.GetCurrentDirectory(), "");
            //txt����ǈꗗ�f�[�^�t�@�C���p�X.Text = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\..\����܂߂���_�����\����܂߂��񑪒�ǈꗗ.csv");
            //txt����ǈꗗ�s���{���f�[�^�t�@�C���p�X.Text = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\..\����܂߂���_�����\����܂߂��񑪒�ǈꗗ_�s���{��.csv");

            cmbYear�X�V();
        }

        #region 0. �f�[�^�폜
        private void btnClearData_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("�e�[�u���̃f�[�^���N���A���܂����H", "�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                string connectionString = txtConnectionString.Text; // �ڑ�������

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    if (chkZip�𓀃t�@�C��.Checked)
                    {
                        // work�f�B���N�g�������݂���ꍇ�͍폜
                        if (Directory.Exists(txtWorkFolderPath.Text))
                        {
                            Directory.Delete(txtWorkFolderPath.Text, true); // true �Ńf�B���N�g�����̂��ׂẴt�@�C�����폜
                        }

                        // work�f�B���N�g����V�K�쐬
                        Directory.CreateDirectory(txtWorkFolderPath.Text);
                    }

                    if (chk�C���|�[�g�f�[�^.Checked)
                    {
                        using (SqlCommand cmd = new SqlCommand(@"
                            TRUNCATE TABLE tImport_MeasurementData;
                            TRUNCATE TABLE tImport_MeasurementStation;
                            TRUNCATE TABLE tImport_MeasurementStation_�s���{��;",
                            conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    if (chk�ϊ���f�[�^.Checked)
                    {
                        using (SqlCommand cmd = new SqlCommand(@"
                            TRUNCATE TABLE tMeasurementData;
                            TRUNCATE TABLE tMeasurementStation;",
                            conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    if (chk�T�}���[�f�[�^.Checked)
                    {
                        using (SqlCommand cmd = new SqlCommand("TRUNCATE TABLE tSummary", conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("�f�[�^���N���A���܂����B", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"�G���[: {ex.Message}");
            }
        }
        #endregion 0. �f�[�^�폜

        #region 1. ����f�[�^
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    // �_�C�A���O�̏����ݒ�i�I�v�V�����j
                    folderBrowserDialog.Description = "�t�H���_��I�����Ă��������B";
                    folderBrowserDialog.SelectedPath = Path.GetFullPath(txtZipFolderPath.Text);

                    // �_�C�A���O��\��
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        // �I�����ꂽ�t�H���_�̃p�X���e�L�X�g�{�b�N�X�ɐݒ�
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
                    // �_�C�A���O�̏����ݒ�i�I�v�V�����j
                    folderBrowserDialog.Description = "�t�H���_��I�����Ă��������B";
                    folderBrowserDialog.SelectedPath = Path.GetFullPath(txtWorkFolderPath.Text);

                    // �_�C�A���O��\��
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        // �I�����ꂽ�t�H���_�̃p�X���e�L�X�g�{�b�N�X�ɐݒ�
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
            var Zip�t�@�C���W�J = new Zip�t�@�C���W�J(txtZipFolderPath.Text, txtWorkFolderPath.Text);
            Zip�t�@�C���W�J.ShowDialog();
        }

        private async void btnCsvFileImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("CSV�t�@�C���̃C���|�[�g���J�n���܂����H", "�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                var processingDialog = new ProcessingDialog();
                var task = Task.Run(async () =>
                {
                    try
                    {
                        using (var conn = new SqlConnection(txtConnectionString.Text))
                        {
                            await conn.OpenAsync();

                            // �f�[�^�͏���
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
                                    await sr.ReadLineAsync();// �w�b�_�s��ǂݔ�΂�

                                    string? line;
                                    while ((line = await sr.ReadLineAsync()) != null)
                                    {
                                        var fields = line.Split(',');   // CSV�̍s���R���}�ŕ���
                                        fields[0] = fields[0].PadLeft(8, '0');
                                        _DataTable.Rows.Add(fields);    // _DataTable�ɍs��ǉ�
                                    }
                                }

                                // 100�t�@�C�����Ƃ܂��͍Ō�̃t�@�C���̏ꍇ�A�o�b�`���������s
                                if (fileCnt % 10 == 0 || fileCnt == csvFiles.Length)
                                {
                                    using (var bulkCopy = new SqlBulkCopy(conn))
                                    {
                                        bulkCopy.DestinationTableName = "tImport_MeasurementData";

                                        // ��̃}�b�s���O��ݒ�
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
                                        processingDialog.StatusText = $"�����σt�@�C�� {fileCnt} / �S�t�@�C�� {csvFiles.Length}";// UI���X�V
                                    }));
                                }
                            }
                        }
                    }
                    finally
                    {
                        processingDialog.Invoke(new Action(() =>
                        {
                            processingDialog.Close(); // �o�b�N�O���E���h�������������������
                        }));
                    }
                });

                processingDialog.ShowDialog(); // �������_�C�A���O��\��

                await task; // �o�b�N�O���E���h��������������܂őҋ@

                MessageBox.Show("CSV�t�@�C���̃C���|�[�g���������܂����B", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private async void btn�C���|�[�g�����f�[�^������_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("�C���|�[�g�����f�[�^�̌��؂��J�n���܂����H", "�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
                            fileTotalLineCnt += lines.Length - 1; // �w�b�_�s�������s�����J�E���g

                            bool isFirstLine = true;
                            foreach (var line in lines)
                            {
                                if (isFirstLine)
                                {
                                    isFirstLine = false; // �ŏ��̍s���X�L�b�v
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

                            // �s�����擾
                            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tImport_MeasurementData", conn))
                            {
                                tImportPlane_TotalRowCount = (int)cmd.ExecuteScalar();
                            }

                            // ���j�[�N��MeasurementStationCode�̐����擾
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
                            processingDialog.Close(); // �o�b�N�O���E���h�������������������
                        }));
                    }
                });

                processingDialog.ShowDialog(); // �������_�C�A���O��\��

                await task; // �o�b�N�O���E���h��������������܂őҋ@

                MessageBox.Show(@$"fileCnt:{csvFiles.Length}
file_StationCode_UniqueCount:{uniqueValues.Count} => tImportPlane_StationCode_UniqueCount:{tImportPlane_StationCode_UniqueCount}
fileTotalLineCnt:{fileTotalLineCnt} => tImportPlane_TotalRowCount:{tImportPlane_TotalRowCount}
", "���،���", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (MessageBox.Show("�C���|�[�g�����f�[�^��ϊ����܂����H", "�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                var processingDialog = new ProcessingDialog();
                var task = Task.Run(async () =>
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                        {
                            await conn.OpenAsync();

                            // tImportPlane �e�[�u���̍ő�Id���擾
                            long maxId;
                            using (SqlCommand cmd = new SqlCommand("SELECT MAX(Id) FROM tImport_MeasurementData", conn))
                            {
                                maxId = (long)await cmd?.ExecuteScalarAsync();
                            }

                            // n�������[�v���s
                            for (startRow = int.Parse(txtStartRow.Text); startRow <= maxId; startRow = endRow + 1)
                            {
                                endRow = startRow + 99999;
                                processingDialog.Invoke(new Action(() =>
                                {
                                    processingDialog.StatusText = $"RowCntMax:{maxId}  startRow:{startRow} / endRow:{endRow}";// UI���X�V
                                }));

                                using (SqlCommand cmd = new SqlCommand("InsertMeasurementData", conn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandTimeout = Int32.MaxValue; // �ő���̃^�C���A�E�g�l��ݒ�

                                    // �p�����[�^�̐ݒ�
                                    cmd.Parameters.Add(new SqlParameter("@StartRow", startRow));
                                    cmd.Parameters.Add(new SqlParameter("@EndRow", endRow));

                                    // �X�g�A�h�v���V�[�W���̎��s
                                    await cmd.ExecuteNonQueryAsync();
                                }
                            }
                        }
                    }
                    finally
                    {
                        processingDialog.Invoke(new Action(() =>
                        {
                            processingDialog.Close(); // �o�b�N�O���E���h�������������������
                        }));
                    }
                });

                processingDialog.ShowDialog(); // �������_�C�A���O��\��

                await task; // �o�b�N�O���E���h��������������܂őҋ@

                MessageBox.Show("�C���|�[�g�����f�[�^�̕ϊ����������܂����B", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\n startRow:{startRow} endRow:{endRow}");
            }
        }

        private void btn�ϊ������f�[�^������_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("�ϊ������f�[�^�̌��؂��J�n���܂����H", "�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                int tImportPlane_TotalRowCount = 0;
                using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                {
                    conn.Open();

                    // �s�����擾
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tImport_MeasurementData", conn))
                    {
                        tImportPlane_TotalRowCount = (int)cmd.ExecuteScalar();
                    }
                }

                int tImport_TotalRowCount = 0;
                using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                {
                    conn.Open();

                    // �s�����擾
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tMeasurementData", conn))
                    {
                        tImport_TotalRowCount = (int)cmd.ExecuteScalar();
                    }
                }

                MessageBox.Show(@$"tImportPlane_TotalRowCount:{tImportPlane_TotalRowCount} => tImport_TotalRowCount:{tImport_TotalRowCount}", "���،���", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        #endregion 1. ����f�[�^

        #region 2. ����ǃ}�X�^

        private void btn�t�@�C���I��_����ǈꗗCSV�t�@�C���p�X_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\..\..\..\.."); // �����f�B���N�g����ݒ�
                    openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*"; // �t�@�C���̎�ނ��w��

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // �t�@�C���p�X���e�L�X�g�{�b�N�X�ɃZ�b�g
                        txt����ǈꗗ�s���{���f�[�^�t�@�C���p�X.Text = openFileDialog.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btn����ǈꗗ�s���{���f�[�^�t�@�C���p�X_Click(object sender, EventArgs e)
        {

        }

        private async void btnCSV�t�@�C���C���|�[�g���s_����ǈꗗ_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("CSV�t�@�C���̃C���|�[�g���J�n���܂����H", "�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                _DataTable����ǈꗗ.Clear();

                using (var conn = new SqlConnection(txtConnectionString.Text))
                {
                    await conn.OpenAsync();

                    // �f�[�^�͏���
                    using (SqlCommand cmd = new SqlCommand(@$"DELETE FROM tImport_MeasurementStation", conn))
                    {
                        await cmd?.ExecuteNonQueryAsync();
                    }
                }

                using (StreamReader sr = new StreamReader(txt����ǈꗗ�f�[�^�t�@�C���p�X.Text))
                {
                    await sr.ReadLineAsync();// �w�b�_�s��ǂݔ�΂�

                    string? line;
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        var fields = line.Split(',');
                        fields[0] = fields[0].PadLeft(8, '0');
                        _DataTable����ǈꗗ.Rows.Add(fields);
                    }
                }

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(txtConnectionString.Text))
                {
                    bulkCopy.DestinationTableName = "tImport_MeasurementStation";

                    // ��̃}�b�s���O��ݒ�
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

                    await bulkCopy.WriteToServerAsync(_DataTable����ǈꗗ);
                }

                MessageBox.Show("CSV�t�@�C���̃C���|�[�g���������܂����B", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btn�C���|�[�g�����f�[�^������_����ǈꗗ_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("�C���|�[�g�����f�[�^�̌��؂��J�n���܂����H", "�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                int fileTotalLineCnt = 0;
                var uniqueValues = new HashSet<string>();
                var lines = File.ReadAllLines(txt����ǈꗗ�f�[�^�t�@�C���p�X.Text);
                fileTotalLineCnt += lines.Length - 1; // �w�b�_�s�������s�����J�E���g

                bool isFirstLine = true;
                foreach (var line in lines)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false; // �ŏ��̍s���X�L�b�v
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

                    // �s�����擾
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tImport_MeasurementStation", conn))
                    {
                        tImportPlane_TotalRowCount = (int)cmd.ExecuteScalar();
                    }

                    // ���j�[�N��MeasurementStationCode�̐����擾
                    using (var cmd = new SqlCommand("SELECT COUNT(DISTINCT MeasurementStationCode) FROM tImport_MeasurementStation", conn))
                    {
                        tImportPlane_StationCode_UniqueCount = (int)cmd.ExecuteScalar();
                    }
                }

                MessageBox.Show(@$"file_StationCode_UniqueCount:{uniqueValues.Count} => tImportPlane_StationCode_UniqueCount:{tImportPlane_StationCode_UniqueCount}
fileTotalLineCnt:{fileTotalLineCnt} => tImportPlane_TotalRowCount:{tImportPlane_TotalRowCount}
", "���،���", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private async void btnCSV�t�@�C���C���|�[�g���s_����ǈꗗ_�s���{��_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("CSV�t�@�C���̃C���|�[�g���J�n���܂����H", "�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                {
                    conn.Open();

                    // �f�[�^�͏���
                    using (var cmd = new SqlCommand("TRUNCATE TABLE tImport_MeasurementStation_�s���{��", conn))
                    {
                        await cmd?.ExecuteNonQueryAsync();
                    }
                }

                _DataTable����ǈꗗ_�s���{��.Clear();

                using (StreamReader sr = new StreamReader(txt����ǈꗗ�s���{���f�[�^�t�@�C���p�X.Text))
                {
                    await sr.ReadLineAsync(); // �w�b�_�s��ǂݔ�΂�

                    string? line;
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        var fields = line.Split(',');
                        fields[0] = fields[0].PadLeft(8, '0');
                        _DataTable����ǈꗗ_�s���{��.Rows.Add(fields[0].Trim(), fields[2].Trim());
                    }
                }

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(txtConnectionString.Text))
                {
                    bulkCopy.DestinationTableName = "tImport_MeasurementStation_�s���{��";

                    // ��̃}�b�s���O��ݒ�
                    bulkCopy.ColumnMappings.Add(0, "MeasurementStationCode");
                    bulkCopy.ColumnMappings.Add(1, "�s���{��");

                    await bulkCopy.WriteToServerAsync(_DataTable����ǈꗗ_�s���{��);
                }

                MessageBox.Show("CSV�t�@�C���̃C���|�[�g���������܂����B", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btn�C���|�[�g�����f�[�^������_����ǈꗗ_�s���{��_Click(object sender, EventArgs e)
        {
            try
            {
                int tImport_MeasurementStation_Count = 0;
                int tImport_MeasurementStation_�s���{��_Count = 0;
                using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                {
                    conn.Open();

                    // �s�����擾
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tImport_MeasurementStation", conn))
                    {
                        tImport_MeasurementStation_Count = (int)cmd.ExecuteScalar();
                    }

                    // �s�����擾
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tImport_MeasurementStation_�s���{��", conn))
                    {
                        tImport_MeasurementStation_�s���{��_Count = (int)cmd.ExecuteScalar();
                    }
                }

                MessageBox.Show(@$"tImport_MeasurementStation �s��:{tImport_MeasurementStation_Count} => tImport_MeasurementStation_�s���{�� �s��:{tImport_MeasurementStation_�s���{��_Count}
", "���،���", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private async void btn���K�e�[�u���֕ϊ�_����ǈꗗ_Click(object sender, EventArgs e)
        {
            int startRow = 0;
            int endRow = 0;

            try
            {
                if (MessageBox.Show("�C���|�[�g�����f�[�^��ϊ����܂����H", "�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                {
                    await conn.OpenAsync();

                    // tImport�e�[�u���̃f�[�^�͏���
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM tMeasurementStation", conn))
                    {
                        await cmd?.ExecuteNonQueryAsync();
                    }

                    // tImportPlane �e�[�u���̍ő�Id���擾
                    long maxId;
                    using (SqlCommand cmd = new SqlCommand("SELECT MAX(Id) FROM tImport_MeasurementStation", conn))
                    {
                        maxId = (long)await cmd?.ExecuteScalarAsync();
                    }

                    //_ProcessingDialog.Invoke(new Action(() =>
                    //{
                    //    _ProcessingDialog.StatusText = $"RowCntMax:{maxId}";// UI���X�V
                    //}));

                    // n�������[�v���s
                    for (startRow = int.Parse(txtStartRow.Text); startRow <= maxId; startRow = endRow + 1)
                    {
                        endRow = startRow + 99999;
                        //_ProcessingDialog.Invoke(new Action(() =>
                        //{
                        //    _ProcessingDialog.StatusText = $"startRow:{startRow} / endRow:{endRow}";// UI���X�V
                        //}));

                        using (SqlCommand cmd = new SqlCommand("InsertMeasurementStation", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = Int32.MaxValue; // �ő���̃^�C���A�E�g�l��ݒ�

                            // �p�����[�^�̐ݒ�
                            //cmd.Parameters.Add(new SqlParameter("@StartRow", startRow));
                            //cmd.Parameters.Add(new SqlParameter("@EndRow", endRow));

                            // �X�g�A�h�v���V�[�W���̎��s
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                }

                MessageBox.Show("�C���|�[�g�����f�[�^�̕ϊ����������܂����B", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \r\n startRow:{startRow} endRow:{endRow}");
            }
        }

        private void btn�ϊ������f�[�^������_����ǈꗗ_Click(object sender, EventArgs e)
        {
            try
            {
                int tImport_MeasurementStation_Count = 0;
                int tImport_MeasurementStation_�s���{��_Count = 0;
                int tMeasurementStation_Count = 0;
                using (SqlConnection conn = new SqlConnection(txtConnectionString.Text))
                {
                    conn.Open();

                    // �s�����擾
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tImport_MeasurementStation", conn))
                    {
                        tImport_MeasurementStation_Count = (int)cmd.ExecuteScalar();
                    }

                    // �s�����擾
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tImport_MeasurementStation_�s���{��", conn))
                    {
                        tImport_MeasurementStation_�s���{��_Count = (int)cmd.ExecuteScalar();
                    }

                    // �s�����擾
                    using (var cmd = new SqlCommand("SELECT COUNT(*) FROM tMeasurementStation", conn))
                    {
                        tMeasurementStation_Count = (int)cmd.ExecuteScalar();
                    }
                }

                MessageBox.Show(@$"tImport_MeasurementStation �s��:{tImport_MeasurementStation_Count} => tImport_MeasurementStation_�s���{�� �s��:{tImport_MeasurementStation_�s���{��_Count} => tMeasurementStation_Count �s��:{tMeasurementStation_Count}", "���،���", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btnMapURL����_Click(object sender, EventArgs e)
        {
            var stationCode = string.Empty;
            var prefecture = string.Empty;
            var address = string.Empty;
            try
            {
                if (MessageBox.Show("Map URL �𐶐����܂����H", "�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                var stationData = new List<Tuple<string, string, string>>();

                using (var conn = new SqlConnection(txtConnectionString.Text))
                {
                    conn.Open();

                    // tMeasurementStation �e�[�u������s���{���ƏZ�����擾���ă��X�g�ɕۑ�
                    using (var selectCommand = new SqlCommand("SELECT MeasurementStationCode, [�s���{��], Address FROM tMeasurementStation", conn))
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

                    // Google Map URL ���X�V
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

                    // ����܂߂��� URL ���X�V
                    foreach (var item in stationData)
                    {
                        var combinedAddress = item.Item2 + " " + item.Item3;
                        var encodedAddress = WebUtility.UrlEncode(combinedAddress);

                        using (var updateCommand = new SqlCommand("UPDATE tMeasurementStation SET ����܂߂���URL = @����܂߂���URL WHERE MeasurementStationCode = @StationCode", conn))
                        {
                            updateCommand.Parameters.AddWithValue("@����܂߂���URL", @$"https://soramame.env.go.jp/preview/table/{item.Item1}/7day/SO2/-");
                            updateCommand.Parameters.AddWithValue("@StationCode", item.Item1);

                            updateCommand.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Map URL �𐶐����܂����B", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("�G���[���������܂���: " + ex.Message + $"\r\n stationCode:{stationCode} \r\n prefecture:{prefecture} \r\n address:{address}");
            }
        }
        #endregion 2. ����ǃ}�X�^

        #region 3. �T�}���[���v�Z
        private void btn�X�V_cmbYear_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("�X�V���܂����H", "�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                cmbYear�X�V();

                MessageBox.Show("�X�V���܂����B", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("�G���[���������܂���: " + ex.Message);
            }
        }

        private void cmbYear�X�V()
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
                    MessageBox.Show("�N�������I������Ă��܂���", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("�T�}���[���v�Z���܂����H", "�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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

                            // �f�[�^�͏���
                            using (SqlCommand cmd = new SqlCommand(@$"DELETE FROM tSummary WHERE Year={year}", conn))
                            {
                                await cmd?.ExecuteNonQueryAsync();
                            }

                            using (SqlCommand cmd = new SqlCommand("InsertSummary", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@Year", year);

                                // �X�g�A�h�v���V�[�W���̎��s
                                await cmd.ExecuteNonQueryAsync();
                            }
                        }
                    }
                    finally
                    {
                        processingDialog.Invoke(new Action(() =>
                        {
                            processingDialog.Close(); // �o�b�N�O���E���h�������������������
                        }));
                    }
                });

                processingDialog.ShowDialog(); // �������_�C�A���O��\��

                await task; // �o�b�N�O���E���h��������������܂őҋ@

                MessageBox.Show("�T�}���[���v�Z���������܂����B", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btn�T�}���[�v�Z���ʂ�����_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("�T�}���[�v�Z���ʂ̌��؂��J�n���܂����H", "�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                string result = "�ytSummary�e�[�u���z\r\n";

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

                    result += "\r\n�ytMeasurementData�e�[�u���z\r\n";

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

                    result += "\r\n�ytSummary�EtMeasurementStation�e�[�u���z\r\n";

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
                                result += $"MeasurementStationCode�s��v�i����ǈꗗ�ɖ����A�f�[�^�͗L��j: Count: {reader[0]}\r\n";
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
                                result += $"MeasurementStationCode�s��v�i����ǈꗗ�ɗL��A�f�[�^�͖����j: Count: {reader[0]}\r\n";
                            }
                        }
                    }
                }


                // result �ɂ͗����̃N�G���̌��ʂ��܂܂�Ă��܂�
                MessageBox.Show(result, "���،���", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btn�v�Z���ʂ��m�F_Click(object sender, EventArgs e)
        {
            var viewer = new Form�v�Z����Viewer(txtConnectionString.Text, cmbYear.Items.Cast<string>(), int.Parse(cmbYear.Text));
            viewer.Show();
        }

        #endregion 3. �T�}���[���v�Z

        private void btn������_Click(object sender, EventArgs e)
        {
            var f������ = new F������();
            f������.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigurationManager.AppSettings["ConnectionString"] = txtConnectionString.Text;
            ConfigurationManager.AppSettings["FolderPath"] = txtZipFolderPath.Text;
        }

    }
}
