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
        private List<string> xOsa = new List<string>();
        private List<int> yOsa = new List<int>();

        public Students()
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
                cmbModel.Items.Add("last 3 years");
                cmbModel.Items.Add("last 5 years");
            }
            else if (cmbMake.SelectedIndex == 2)
            {
                cmbModel.Items.Add("last 3 years");
                cmbModel.Items.Add("last 5 years");
            }
            else if (cmbMake.SelectedIndex == 3)
            {
                cmbModel.Items.Add("Bachelor");
                cmbModel.Items.Add("Master");
                cmbModel.Items.Add("PhD");
            }
            else 
            {
                cmbModel.Items.Add("RI");
                cmbModel.Items.Add("AiE");
                cmbModel.Items.Add("EE");
                cmbModel.Items.Add("TK");
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
                    yOsa.Add(35); yOsa.Add(24); yOsa.Add(20);
                }
                else
                {
                    xOsa.Add("'13/'14"); xOsa.Add("'14/'15"); xOsa.Add("'15/'16"); xOsa.Add("'16/'17"); xOsa.Add("'17/'18");
                    yOsa.Add(15); yOsa.Add(24); yOsa.Add(35); yOsa.Add(24); yOsa.Add(20);
                }
            }
            else if (cmbMake.SelectedIndex == 1)
            {
                if (cmbModel.SelectedIndex == 0)
                {
                    xOsa.Add("2015/2016"); xOsa.Add("2016/2017"); xOsa.Add("2017/2018");
                    yOsa.Add(12); yOsa.Add(24); yOsa.Add(28);
                }
                else
                {
                    xOsa.Add("'13/'14"); xOsa.Add("'14/'15"); xOsa.Add("'15/'16"); xOsa.Add("'16/'17"); xOsa.Add("'17/'18");
                    yOsa.Add(14); yOsa.Add(19); yOsa.Add(12); yOsa.Add(24); yOsa.Add(28);
                }
            }
            else if (cmbMake.SelectedIndex == 2)
            {
                if (cmbModel.SelectedIndex == 0)
                {
                    xOsa.Add("2015/2016"); xOsa.Add("2016/2017"); xOsa.Add("2017/2018");
                    yOsa.Add(26); yOsa.Add(19); yOsa.Add(21);
                }
                else
                {
                    xOsa.Add("'13/'14"); xOsa.Add("'14/'15"); xOsa.Add("'15/'16"); xOsa.Add("'16/'17"); xOsa.Add("'17/'18");
                    yOsa.Add(16); yOsa.Add(17); yOsa.Add(26); yOsa.Add(19); yOsa.Add(21);
                }
            }
            else if (cmbMake.SelectedIndex == 3)
            {
                if (cmbModel.SelectedIndex == 0)
                {
                    xOsa.Add("First"); xOsa.Add("Second"); xOsa.Add("Third");
                    yOsa.Add(151); yOsa.Add(114); yOsa.Add(92);
                }
                else if (cmbModel.SelectedIndex == 1)
                {
                    xOsa.Add("First"); xOsa.Add("Second");
                    yOsa.Add(106); yOsa.Add(106);
                }
                else
                {
                    xOsa.Add("First"); xOsa.Add("Second"); xOsa.Add("Third");
                    yOsa.Add(58); yOsa.Add(55); yOsa.Add(42);
                }
            }
            else if (cmbMake.SelectedIndex == 4)
            {
                if (cmbModel.SelectedIndex == 0)
                {
                    xOsa.Add("RI"); xOsa.Add("AiE"); xOsa.Add("EE");
                    yOsa.Add(44); yOsa.Add(34); yOsa.Add(30);
                }
                else if (cmbModel.SelectedIndex == 1)
                {
                    xOsa.Add("RI"); xOsa.Add("AiE"); xOsa.Add("EE");
                    yOsa.Add(39); yOsa.Add(29); yOsa.Add(28);
                }
                else
                {
                    xOsa.Add("RI"); xOsa.Add("AiE"); xOsa.Add("EE");
                    yOsa.Add(20); yOsa.Add(30); yOsa.Add(29);
                }
            }
        }
    }
}
