using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace gtaOnlineManagement
{
    class oneInDelay
    {
        //TODO plus adapté aux supplies qu'au timer 24h pour le moment, faire une version ou il faut avoir l'app lancée, faire un bouton qui permet de reset les lignes
        public String name { get; set; }
        public TimeSpan duration { get; set; }
        public DateTime lastPush { get; set; }
        public StackPanel panel { get; set; }
        public DispatcherTimer timer { get; set; }

        public oneInDelay(String name, TimeSpan duration)
        {
            this.name = name.Trim();
            this.duration = duration;
            initStackPanel();
        }

        public void initStackPanel()
        {
            panel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Background = (Brush)(new System.Windows.Media.BrushConverter()).ConvertFromString("#00a6ff")
            };


            panel.Children.Add(new Label
            {
                Content = name,
                Style = (Style) Application.Current.FindResource("LabelStyle")
            });

            var button = new Button
            {
                Content = new Image
                {
                    Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("icons/spin.png", UriKind.Relative)),
                    Height = 16,
                    Width = 16
                },
                Style = (Style) Application.Current.FindResource("CasinoButtonStyle"),
                IsEnabled = true
            };
            button.Click += (sender, e) => 
            {
                Push();
            };

            panel.Children.Add(button);
            panel.Children.Add(new TextBlock
            {
                Name = "timer",
                Text = "It's time !",
                Style = (Style) Application.Current.FindResource("TextBlockStyle")
            });


        }

        public void Push()
        {
            setWait();
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 30);
            timer.Start();
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            ((Label)panel.Children[0]).Content += "!";
            var dateEnd = lastPush.Add(duration);
            if (DateTime.Compare(DateTime.Now,dateEnd) > 0)
            {
                setNeedPush();
                timer.Stop();
            }
        }

        public void setWait()
        {
            lastPush = DateTime.Now;
            ((TextBlock)panel.Children[2]).Text = "Next time : " + (lastPush + duration).ToString("H:mm");
            ((Button)panel.Children[1]).IsEnabled = false;
            panel.Background = (Brush)(new System.Windows.Media.BrushConverter()).ConvertFromString("#26292f");
        }

        public void setNeedPush()
        {
            ((TextBlock)panel.Children[2]).Text = "It's time !";
            ((Button)panel.Children[1]).IsEnabled = true;
            panel.Background = (Brush)(new System.Windows.Media.BrushConverter()).ConvertFromString("#00a6ff");
        }
    }
}
