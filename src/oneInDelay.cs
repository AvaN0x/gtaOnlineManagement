using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace gtaOnlineManagement
{
    class oneInDelay
    {
        // plus adapté aux supplies qu'au timer 24h pour le moment, faire une version ou il faut avoir l'app lancée, faire un bouton qui permet de reset les lignes
        public String name { get; set; }
        public DateTime duration { get; set; }
        public StackPanel panel { get; set; }

        public oneInDelay(String name, DateTime duration)
        {
            this.name = name.Trim();
            this.duration = duration;
            initStackPanel();
        }

        public void initStackPanel()
        {
            panel = new StackPanel
            {
                Orientation = Orientation.Horizontal
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
                Text = duration.ToString(),
                Style = (Style) Application.Current.FindResource("TextBlockStyle")
            });


        }

        public void Push()
        {
            //((TextBlock) panel.Children[2]).Text = "ui";
            setWait();
        }

        public void setWait()
        {
            ((Button)panel.Children[1]).IsEnabled = false;
            panel.Background = (Brush)(new System.Windows.Media.BrushConverter()).ConvertFromString("#26292f");
        }

        public void setNeedPush()
        {
            ((Button)panel.Children[1]).IsEnabled = true;
            panel.Background = (Brush)(new System.Windows.Media.BrushConverter()).ConvertFromString("#00a6ff");
        }
    }
}
