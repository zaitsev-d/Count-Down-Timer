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
        DateTime currentDate;
        DateTime nextYear;
        DateTime bd_test;
        int days, hours, minutes, seconds;
        DispatcherTimer timer1;

        public MainWindow()
        {
            InitializeComponent();
            timer1 = new DispatcherTimer();
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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            bd_test = new DateTime(1993, 6, 25);
            var birthday = new Holiday("Birthday", bd_test);
            holidays.Add(birthday);

            currentDate = DateTime.Now;
            nextYear = bd_test.AddYears(currentDate.Year - bd_test.Year);

            if (nextYear < currentDate)
            {
                if (!DateTime.IsLeapYear(nextYear.Year + 1))
                    nextYear = nextYear.AddYears(1);
                else
                    nextYear = new DateTime(nextYear.Year + 1, bd_test.Month, bd_test.Day);
            }

            days = (nextYear - currentDate).Days;
            hours = (nextYear - currentDate).Hours;
            minutes = (nextYear - currentDate).Minutes;
            seconds = (nextYear - currentDate).Seconds;
        }

        private void Timer_Tick( Object s, EventArgs e)
        {
            if(hours == 0) days--;
            if (minutes == 0) hours--;
            if (seconds == 0) minutes--;

            if (seconds <= 0) seconds = 59;
            else seconds--;

            if (hours < 0) hours = 23;
            if (minutes < 0) minutes = 59;

            CountDownTimer.Text = string.Format($"{days} : {hours} : {minutes} : {seconds}");
        }
    }
}
