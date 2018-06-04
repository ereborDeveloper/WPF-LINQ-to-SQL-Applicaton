using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace kurscachWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CurrentUser.hand = GetWindow(this);
            CurrentUser.winid = 1;
            Current.Text = CurrentUser.name;
            Current.Width = Current.Text.Length * 8 + 5;
            // MessageBox.Show(Current.Width.ToString());
            //Eugene Buyvolov AMaCS-4
            //Screen Position
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
            //Undecorated window
            WindowStyle =System.Windows.WindowStyle.None;
            AllowsTransparency = true;
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = 0.2;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(1);
            this.BeginAnimation(Window.OpacityProperty,OpacityAnimation);
            //Make it moveable
            MouseDown += Window_MouseDown;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Open Find Job
            
            Findjob a = new Findjob();
            a.Left = (this.Left) + (this.Width - a.Width) / 2;
            a.Top = (this.Top) + (this.Height - a.Height) / 2;
            a.Show();
            this.Close();
            //Screen Position

            //this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Findworker a = new Findworker();
            //Позиция на экране
            a.Left = (this.Left) + (this.Width - a.Width) / 2;
            a.Top = (this.Top) + (this.Height - a.Height) / 2;
            a.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            if (CurrentUser.flag)
            {
                LogIn a = new LogIn();
                a.Left = (this.Left) + (this.Width - a.Width) / 2;
                a.Top = (this.Top) + (this.Height - a.Height) / 2;
                a.Show();
                a.ch += abc;
            }
            else
            {
                if (MessageBox.Show("Выйти?", "Log out", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    CurrentUser.name = "Гость";
                    CurrentUser.flag = true;
                    CurrentUser.type = 0;
                    Current.Text = CurrentUser.name;
                    Current.Width = Current.Text.Length * 8 + 5;
                }
            } 
        }
        private void abc(object sender, EventArgs e)
        {
            Current.Text = CurrentUser.name;
            Current.Width = Current.Text.Length * 8+5;
        }

        private void Current_TextChanged(object sender, TextChangedEventArgs e)
        {
      
        }
    }
}
