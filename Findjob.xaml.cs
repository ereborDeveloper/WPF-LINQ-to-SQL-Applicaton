using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Data;
using System.Data.Linq;

namespace kurscachWPF
{
    /// <summary>
    /// Логика взаимодействия для Findjob.xaml
    /// </summary>
    public partial class Findjob : Window
    {
        public Findjob()
        {
            InitializeComponent();
            CurrentUser.hand = GetWindow(this);
            CurrentUser.winid = 2;
            Current.Text = CurrentUser.name;
            Current.Width = Current.Text.Length * 8 + 5;
            GRIDREAL.AutoGenerateColumns = false;
            Connect();
            Update();
            WindowStyle = System.Windows.WindowStyle.None;
            AllowsTransparency = true;
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = 0.4;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(1);
            this.BeginAnimation(Window.OpacityProperty, OpacityAnimation);
            MouseDown += Window_MouseDown;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Left = (this.Left) + (this.Width - a.Width) / 2;
            a.Top = (this.Top) + (this.Height - a.Height) / 2;
            a.Show();
            this.Close();
        }
        private DataContext db;
        private Table<vacancies> vacs;
        private Table<org> orgg;
        private Table<R1> rtable;
        private Table<R2> rtable2;
        //R1 - vacant/org
        //R - vacant/applicant
        //R2 - applicant/org
        bool clear;
        
        private void Connect()
        {
            try
            {
                db = new DataContext(entities.connectionString);
                vacs = db.GetTable<vacancies>();
                orgg = db.GetTable<org>();
                rtable = db.GetTable<R1>();
                rtable2 = db.GetTable<R2>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Не удалось подключиться к базе данных!");
            }
        }
        public void Update()
        {
            try
            {
                if (TBSalary.Text == "")
                    TBSalary.Text = "0";
                if ((TBSalary.Text != "") && (CBVacant.Text == ""))
                {
                    var result =
                        
                        from r in rtable
                        where r.vacancies.salary >= int.Parse(TBSalary.Text) && r.vacancies.dateclose == null
                        select new { r.vacancies.Idvacant, r.vacancies.position, r.org.orgname, r.vacancies.salary,r.vacancies.dateopen };
                    GRIDREAL.ItemsSource = result; 
                }
                else
                {
                    if ((CBVacant.Text != ""))
                    {
                        var result =
                        from r in rtable
                        where (((r.vacancies.position.Substring(0,CBVacant.Text.Length)) == CBVacant.Text) || (r.org.orgname.Substring(0, CBVacant.Text.Length)) == CBVacant.Text) && (r.vacancies.salary >= int.Parse(TBSalary.Text)) && r.vacancies.dateclose == null
                        select new { r.vacancies.Idvacant, r.vacancies.position, r.org.orgname, r.vacancies.salary,r.vacancies.dateopen };
                        GRIDREAL.ItemsSource = result;
                    }
                    else
                    {
                        var result =
                        from r in rtable where r.vacancies.dateclose ==null
                        select new { r.vacancies.Idvacant, r.vacancies.position, r.org.orgname, r.vacancies.salary,r.vacancies.dateopen};
                        GRIDREAL.ItemsSource = result;
                    }
                }
                foreach (var vac in vacs)
                {
                   if (!CBVacant.Items.Contains(vac.position))
                       CBVacant.Items.Add(vac.position);
                }
                //GRIDREAL.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                TBSalary.Text = "0";
            }
        }
        
    
    private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = 0;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(1);
            this.GRID.BeginAnimation(UIElement.OpacityProperty, OpacityAnimation);
            this.GRIDREAL.BeginAnimation(UIElement.OpacityProperty, OpacityAnimation);
            Update();
        }
        
        private void SendWorker_Click(object sender, RoutedEventArgs e)
        {
            clear = true;
            add_show(1);
        }

        private void GRIDREAL_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CBVacant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CBVacant_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void TBSalary_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void YEAH_Click(object sender, RoutedEventArgs e)
        {
            clear = false;
            add_show(2);

        }
        private void add_show(byte key)
        {
            if (CurrentUser.type != 2)
            {
                AddWorker a = new AddWorker();
                foreach (var vac in vacs)
                {
                    if (!a.APOSITION.Items.Contains(vac.position))
                        a.APOSITION.Items.Add(vac.position);
                }
                //Позиция на экране
                a.Left = (this.Left) + (this.Width - a.Width) / 2;
                a.Top = (this.Top) + (this.Height - a.Height) / 2;
                string ar;
                try
                {
                    a.NewR = new R();
                    a.NewR2 = new R2();
                    ar = this.GRIDREAL.SelectedItem.ToString();
                    a.NewR.Idvacant = int.Parse(ar.Split('=', ' ', ',')[4]);
                    string comp = ar.Split('=', ',')[5];
                    comp = comp.Substring(1, comp.Length-1);
                    a.NewR2.Idorg = (from orgid in orgg where orgid.orgname == comp select orgid.Idorg).Max();
                    a.AFIO.Text = CurrentUser.name;
                    if (!clear)
                    {
                        a.APOSITION.Text= ar.Split('=', ' ')[8];
                        a.ASALARY.Text = this.TBSalary.Text;
                    }
                    a.Show();
                }
                catch (Exception e)
                {
                    if(key==2) MessageBox.Show(e.Message);
                    a.AFIO.Text = CurrentUser.name;
                    a.Show();
                    //
                }
            }
            else
            {
                MessageBox.Show("Комании не могут добавлять резюме. Пожалуйста, перелогиньтесь");
            }
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
        public void abc(object sender, EventArgs e)
        {
            Current.Text = CurrentUser.name;
            Current.Width = Current.Text.Length * 8 + 5;
        }
    }
}
