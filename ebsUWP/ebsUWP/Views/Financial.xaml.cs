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
    
    public sealed partial class Financial : Page
    {
        List<string> xOsa = new List<string>();
        List<int> yOsa = new List<int>();

        public Financial()
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
                cmbModel.Items.Add("last 3 years");
                cmbModel.Items.Add("last 5 years");
            }
            else if (cmbMake.SelectedIndex == 1)
            {
                cmbModel.Items.Add("type of employee");
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
                if (cmbModel.SelectedIndex == 0)
                {
                    xOsa.Add("2015/2016"); xOsa.Add("2016/2017"); xOsa.Add("2017/2018");
                    yOsa.Add(35453); yOsa.Add(24453); yOsa.Add(20687);
                }
                else
                {
                    xOsa.Add("'13/'14"); xOsa.Add("'14/'15"); xOsa.Add("'15/'16"); xOsa.Add("'16/'17"); xOsa.Add("'17/'18");
                    yOsa.Add(15900); yOsa.Add(24687); yOsa.Add(35387); yOsa.Add(24657); yOsa.Add(20876);
                }
            }
            else if (cmbMake.SelectedIndex == 1)
            {
                xOsa.Add("Assistant"); xOsa.Add("Assistant professor"); xOsa.Add("Undergraduate teaching assistants"); xOsa.Add("Vice dean"); xOsa.Add("Full professor"); xOsa.Add("Dean");
                yOsa.Add(27705); yOsa.Add(28751); yOsa.Add(25329); yOsa.Add(2485); yOsa.Add(8840); yOsa.Add(1853);                   
            }            
        }
    }
}
