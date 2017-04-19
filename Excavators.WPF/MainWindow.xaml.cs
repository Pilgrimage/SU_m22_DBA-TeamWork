namespace Excavators.WPF
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using Newtonsoft.Json;
    using Excavators.Models.DTO;
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonTemperatures_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButtonAllValues.IsChecked==true)
            {
                var json = File.ReadAllText("../../../ExportJson/tempAllDto.json");
                var tempAll = JsonConvert.DeserializeObject<IEnumerable<TempAllDto>>(json);
                dataGrid.ItemsSource= tempAll.Take(500);

            }
            else if (RadioButtonOnlyWarnings.IsChecked==true)
            {
                var json = File.ReadAllText("../../../ExportJson/tempWarningsDto.json");
                var tempWarnings = JsonConvert.DeserializeObject<IEnumerable<TempWarningsDto>>(json);
                dataGrid.ItemsSource = tempWarnings.Take(500);
            }
        }

        private void ButtonCurrents_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButtonAllValues.IsChecked == true)
            {
                var json = File.ReadAllText("../../../ExportJson/currentAllDto.json");
                var currentAll = JsonConvert.DeserializeObject<IEnumerable<CurrentAllDto>>(json);
                dataGrid.ItemsSource = currentAll.Take(500);
            }
            else if (RadioButtonOnlyWarnings.IsChecked == true)
            {
                var json = File.ReadAllText("../../../ExportJson/currentWarningsDto.json");
                var currentWarnings = JsonConvert.DeserializeObject<IEnumerable<CurrentWarningsDto>>(json);
                dataGrid.ItemsSource = currentWarnings.Take(500);
            }
        }

        private void ButtonSpeeds_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButtonAllValues.IsChecked == true)
            {
                var json = File.ReadAllText("../../../ExportJson/speedAllDto.json");
                var speedAll = JsonConvert.DeserializeObject<IEnumerable<SpeedAllDto>>(json);
                dataGrid.ItemsSource = speedAll.Take(500);
            }
            else if (RadioButtonOnlyWarnings.IsChecked == true)
            {
                var json = File.ReadAllText("../../../ExportJson/speedWarningsDto.json");
                var speedWarnings = JsonConvert.DeserializeObject<IEnumerable<SpeedWarningsDto>>(json);
                dataGrid.ItemsSource = speedWarnings.Take(500);
            }
        }

        private void ButtonTensions_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButtonAllValues.IsChecked == true)
            {
                var json = File.ReadAllText("../../../ExportJson/tensionAllDto.json");
                var tensionAll = JsonConvert.DeserializeObject<IEnumerable<TensionAllDto>>(json);
                dataGrid.ItemsSource = tensionAll.Take(500);
            }
            else if (RadioButtonOnlyWarnings.IsChecked == true)
            {
                var json = File.ReadAllText("../../../ExportJson/tensionWarningsDto.json");
                var tensionWarnings = JsonConvert.DeserializeObject<IEnumerable<TensionWarningsDto>>(json);
                dataGrid.ItemsSource = tensionWarnings.Take(500);
            }
        }

        private void ButtonVolumes_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButtonAllValues.IsChecked == true)
            {
                var json = File.ReadAllText("../../../ExportJson/volumeAllDto.json");
                var volumeAll = JsonConvert.DeserializeObject<IEnumerable<VolumeAllDto>>(json);
                dataGrid.ItemsSource = volumeAll.Take(500);
            }
            else if (RadioButtonOnlyWarnings.IsChecked == true)
            {
                var json = File.ReadAllText("../../../ExportJson/volumeWarningsDto.json");
                var volumeWarnings = JsonConvert.DeserializeObject<IEnumerable<VolumeWarningsDto>>(json);
                dataGrid.ItemsSource = volumeWarnings.Take(500);
            }
        }
    }
}
