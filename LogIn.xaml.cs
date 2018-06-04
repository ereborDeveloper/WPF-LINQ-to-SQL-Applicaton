using System;
using System.Windows;

namespace kurscachWPF
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
           
                InitializeComponent();
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler ch;
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CurrentUser.setLabel(this.Login.Text, this.Password.Password);
            ch?.Invoke(this, new EventArgs());
            if (CurrentUser.flag == false) this.Close();
        }

        private void REG_Click(object sender, RoutedEventArgs e)
        {
            registration a = new registration();
            a.Left = (this.Left) + (this.Width - a.Width) / 2;
            a.Top = (this.Top) + (this.Height - a.Height) / 2;
            a.Show();
            a.ch += abc;
            this.Close();
        }
        public void abc(object sender, EventArgs e)
        {
            GetWindow(CurrentUser.hand).Close();
            if(CurrentUser.winid ==1)
            {
                MainWindow a = new MainWindow();
                a.Left = (this.Left) + (this.Width - a.Width) / 2;
                a.Top = (this.Top) + (this.Height - a.Height) / 2;
                a.Show();
            }
            if (CurrentUser.winid == 2)
            {
                Findjob a = new Findjob();
                a.Left = (this.Left) + (this.Width - a.Width) / 2;
                a.Top = (this.Top) + (this.Height - a.Height) / 2;
                a.Show();
            }
            if (CurrentUser.winid == 3)
            {
                Findworker a = new Findworker();
                a.Left = (this.Left) + (this.Width - a.Width) / 2;
                a.Top = (this.Top) + (this.Height - a.Height) / 2;
                a.Show();
            }
        }
    }
}
