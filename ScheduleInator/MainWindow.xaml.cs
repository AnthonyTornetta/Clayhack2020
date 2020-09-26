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
        public MainWindow()
        {
            InitializeComponent();


        }

        public void addEvent(Event e)
        {
            RowDefinition rowObj = new RowDefinition
            {
                Height = GridLength.Auto
            };

            gridEvents.RowDefinitions.Add(rowObj);


            /*
<TextBlock Text="Cool Event Name" FontSize="25" VerticalAlignment="Center" Grid.Row="0" Grid.Column="0"></TextBlock>
<TextBlock Text="12:00 AM" FontSize="25" VerticalAlignment="Center" Grid.Row="0" Grid.Column="1"></TextBlock>
<Button Style="{StaticResource btn-slick}" x:Name="btnModify" Content="*" Click="btnModify_Click" Grid.Row="0" Grid.Column="2"></Button>
<Button Style="{StaticResource btn-slick}" x:Name="btnAdd" Content="+" Click="btnAdd_Click" Grid.Row="0" Grid.Column="3"></Button>
<Button Style="{StaticResource btn-slick}" x:Name="btnRemove" Content="-" Click="btnRemove_Click" Grid.Row="0" Grid.Column="4"></Button>
             */

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
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Modify");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
