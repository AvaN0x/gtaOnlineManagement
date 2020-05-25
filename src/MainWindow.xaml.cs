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

namespace gtaOnlineManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var ui = new Label();

            //ui.Content = "ui";
            //ui.Background = new SolidColorBrush(Colors.Orange);

            //ui.Foreground = new SolidColorBrush(Colors.Black);

            //Casino.Children.Add(ui);


            var luckyWheel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            //var label = new Label
            //{
            //    Content = "Casino Lucky Wheel",
            //    Style = (Style) Application.Current.FindResource("LabelStyle")
            //};

            //var button = new Button
            //{
            //    Style = (Style) Application.Current.FindResource("CasinoButtonStyle"),
            //    IsEnabled = false
            //};

            luckyWheel.Children.Add(new Label
            {
                Content = "Casino Lucky Wheel",
                Style = (Style) Application.Current.FindResource("LabelStyle")
            });

            var button = new Button
            {
                Content = new Image
                {
                    Source = new BitmapImage(new Uri("icons/spin.png", UriKind.Relative)),
                    Height = 16,
                    Width = 16
                },
                Style = (Style) Application.Current.FindResource("CasinoButtonStyle"),
                IsEnabled = false,
            };
            button.Click += new RoutedEventHandler(this.btn_close_Click);

            luckyWheel.Children.Add(button);
            luckyWheel.Children.Add(new TextBlock
            {
                Text = "hh/mm",
                Style = (Style) Application.Current.FindResource("TextBlockStyle")
            });

            Casino.Children.Add(luckyWheel);


            //<StackPanel Orientation = "Horizontal" Background = "#00a6ff" >
            //    <Label Content = "Casino Lucky Wheel" Style = "{StaticResource LabelStyle}" ></ Label >
            //     <Button Style = "{StaticResource CasinoButtonStyle}"
            //           IsEnabled = "True" >
            //          <Viewbox Width = "16" Height = "16" >
            //             <Image Source = "icons/spin.png" />
            //          </Viewbox >
            //     </Button >
            //     <TextBlock Text = "hh/mm" Style = "{StaticResource TextBlockStyle}" />
            //</StackPanel>
        }

        private void Drag_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void OnTop_Checked(object sender, RoutedEventArgs e)
        {
            Topmost = true;
        }

        private void OnTop_Unchecked(object sender, RoutedEventArgs e)
        {
            Topmost = false;
        }
    }
}
