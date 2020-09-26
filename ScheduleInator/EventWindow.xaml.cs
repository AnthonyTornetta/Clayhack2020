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
                // 6 more times

            if(window.grdETA.Visibility == Visibility.Visible)
            {
                // It's the ETA they want
                string etaMin = window.etaMinutes.Text;
                string etaHours = window.etaHours.Text;

                // hf dealing with those strings
            }
            else
            {
                // It's a specific date they want
                string startTime = window.startTime.Text;
                string endTime = window.endTime.Text;

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
    }
}
