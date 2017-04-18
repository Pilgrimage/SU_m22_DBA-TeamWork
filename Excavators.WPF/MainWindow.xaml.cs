using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Excavators.Models.DTO;

namespace Excavators.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
                foreach (var tempAllDto in tempAll)
                {
                    textBox.Text = tempAllDto.SensorName;
                }
                
            }
            else if (RadioButtonOnlyWarnings.IsChecked==true)
            {
                textBox.Text = "Temperatures Only Warnings: Import from Database Temperatures Only Warnings";
            }
        }

        private void ButtonCurrents_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButtonAllValues.IsChecked == true)
            {
                textBox.Text = "Currents All Value:Import from Database Currents All Value";
            }
            else if (RadioButtonOnlyWarnings.IsChecked == true)
            {
                textBox.Text = "Currents Only Warnings:Import from Database Currents Only Warnings";
            }
        }

        private void ButtonSpeeds_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButtonAllValues.IsChecked == true)
            {
                textBox.Text = "Speeds All Value:Import from Database Speeds All Value";
            }
            else if (RadioButtonOnlyWarnings.IsChecked == true)
            {
                textBox.Text = "Speeds Only Warnings:Import from Database Speeds Only Warnings";
            }
        }

        private void ButtonTensions_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButtonAllValues.IsChecked == true)
            {
                textBox.Text = "Tensions All Value:Import from Database Tensions All Value";
            }
            else if (RadioButtonOnlyWarnings.IsChecked == true)
            {
                textBox.Text = "Tensions Only Warnings:Import from Database Tensions Only Warnings";
            }
        }

        private void ButtonVolumes_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButtonAllValues.IsChecked == true)
            {
                textBox.Text = "Volumes All Value:Import from Database Volumes All Value";
            }
            else if (RadioButtonOnlyWarnings.IsChecked == true)
            {
                textBox.Text = "Volumes Only Warnings:Import from Database Volumes Only Warnings";
            }
        }
    }
}
