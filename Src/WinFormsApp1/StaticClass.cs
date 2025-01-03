﻿using System;
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
        internal static int SelectedIndex;
        internal static int Year;
        internal static bool 固定測定局コードChecked;
        internal static string 固定測定局コード;

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
                StaticClass.MaxPM25 = int.Parse(maxPM25);
            else
                StaticClass.MaxPM25 = 70000;

            var maxNOx2 = ConfigurationManager.AppSettings["MaxNOx2"];
            if (!string.IsNullOrEmpty(maxNOx2))
                StaticClass.MaxNOx2 = int.Parse(maxNOx2);
            else
                StaticClass.MaxNOx2 = 30;

            var selectedIndex = ConfigurationManager.AppSettings["SelectedIndex"];
            if (!string.IsNullOrEmpty(selectedIndex))
                StaticClass.SelectedIndex = int.Parse(selectedIndex);
            else
                StaticClass.SelectedIndex = 1;

            var 固定測定局コードChecked = ConfigurationManager.AppSettings["固定測定局コードChecked"];
            if (!string.IsNullOrEmpty(固定測定局コードChecked))
                StaticClass.固定測定局コードChecked = bool.Parse(固定測定局コードChecked);
            else
                StaticClass.固定測定局コードChecked = false;

            var 固定測定局コード = ConfigurationManager.AppSettings["固定測定局コード"];
            if (!string.IsNullOrEmpty(固定測定局コード))
                StaticClass.固定測定局コード = 固定測定局コード;
            else
                StaticClass.固定測定局コード = string.Empty;
        }

        internal static void SavePrefecturesState(
            BindingList<Prefecture> prefectures, 
            string maxPM25, 
            string maxNOx2,
            string selectedIndex,
            bool 固定測定局コードChecked,
            string 固定測定局コード)
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

            if (config.AppSettings.Settings["SelectedIndex"] == null)
                config.AppSettings.Settings.Add("SelectedIndex", selectedIndex);
            else
                config.AppSettings.Settings["SelectedIndex"].Value = selectedIndex;

            if (config.AppSettings.Settings["固定測定局コードChecked"] == null)
                config.AppSettings.Settings.Add("固定測定局コードChecked", 固定測定局コードChecked.ToString());
            else
                config.AppSettings.Settings["固定測定局コードChecked"].Value = 固定測定局コードChecked.ToString();

            if (config.AppSettings.Settings["固定測定局コード"] == null)
                config.AppSettings.Settings.Add("固定測定局コード", 固定測定局コード);
            else
                config.AppSettings.Settings["固定測定局コード"].Value = 固定測定局コード;

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }


    }
}
