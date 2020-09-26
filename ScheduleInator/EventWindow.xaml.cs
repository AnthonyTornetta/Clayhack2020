using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ScheduleInator
{
    /// <summary>
    /// Interaction logic for EventWindow.xaml
    /// </summary>
    public partial class EventWindow : Window
    {
        public EventWindow()
        {
            InitializeComponent();
        }

        public static Event PollUser()
        {
            EventWindow window = new EventWindow();
            window.ShowDialog();

            string name = window.tboxEventName.Text;
            DateTime? date = window.dueDate.SelectedDate;

            bool[] days = new bool[7];
            days[0] = (bool)window.chk0.IsChecked;
            days[1] = (bool)window.chk1.IsChecked;
            days[2] = (bool)window.chk2.IsChecked;
            days[3] = (bool)window.chk3.IsChecked;
            days[4] = (bool)window.chk4.IsChecked;
            days[5] = (bool)window.chk5.IsChecked;
            days[6] = (bool)window.chk6.IsChecked;


            if (window.grdETA.Visibility == Visibility.Visible)
            {
                // It's the ETA they want
                string etaMin = window.etaMinutes.Text;
                string etaHours = window.etaHours.Text;

                Time eta = new Time(Int32.Parse(etaHours), Int32.Parse(etaMin));

                return new Event(name, (DateTime)date, new CustomTime(days, false, eta);
                // hf dealing with those strings
            }
            else
            {
                // It's a specific date they want
                string startTime = window.startTime.Text;
                string endTime = window.endTime.Text;

                Time start = ParseTimes(startTime);
                Time end = ParseTimes(endTime);

                return new Event(name, (DateTime)date, new CustomTime(start, end, days, true));
                // hf 2.0
            }


        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnEnableDuedate_Click(object sender, RoutedEventArgs e)
        {
            btnEnableDuedate.Visibility = Visibility.Hidden;
            dueDate.Visibility = Visibility.Visible;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void btnTimeToggle_Click(object sender, RoutedEventArgs e)
        {
            if (grdETA.Visibility == Visibility.Visible)
            {
                btnTimeToggle.Content = "Set ETA";
                grdETA.Visibility = Visibility.Hidden;
                grdTimes.Visibility = Visibility.Visible;
            }
            else
            {
                btnTimeToggle.Content = "Specific Time";
                grdETA.Visibility = Visibility.Visible;
                grdTimes.Visibility = Visibility.Hidden;
            }
        }

        public static Time ParseTimes(string time)
        {

            if (time.Contains("am") || time.Contains("AM") || time.Contains("Am"))
            {
                string[] hourMinute = time.Split(':');
                Time eta = new Time(Int32.Parse(hourMinute[0]), Int32.Parse(hourMinute[1]));
                return eta;
            }
            else if (time.Contains("pm") || time.Contains("PM") || time.Contains("Pm"))
            {
                string[] hourMinute = time.Split(':');
                Time eta = new Time(12 + Int32.Parse(hourMinute[0]), Int32.Parse(hourMinute[1]));
                return eta;
            }
            else
            {
                string[] hourMinute = time.Split(':');
                Time eta = new Time(Int32.Parse(hourMinute[0]), Int32.Parse(hourMinute[1]));
                return eta;
            }
        }
    }
}
