using System.Data;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Text;

namespace WinFormsApp1
{
    public partial class Form計算結果Viewer : Form
    {
        string ConnectionString;

        public Form計算結果Viewer(string connectionString, IEnumerable<string> cmbYearItems, int year)
        {
            InitializeComponent();

            this.ConnectionString = connectionString;

            // Enumの値をコンボボックスに追加
            cmbSelectType.Items.AddRange(Enum.GetNames(typeof(ReportType)));
            cmbSelectType.SelectedIndex = (int)ReportType.大気汚染順;

            foreach (var item in cmbYearItems)
            {
                cmbYear.Items.Add(item);
            }

            cmbYear.Text = year.ToString();
        }

        private void Form計算結果Viewer_Load(object sender, EventArgs e)
        {
            更新();
        }

        private void btn詳細条件_Click(object sender, EventArgs e)
        {
            var form詳細条件 = new Form詳細条件();
            form詳細条件.Show();
        }

        private void btn更新_Click(object sender, EventArgs e)
        {
            更新();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.RowIndex >= 0)
                {
                    var url = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                    if (!string.IsNullOrEmpty(url))
                    {
                        // URL を既定のブラウザで開く
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = url,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var dataGridView = sender as DataGridView;
                if (dataGridView == null) return;

                var column = dataGridView.Columns[e.ColumnIndex];

                // 現在のソート方向を切り替える
                ListSortDirection direction;
                if (dataGridView.SortOrder == System.Windows.Forms.SortOrder.Ascending || dataGridView.SortOrder == System.Windows.Forms.SortOrder.None)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }

                // 指定した列でソートする
                dataGridView.Sort(column, direction);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btnCSVファイル出力_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSVファイル (*.csv)|*.csv",
                    Title = "CSVファイルに保存"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                    {
                        // ヘッダー行の書き込み
                        var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
                        sw.WriteLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

                        // データ行の書き込み
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            var cells = row.Cells.Cast<DataGridViewCell>();
                            sw.WriteLine(string.Join(",", cells.Select(cell =>
                            {
                                var cellValue = cell.Value?.ToString() ?? "";
                                // 0で始まる数値データの場合、等号を追加してExcelでの表示を調整
                                if (cellValue.StartsWith("0") && cellValue.All(char.IsDigit))
                                {
                                    return "\"=\"" + cellValue + "\"\"";
                                }
                                else
                                {
                                    return "\"" + cellValue + "\"";
                                }
                            }).ToArray()));
                        }
                    }

                    MessageBox.Show("CSVファイルに保存しました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void btnHTMLファイル出力_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "テキストファイル (*.txt)|*.txt",
                    Title = "テキストファイルに保存",
                    FileName = "html.txt"
                };

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                StringBuilder htmlTable = new StringBuilder();
                htmlTable.AppendLine("<figure class=\"wp-block-table\"><table><thead style=\"background-color: #e0f2f1;\"><tr><th rowspan=\"2\" style=\"border: 1px solid #ccc;\">順位</th><th rowspan=\"2\" style=\"border: 1px solid #ccc;\">測定局</th><th rowspan=\"2\" style=\"border: 1px solid #ccc;\">住所</th><th colspan=\"2\" class=\"has-text-align-center\" data-align=\"center\" style=\"border: 1px solid #ccc;\">年間総量</th></tr><tr><th style=\"border: 1px solid #ccc;\">PM25</th><th style=\"border: 1px solid #ccc;\">NO2</th></tr></thead><tbody>");

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    htmlTable.AppendLine("<tr>");
                    htmlTable.AppendLine($"<td>{row.Cells[0].Value}</td>");
                    htmlTable.AppendLine($"<td><a href=\"{row.Cells[2].Value}\">{row.Cells[1].Value}</a></td>");
                    htmlTable.AppendLine($"<td><a href=\"{row.Cells[6].Value}\">{row.Cells[4].Value}{row.Cells[5].Value}</a></td>");
                    htmlTable.AppendLine($"<td class=\"has-text-align-right\" data-align=\"right\">{row.Cells[8].Value}</td>");
                    htmlTable.AppendLine($"<td class=\"has-text-align-right\" data-align=\"right\">{row.Cells[9].Value}</td>");
                    htmlTable.AppendLine("</tr>");
                }

                htmlTable.AppendLine("</tbody></table></figure>");

                // HTMLテーブルをファイルに出力
                File.WriteAllText(saveFileDialog.FileName, htmlTable.ToString());

                MessageBox.Show("HTMLファイルに保存しました。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

        }

        private void 更新()
        {
            dataGridView1.Columns.Clear();

            // DataTableを用意
            var dataTable = new DataTable();

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand("Select解析結果_局単位", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SelectType", cmbSelectType.SelectedIndex);
                    cmd.Parameters.AddWithValue("@Year", int.Parse(cmbYear.Text));
                    cmd.Parameters.AddWithValue("@PrefecturesCSV", String.Join(",", StaticClass.Prefectures.Where(x => x.Selected).Select(x2 => x2.Name)));
                    cmd.Parameters.AddWithValue("@MaxPM25", StaticClass.MaxPM25);
                    cmd.Parameters.AddWithValue("@MaxNOx2", StaticClass.MaxNOx2);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);    // ストアドプロシージャの実行
                    }
                }
            }

            // DataGridViewのデータソースを設定
            dataGridView1.DataSource = dataTable;

            // DataGridViewLinkColumnを追加
            var linkColumn = new DataGridViewLinkColumn
            {
                DataPropertyName = "MapURL", // URLを含む列名
                HeaderText = "Google Map URL",
                Name = "MapLink"
            };
            dataGridView1.Columns.Insert(5, linkColumn);
            dataGridView1.Columns.RemoveAt(6);

            var linkColumn2 = new DataGridViewLinkColumn
            {
                DataPropertyName = "そらまめくんURL", // URLを含む列名
                HeaderText = "そらまめくん URL",
                Name = "そらまめくんLink"
            };
            dataGridView1.Columns.Insert(2, linkColumn2);
        }

    }
}
