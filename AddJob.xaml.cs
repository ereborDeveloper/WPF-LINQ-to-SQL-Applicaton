using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Data.Linq;

namespace kurscachWPF
{
    /// <summary>
    /// Логика взаимодействия для AddWork.xaml
    /// </summary>
    public partial class AddJob : Window
    {
        public R1 NewR1;
        private vacancies AddNew;
        private Table<org> ForQueue;
        private DataContext db;
        private Table<vacancies> vac;
        private Table<R1> rr;
        public AddJob()
        {
            InitializeComponent();
            WindowStyle = System.Windows.WindowStyle.None;

            AllowsTransparency = true;
           
            //WindowStyle = System.Windows.WindowStyle.SingleBorderWindow;
            MouseDown += Window_MouseDown;
            db = new DataContext(entities.connectionString);
            vac = db.GetTable<vacancies>();
            rr = db.GetTable<R1>();
            ForQueue = db.GetTable<org>();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (this.POSITION.Text != "")
            {
                try
                {

                    AddNew = new vacancies();
                    //fill vacant
                    AddNew.Idvacant = int.Parse(this.ID.Text);
                    AddNew.position = this.POSITION.Text+" ";
                    AddNew.salary = int.Parse(this.SALARY.Text);
                    AddNew.dateopen = DateTime.Now;
                    //fill R
                    NewR1.Idvacant = AddNew.Idvacant;
                    NewR1.Idorg = (from o in ForQueue where o.orgname == CurrentUser.name select o.Idorg).Max();
                    rr.InsertOnSubmit(NewR1);
                    vac.InsertOnSubmit(AddNew);
                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("Вакансия успешно добавлена!");
                        this.Close();
                    }
                    catch (Exception exx)
                    {
                        MessageBox.Show(exx.Message);
                        db.SubmitChanges();
                        this.SALARY.Text = "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Введите название вакансии!");
        }
    }
}
