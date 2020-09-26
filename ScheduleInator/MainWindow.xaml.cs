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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScheduleInator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Rectangle[,] rects;

        public MainWindow()
        {
            InitializeComponent();

            Time t = new Time();

            for(int i = 0; i < 24 * 2; i++)
            {
                TextBlock txt = new TextBlock
                {
                    Text = t.ToString(),
                    FontSize = 16
                };
                txt.SetValue(Grid.RowProperty, i);
                grdCalendar.Children.Add(txt);

                t.addMins(30);
            }

            rects = new Rectangle[7, 24 * 2];

            for(int col = 0; col < 7; col++)
            {
                for(int row = 0; row < 24 * 2; row++)
                {
                    rects[col, row] = new Rectangle();

                    rects[col, row].SetValue(Grid.RowProperty, row);
                    rects[col, row].SetValue(Grid.ColumnProperty, col + 1);

                    grdCalendar.Children.Add(rects[col, row]);
                }
            }

            /*
            Random rdm = new Random();

            for (int i = 0; i < 24 * 4; i++)
            {
                RowDefinition def = new RowDefinition();
                def.Height = new GridLength(20);
                viewTwo.RowDefinitions.Add(def);

                for (int j = 0; j < 7; j++)
                {
                    Grid grd = new Grid();
                    grd.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    grd.SetValue(Grid.ColumnProperty, j);
                    grd.SetValue(Grid.RowProperty, i);
                    viewTwo.Children.Add(grd);
                }
            }
            */
        }

        public void addEvent(Event e)
        {
            RowDefinition rowObj = new RowDefinition
            {
                Height = GridLength.Auto
            };

            gridEvents.RowDefinitions.Add(rowObj);

            UIElement lastElem = gridEvents.Children[gridEvents.Children.Count - 1];
            int row = (int)lastElem.GetValue(Grid.RowProperty);

            TextBlock blocc = new TextBlock
            {
                Text = e.Name,
                FontSize = 25,
                VerticalAlignment = VerticalAlignment.Center
            };
            blocc.SetValue(Grid.RowProperty, row);
            blocc.SetValue(Grid.ColumnProperty, 0);

            CustomTime time = e.SpecifiedTime;

            TextBlock timeBlocc = new TextBlock
            {
                Text = time.StartTime.ToString() + " - " + time.EndTime.ToString(),
                FontSize = 25,
                VerticalAlignment = VerticalAlignment.Center
            };
            timeBlocc.SetValue(Grid.RowProperty, row);
            timeBlocc.SetValue(Grid.ColumnProperty, 1);

            Button btnModify = new Button()
            {
                Style = this.FindResource("btn-slick") as Style,
                Content="*",
            };
            btnModify.SetValue(Grid.RowProperty, row);
            btnModify.SetValue(Grid.ColumnProperty, 2);
            btnModify.Click += btnModify_Click;

            Button btnRemove = new Button()
            {
                Style = this.FindResource("btn-slick") as Style,
                Content = "-"
            };
            btnRemove.SetValue(Grid.RowProperty, row);
            btnRemove.SetValue(Grid.ColumnProperty, 3);
            btnRemove.Click += btnRemove_Click;

            gridEvents.Children.Remove(lastElem);

            gridEvents.Children.Add(blocc);
            gridEvents.Children.Add(timeBlocc);
            gridEvents.Children.Add(btnModify);
            gridEvents.Children.Add(btnRemove);

            gridEvents.Children.Add(lastElem);

            lastElem.SetValue(Grid.RowProperty, row + 1);


            int pos = time.StartTime.Hours * 2 + time.StartTime.Minutes / 30;

            for(int i = 0; i < 7; i++)
            {
                if(time.days[i] || true)
                {
                    TextBlock txtBlk = new TextBlock()
                    {
                        Text = e.Name
                    };
                    txtBlk.SetValue(Grid.RowProperty, pos);
                    txtBlk.SetValue(Grid.ColumnProperty, i + 1);
                    txtBlk.VerticalAlignment = VerticalAlignment.Center;
                    txtBlk.HorizontalAlignment = HorizontalAlignment.Center;

                    grdCalendar.Children.Add(txtBlk);

                    for(int j = pos; j <= time.EndTime.Hours * 2 + time.EndTime.Minutes / 30; j++)
                    {
                        rects[i, j].Fill = new SolidColorBrush(Color.FromRgb(28, 255, 28));
                    }
                }
            }

        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Modify");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            EventWindow.PollUser();

            Event ev = new Event("test", "event", DateTime.Today, new CustomTime(
                new Time(10, 10), new Time(22, 0), new bool[7], true));

            addEvent(ev);
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void gridTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnResize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSwap_Click(object sender, RoutedEventArgs e)
        {
            if (viewOne.Visibility == Visibility.Visible)
            {
                viewOne.Visibility = Visibility.Hidden;
                viewTwo.Visibility = Visibility.Visible;
            }
            else
            {
                viewOne.Visibility = Visibility.Visible;
                viewTwo.Visibility = Visibility.Hidden;
            }
        }
    }
}
