using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal static class StaticClass
    {
        internal static BindingList<Prefecture>? Prefectures;


        internal static void LoadPrefecturesState()
        {
            // App.config から設定を読み込む
            var savedData = ConfigurationManager.AppSettings["PrefecturesData"];

            if (!string.IsNullOrEmpty(savedData))
            {
                var values = savedData.Split(';');
                StaticClass.Prefectures = new BindingList<Prefecture>();

                foreach (var value in values)
                {
                    var parts = value.Split(',');
                    if (parts.Length == 2)
                    {
                        var name = parts[0];
                        var selected = bool.Parse(parts[1]);
                        StaticClass.Prefectures.Add(new Prefecture(selected, name));
                    }
                }
            }
            else
            {
                // デフォルト値を設定するか、空のリストを初期化
                StaticClass.Prefectures = new BindingList<Prefecture>();
            }
        }

        internal static void SavePrefecturesState(BindingList<Prefecture> prefectures)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = config.AppSettings.Settings;
            var values = new List<string>();

            foreach (var prefecture in prefectures)
            {
                // 都道府県名と選択状態をカンマ区切りで保存
                values.Add($"{prefecture.Name},{prefecture.Selected}");
            }

            // カンマ区切りの値をセミコロンで連結して保存
            string savedData = String.Join(";", values);

            // 設定が存在しない場合は追加、存在する場合は値を更新
            if (settings["PrefecturesData"] == null)
            {
                settings.Add("PrefecturesData", savedData);
            }
            else
            {
                settings["PrefecturesData"].Value = savedData;
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }


    }
}
