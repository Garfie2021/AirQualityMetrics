using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form詳細条件 : Form
    {

        public Form詳細条件(IEnumerable<string> yearItems)
        {
            InitializeComponent();

            // Enumの値をコンボボックスに追加
            cmbSelectType.Items.AddRange(Enum.GetNames(typeof(ReportType)));
            cmbSelectType.SelectedIndex = (int)ReportType.大気汚染順;

            BindListToDataGridView();

            foreach (var item in yearItems)
            {
                cmbYear.Items.Add(item);
            }
            cmbYear.Text = 2023.ToString();

        }

        private void Form詳細条件_Load(object sender, EventArgs e)
        {
            cmbSelectType.SelectedIndex = StaticClass.SelectedIndex;
            txtMaxPM25.Text = StaticClass.MaxPM25.ToString();
            txtMaxNOx2.Text = StaticClass.MaxNOx2.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            StaticClass.SavePrefecturesState(
                StaticClass.Prefectures,
                txtMaxPM25.Text,
                txtMaxNOx2.Text,
                cmbSelectType.SelectedIndex.ToString()
                );

            StaticClass.LoadPrefecturesState();

            Close();
        }

        private void btnキャンセル_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void BindListToDataGridView()
        {
            #region 実行初回で必要だった
            //_Prefectures = new BindingList<Prefecture>
            //{
            //    new Prefecture(false, "北海道"),
            //    new Prefecture(false, "青森県"),
            //    new Prefecture(false, "岩手県"),
            //    new Prefecture(false, "宮城県"),
            //    new Prefecture(false, "秋田県"),
            //    new Prefecture(false, "山形県"),
            //    new Prefecture(false, "福島県"),
            //    new Prefecture(false, "茨城県"),
            //    new Prefecture(false, "栃木県"),
            //    new Prefecture(false, "群馬県"),
            //    new Prefecture(false, "埼玉県"),
            //    new Prefecture(false, "千葉県"),
            //    new Prefecture(false, "東京都"),
            //    new Prefecture(false, "神奈川県"),
            //    new Prefecture(false, "新潟県"),
            //    new Prefecture(false, "富山県"),
            //    new Prefecture(false, "石川県"),
            //    new Prefecture(false, "福井県"),
            //    new Prefecture(false, "山梨県"),
            //    new Prefecture(false, "長野県"),
            //    new Prefecture(false, "岐阜県"),
            //    new Prefecture(false, "静岡県"),
            //    new Prefecture(false, "愛知県"),
            //    new Prefecture(false, "三重県"),
            //    new Prefecture(false, "滋賀県"),
            //    new Prefecture(false, "京都府"),
            //    new Prefecture(false, "大阪府"),
            //    new Prefecture(false, "兵庫県"),
            //    new Prefecture(false, "奈良県"),
            //    new Prefecture(false, "和歌山県"),
            //    new Prefecture(false, "鳥取県"),
            //    new Prefecture(false, "島根県"),
            //    new Prefecture(false, "岡山県"),
            //    new Prefecture(false, "広島県"),
            //    new Prefecture(false, "山口県"),
            //    new Prefecture(false, "徳島県"),
            //    new Prefecture(false, "香川県"),
            //    new Prefecture(false, "愛媛県"),
            //    new Prefecture(false, "高知県"),
            //    new Prefecture(false, "福岡県"),
            //    new Prefecture(false, "佐賀県"),
            //    new Prefecture(false, "長崎県"),
            //    new Prefecture(false, "熊本県"),
            //    new Prefecture(false, "大分県"),
            //    new Prefecture(false, "宮崎県"),
            //    new Prefecture(false, "鹿児島県"),
            //    new Prefecture(false, "沖縄県")
            //};
            #endregion

            dataGridView対象都道府県.DataSource = StaticClass.Prefectures;
        }

        private void chk固定測定局コード_CheckedChanged(object sender, EventArgs e)
        {
            if (chk固定測定局コード.Checked)
                txt固定測定局コード.Enabled = true;
            else
                txt固定測定局コード.Enabled = false;
        }
    }
}
