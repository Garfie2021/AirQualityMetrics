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
        internal static int MaxPM25;
        internal static int MaxNOx2;
        
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

            var maxPM25 = ConfigurationManager.AppSettings["MaxPM25"];
            if (!string.IsNullOrEmpty(maxPM25))
            {
                StaticClass.MaxPM25 = int.Parse(maxPM25);
            }
            else
            {
                StaticClass.MaxPM25 = 70000;
            }

            var maxNOx2 = ConfigurationManager.AppSettings["MaxNOx2"];
            if (!string.IsNullOrEmpty(maxNOx2))
            {
                StaticClass.MaxNOx2 = int.Parse(maxNOx2);
            }
            else
            {
                StaticClass.MaxNOx2 = 30;
            }
        }

        internal static void SavePrefecturesState(BindingList<Prefecture> prefectures, string maxPM25, string maxNOx2)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var values = new List<string>();

            foreach (var prefecture in prefectures)
            {
                // 都道府県名と選択状態をカンマ区切りで保存
                values.Add($"{prefecture.Name},{prefecture.Selected}");
            }

            // カンマ区切りの値をセミコロンで連結して保存
            string savedData = String.Join(";", values);

            // 設定が存在しない場合は追加、存在する場合は値を更新
            if (config.AppSettings.Settings["PrefecturesData"] == null)
                config.AppSettings.Settings.Add("PrefecturesData", savedData);
            else
                config.AppSettings.Settings["PrefecturesData"].Value = savedData;

            if (config.AppSettings.Settings["MaxPM25"] == null)
                config.AppSettings.Settings.Add("MaxPM25", maxPM25);
            else
                config.AppSettings.Settings["MaxPM25"].Value = maxPM25;

            if (config.AppSettings.Settings["MaxNOx2"] == null)
                config.AppSettings.Settings.Add("MaxNOx2", maxNOx2);
            else
                config.AppSettings.Settings["MaxNOx2"].Value = maxNOx2;

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }


    }
}
