namespace WinFormsApp1
{
    // 都道府県を表すカスタムクラス
    public class Prefecture
    {
        public bool Selected { get; set; }
        public string Name { get; set; }

        public Prefecture(bool selected, string name)
        {
            Selected = selected;
            Name = name;
        }
    }

}
