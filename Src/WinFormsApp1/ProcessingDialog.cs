namespace WinFormsApp1
{
    public partial class ProcessingDialog : Form
    {
        // txtStatusのテキストを設定・取得するためのプロパティ
        public string StatusText
        {
            get { return txtStatus.Text; }
            set { txtStatus.Text = value; }
        }

        public ProcessingDialog()
        {
            InitializeComponent();

            this.ControlBox = false; // タイトルバーの制御ボックスを非表示に設定
        }

        private void ProcessingDialog_Shown(object sender, EventArgs e)
        {
            txtStatus.Text = string.Empty;
        }
    }
}
