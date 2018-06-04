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
    /// Логика взаимодействия для Findworker.xaml
    /// </summary>
    public partial class Findworker : Window
    {
        private Table<applicant> app;
        private Table<vacancies> vacs;
        private Table<R> RRTAB;
        private Table<R1> rtable;
        private Table<R2> rAO;
        private DataContext db;
        private final AddNew;
        private Table<final> finalTable;
        public Findworker()
        {
            InitializeComponent();
            CurrentUser.hand = GetWindow(this);
            CurrentUser.winid = 3;
            Current.Text = CurrentUser.name;
            Current.Width = Current.Text.Length * 8 + 2;
            WindowStyle = System.Windows.WindowStyle.None;
            GRIDREAL.AutoGenerateColumns = false;
            Connect();
            Update();
            AllowsTransparency = true;
            DoubleAnimation OpacityAnimation = new DoubleAnimation();
            OpacityAnimation.From = 0.4;
            OpacityAnimation.To = 1;
            OpacityAnimation.Duration = TimeSpan.FromSeconds(1);
            this.BeginAnimation(Window.OpacityProperty, OpacityAnimation);

            //WindowStyle = System.Windows.WindowStyle.SingleBorderWindow;
            MouseDown += Window_MouseDown;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            a();
        }
        private void Connect()
        {

            try
            {
                db = new DataContext(entities.connectionString);
                rtable = db.GetTable<R1>();
                app = db.GetTable<applicant>();
                vacs = db.GetTable<vacancies>();
                rAO = db.GetTable<R2>();
                RRTAB = db.GetTable<R>();
                finalTable = db.GetTable<final>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Не удалось подключиться к базе данных!");
            }
            Reply.IsChecked = true;
        }
        private void Update()
        {
            
            try
            {
                if (TBSalary.Text == "")
                {
                    TBSalary.Text = "50000";
                }
                if (CurrentUser.type != 2)
                {
                    Reply.Visibility = Visibility.Hidden;
                    Total.Visibility = Visibility.Hidden;
                    foreach (var a in app)
                    {
                        if (!this.CBApplicant.Items.Contains(a.position))
                            this.CBApplicant.Items.Add(a.position);
                    }
                    if ((TBSalary.Text != "") && (CBApplicant.Text == ""))
                    {
                        var result =
                            from a in app
                            where a.salary <= int.Parse(TBSalary.Text) && a.hired == false
                            select new { a.idapplicant, a.FIO, a.position, a.salary, a.hired };
                        GRIDREAL.ItemsSource = result;
                    }
                    else
                    {
                        if ((CBApplicant.Text != ""))
                        {
                            //Нужна маска ввода для textbox
                            var result =
                            from a in app

                            where (a.position.Substring(0, CBApplicant.Text.Length) == CBApplicant.Text || a.FIO.Substring(0, CBApplicant.Text.Length) == CBApplicant.Text) && a.salary <= int.Parse(TBSalary.Text) && a.hired == false
                            select new { a.idapplicant, a.FIO, a.position, a.salary, a.hired };
                            GRIDREAL.ItemsSource = result;
                        }
                        else
                        {
                            var result =
                            from a in app
                            select new { a.idapplicant, a.FIO, a.position, a.salary,a.hired };
                            GRIDREAL.ItemsSource = result;
                        }
                    }
                }
                else
                {
                    Reply.Visibility = Visibility.Visible;
                    Total.Visibility = Visibility.Visible;
                    if (Reply.IsChecked == true)
                    {
                        var result =
                          from rr in rAO
                          where rr.applicant.salary <= int.Parse(TBSalary.Text) && rr.org.orgname == CurrentUser.name //&&rr.applicant.hired==false
                          select new { rr.applicant.idapplicant, rr.applicant.FIO, rr.applicant.position, rr.applicant.salary, rr.applicant.hired };
                   
                    if ((TBSalary.Text != "") && (CBApplicant.Text == ""))
                        {
                            
                            GRIDREAL.ItemsSource = result;
                        }
                        else
                        {
                            if ((CBApplicant.Text != ""))
                            {
                                //Нужна маска ввода для textbox
                                result =
                                from rr in result
                                where (rr.position.Substring(0, CBApplicant.Text.Length) == CBApplicant.Text || rr.FIO.Substring(0, CBApplicant.Text.Length) == CBApplicant.Text) && rr.salary <= int.Parse(TBSalary.Text)
                                select new { rr.idapplicant, rr.FIO, rr.position, rr.salary,rr.hired};
                                GRIDREAL.ItemsSource = result;
                            }
                            else
                            {
                                GRIDREAL.ItemsSource = result;
                            }
                        }
                    foreach (var rr in result)
                    {
                        if (!this.CBApplicant.Items.Contains(rr.position))
                            this.CBApplicant.Items.Add(rr.position);
                    }
                    }
                    else
                    {
                        var result =
                          from rr in rAO
                          where rr.applicant.salary <= int.Parse(TBSalary.Text) //&&rr.applicant.hired==false
                          select new { rr.applicant.idapplicant, rr.applicant.FIO, rr.applicant.position, rr.applicant.salary, rr.applicant.hired };
                        if ((TBSalary.Text != "") && (CBApplicant.Text == ""))
                        {

                            GRIDREAL.ItemsSource = result;
                        }
                        else
                        {
                            if ((CBApplicant.Text != ""))
                            {
                                //Нужна маска ввода для textbox
                                result =
                                from rr in result
                                where (rr.position.Substring(0, CBApplicant.Text.Length) == CBApplicant.Text || rr.FIO.Substring(0, CBApplicant.Text.Length) == CBApplicant.Text) && rr.salary <= int.Parse(TBSalary.Text)
                                select new { rr.idapplicant, rr.FIO, rr.position, rr.salary, rr.hired };
                                GRIDREAL.ItemsSource = result;
                            }
                            else
                            {
                                GRIDREAL.ItemsSource = result;
                            }
                        }
                        foreach (var rr in result)
                        {
                            if (!this.CBApplicant.Items.Contains(rr.position))
                                this.CBApplicant.Items.Add(rr.position);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("update fail");
                TBSalary.Text = "50000";
            }

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Left = (this.Left) + (this.Width - a.Width) / 2;
            a.Top = (this.Top) + (this.Height - a.Height) / 2;
            a.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.type == 2)
            {
                
                int id;
                //appid
                id = int.Parse(this.GRIDREAL.SelectedItem.ToString().Split(' ', ',', '=')[4]);
                var getuser =
                    from a in app
                    where a.idapplicant == id
                    select a;
                if (getuser.First().hired == false)
                {
                    var DelFromR =
                        from rr in RRTAB
                        where rr.Idapplicant == id
                        select rr;
                    var DelFromR2 =
                        from rr in rAO
                        where rr.Idapplicant == id
                        select rr;
                    int vacid;
                    //get idvac from R
                    foreach (var r in DelFromR)
                    {
                        try
                        {
                            r.vacancies.dateclose = DateTime.Now;
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.Message);
                        }
                    }

                    AddNew = new final();
                    AddNew.dateclose = DateTime.Now;
                    AddNew.dateopen = (from v in RRTAB where v.applicant.idapplicant == id select v.vacancies.dateopen).First();

                    try { AddNew.id = (from i in finalTable select i.id).Max() + 1; }
                    catch (Exception) { AddNew.id = 1; }
                    string ab = (from a in getuser select a.FIO).First();
                    AddNew.FIO = ab;
                    if (AddNew.id == null) AddNew.id = 1;
                    if (AddNew.FIO.Length >= 20) AddNew.FIO = AddNew.FIO.Substring(0, 19);
                    AddNew.Info = (from a in getuser select a.Info).First();
                    if (AddNew.Info == "") AddNew.Info = "Информация не предоставлена";
                    if (AddNew.Info.Length >= 100) AddNew.Info = AddNew.Info.Substring(0, 99);
                    AddNew.orgname = CurrentUser.name;
                    AddNew.position = (from a in getuser select a.position).First();
                    if (AddNew.position.Length >= 30) AddNew.position.Substring(0, 29);
                    AddNew.salary = (from a in getuser select a.salary).Max();
                    AddNew.accepted = "Не подтверждено";
                    MessageBox.Show("Вакансия №" + AddNew.id + "\n" + AddNew.dateopen.ToString() + "\n" + AddNew.dateclose.ToString() + "\n" + "\nИнформация о кандидате:\n" + AddNew.Info + "\n\n" + AddNew.orgname + "\nПозиция - " + AddNew.position + "\nОклад - " + AddNew.salary + " рублей\n");
                    foreach (var rr in DelFromR)
                    {
                        RRTAB.DeleteOnSubmit(rr);
                    }
                    /*foreach (var rr in DelFromR2)
                    {
                        rAO.DeleteOnSubmit(rr);
                    }*/
                    foreach (var h in getuser)
                    {
                        h.hired = true;
                    }
                    finalTable.InsertOnSubmit(AddNew);
                    
                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("Кандидат выбран. Он будет уведомлен специальным сообщением.");
                        Update();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else MessageBox.Show("Кандидат уже приглашен!");
                
            }
            else MessageBox.Show("Только компании могут приглашать кандидатов.");
        }

        private void GRIDREAL_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TBSalary_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void CBApplicant_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void CBApplicant_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
       
        private void abc(object sender, EventArgs e)
        {
            Current.Text = CurrentUser.name;
            Current.Width = Current.Text.Length * 8 + 5;
            Update();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
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
        private void a()
        {
            //remarks
            //Left button - add vacancy and filling "R"-table
            //Right button -"Hired"
            if (CurrentUser.type == 2)
            {
                AddJob a = new AddJob();
                //Позиция на экране
                a.Left = (this.Left) + (this.Width - a.Width) / 2;
                a.Top = (this.Top) + (this.Height - a.Height) / 2;
                a.NewR1 = new R1();
                a.ID.Text = ((from v in vacs select v.Idvacant).Max() + 1).ToString();
                if (a.ID.Text == "") a.ID.Text = "1";
                a.ORG.Text = CurrentUser.name;
                a.SALARY.Text = this.TBSalary.Text;
                a.Show();
            }
            else MessageBox.Show("Только компании могут публиковать вакансии.");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void Total_Checked(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
