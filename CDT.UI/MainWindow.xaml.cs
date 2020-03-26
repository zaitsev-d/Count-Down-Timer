using CDT.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CDT.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Holiday> holidays = new List<Holiday>();
        CDTCore cDTCore = new CDTCore();

        public MainWindow()
        {
            InitializeComponent();
            
            var timer1 = new DispatcherTimer();
            timer1.Interval = new TimeSpan(0, 0, 1);
            timer1.Tick += Timer_Tick;
            timer1.Start();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
           DateTime bd_test = new DateTime(1993, 6, 25);
            var birthday = new Holiday("Birthday", bd_test);
            holidays.Add(birthday);

            cDTCore.CounterBuilder(bd_test);
        }

        private void Timer_Tick(Object s, EventArgs e)
        {
            if (cDTCore.Hours == 0)
            {
                cDTCore.Days--;
                Progress.Value += 1;
            }
            if (cDTCore.Minutes == 0) cDTCore.Hours--;
            if (cDTCore.Seconds == 0) cDTCore.Minutes--;

            if (cDTCore.Seconds <= 0) cDTCore.Seconds = 59;
            else cDTCore.Seconds--;

            if (cDTCore.Hours <= 0) cDTCore.Hours = 23;
            if (cDTCore.Minutes <= 0) cDTCore.Minutes = 59;

            CountDownTimer.Text = string.Format($"{cDTCore.Days} : {cDTCore.Hours} : {cDTCore.Minutes} : {cDTCore.Seconds}");
            Progress.Value = cDTCore.Days;
        }
    }
}
