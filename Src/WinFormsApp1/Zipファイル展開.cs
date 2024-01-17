using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Zipファイル展開 : Form
    {
        string FolderPathWork;
        string FolderPathZip;

        public Zipファイル展開(string folderPathZip, string folderPathWork)
        {
            InitializeComponent();

            // チェックボックス列を追加
            var column1 = new DataGridViewCheckBoxColumn
            {
                Name = "Select",
                HeaderText = "選択",
                Width = 50
            };
            dataGridView1.Columns.Add(column1);

            // ファイル名列を追加
            var column2 = new DataGridViewTextBoxColumn
            {
                Name = "FileName",
                HeaderText = "ファイル名",
                Width = 200
            };
            dataGridView1.Columns.Add(column2);

            FolderPathZip = folderPathZip;
            FolderPathWork = folderPathWork;
        }

        private void Zipファイル展開_Load(object sender, EventArgs e)
        {
            var files = Directory.GetFiles(FolderPathZip);

            foreach (var file in files)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells["FileName"].Value = Path.GetFileName(file);
            }
        }

        private void btn実行_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Zipファイルの展開を開始しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            // workディレクトリが存在する場合は削除
            if (Directory.Exists(FolderPathWork))
            {
                Directory.Delete(FolderPathWork, true); // true でディレクトリ内のすべてのファイルを削除
            }

            // workディレクトリを新規作成
            Directory.CreateDirectory(FolderPathWork);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // チェックボックスの列がチェックされているか確認
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    // チェックされた行のファイル名を取得
                    var zipFile = FolderPathZip + "\\" + row.Cells["FileName"].Value.ToString();

                    try
                    {
                        // ZIPファイルを指定されたフォルダに展開
                        ZipFile.ExtractToDirectory(zipFile, FolderPathWork);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"エラー: {ex.Message}");
                    }
                }
            }

            MessageBox.Show("Zipファイルの展開が完了しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }

        private void btn全選択_Click(object sender, EventArgs e)
        {

        }
    }
}
