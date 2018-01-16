using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ebsUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Academic : Page
    {
        List<string> xOsa = new List<string>();
        List<int> yOsa = new List<int>();

        public Academic()
        {
            this.InitializeComponent();
        }

        private void LoadChartContents(List<string> a, List<int> b)
        {
            Random rand = new Random();
            List<Records> records = new List<Records>();

            for (int i = 0; i < a.Count; i++)
            {
                records.Add(new Records()
                {
                    Name = a[i],
                    Amount = b[i]
                });
            }

            (PieChart.Series[0] as PieSeries).ItemsSource = records;
            (ColumnChart.Series[0] as ColumnSeries).ItemsSource = records;
            (lineChart.Series[0] as LineSeries).ItemsSource = records;
        }

        private void cmbMake_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbModel.Items.Clear();

            if (cmbMake.SelectedIndex == 0)
            {
                cmbModel.Items.Add("count");
            }
            else if (cmbMake.SelectedIndex == 1)
            {
                cmbModel.Items.Add("department");
            }
        }

        private void drawChart(object sender, RoutedEventArgs e)
        {
            GetData();
            LoadChartContents(xOsa, yOsa);

            ColumnChart.Visibility = Visibility.Visible;

            PieChart.Visibility = Visibility.Collapsed;
            lineChart.Visibility = Visibility.Collapsed;
        }

        private void drawPie(object sender, RoutedEventArgs e)
        {
            GetData();
            LoadChartContents(xOsa, yOsa);

            PieChart.Visibility = Visibility.Visible;

            ColumnChart.Visibility = Visibility.Collapsed;
            lineChart.Visibility = Visibility.Collapsed;
        }

        private void drawLine(object sender, RoutedEventArgs e)
        {
            GetData();
            LoadChartContents(xOsa, yOsa);

            lineChart.Visibility = Visibility.Visible;

            ColumnChart.Visibility = Visibility.Collapsed;
            PieChart.Visibility = Visibility.Collapsed;
        }

        private void GetData()
        {
            if (xOsa != null) xOsa.Clear();
            if (yOsa != null) yOsa.Clear();

            if (cmbMake.SelectedIndex == 0)
            {
                xOsa.Add("professor"); xOsa.Add("assistant"); 
                yOsa.Add(38); yOsa.Add(38);                 
            }
            else if (cmbMake.SelectedIndex == 1)
            {
                xOsa.Add("RI"); xOsa.Add("AiE"); xOsa.Add("EE"); xOsa.Add("TK");
                yOsa.Add(19); yOsa.Add(14); yOsa.Add(9); yOsa.Add(20); 
            }
        }
    }
}
