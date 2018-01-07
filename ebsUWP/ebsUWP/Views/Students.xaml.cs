using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ebsUWP.Views
{
    public class Records  
    {  
        public string Name
        {
            get;
            set;
        }
        public int Amount
        {
            get;
            set;
        }
    }
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class Students : Page
    {
 

        public Students()
        {
            this.InitializeComponent();
            LoadChartContents(); 
        }

        private void LoadChartContents()
        {
            Random rand = new Random();
            List<Records> records = new List<Records>();
            records.Add(new Records()
            {
                        Name = "Suresh", Amount = rand.Next(0, 200)
            });
            records.Add(new Records()
            {
                        Name = "C# Corner", Amount = rand.Next(0, 200)
            });
            records.Add(new Records()
            {
                        Name = "Sam", Amount = rand.Next(0, 200)
            });
            records.Add(new Records()
            {
                        Name = "Sri", Amount = rand.Next(0, 200)
            });
            (PieChart.Series[0] as PieSeries).ItemsSource = records;
            (ColumnChart.Series[0] as ColumnSeries).ItemsSource = records;
            (lineChart.Series[0] as LineSeries).ItemsSource = records;
        }

        private void cmbMake_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbModel.Items.Clear();

            if (cmbMake.SelectedIndex == 0)//All
            {
                cmbModel.Items.Add("posljednje 3 godine");
                cmbModel.Items.Add("posljednjih 5 godina");
            }
            else if (cmbMake.SelectedIndex == 1)//Flagged
            {
                cmbModel.Items.Add("RI");
                cmbModel.Items.Add("AiE");
                cmbModel.Items.Add("EE");
                cmbModel.Items.Add("TK");
            }
            else if (cmbMake.SelectedIndex == 2)//Flagged
            {
                cmbModel.Items.Add("BoE");
                cmbModel.Items.Add("MoE");
                cmbModel.Items.Add("PhD");
            }
        }

        private void drawChart(object sender, RoutedEventArgs e)
        {
            ColumnChart.Visibility = Visibility.Visible;

            PieChart.Visibility = Visibility.Collapsed;
            lineChart.Visibility = Visibility.Collapsed;
        }

        private void drawPie(object sender, RoutedEventArgs e)
        {
            PieChart.Visibility = Visibility.Visible;

            ColumnChart.Visibility = Visibility.Collapsed;
            lineChart.Visibility = Visibility.Collapsed;
        }

        private void drawLine(object sender, RoutedEventArgs e)
        {
            lineChart.Visibility = Visibility.Visible;

            ColumnChart.Visibility = Visibility.Collapsed;
            PieChart.Visibility = Visibility.Collapsed;
        }
    }
}
