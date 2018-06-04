using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Data.Linq;

namespace kurscachWPF
{
    /// <summary>
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Window
    {
        private applicant AddNew;
        public R NewR;
        public R2 NewR2;
        private DataContext db;
        private Table<applicant> ap;
        private Table<R> rr;
        private Table<R2> rr2;
        public AddWorker()
        {
            InitializeComponent();
            WindowStyle = System.Windows.WindowStyle.None;
            AllowsTransparency = true;
            MouseDown += Window_MouseDown;
            db = new DataContext(entities.connectionString);
            ap = db.GetTable<applicant>();
            rr = db.GetTable<R>();
            rr2= db.GetTable<R2>();
            int id;
            try {  id= ap.OrderByDescending(ap => ap.idapplicant).FirstOrDefault().idapplicant.Value + 1; }
            catch (Exception) { id = 1; }
            AID.Text = id.ToString();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //if (CurrentUser.type!=0)
            {
                try
                {
                    AddNew = new applicant();
                    //fill applicant
                    AddNew.idapplicant = int.Parse(this.AID.Text);
                    if (this.AFIO.Text.Length > 20)
                        AddNew.FIO = this.AFIO.Text.Substring(0, 19);
                    else AddNew.FIO = this.AFIO.Text;
                    AddNew.position = this.APOSITION.Text;
                    AddNew.salary = int.Parse(this.ASALARY.Text);
                    AddNew.hired = false;
                    if (this.AINFO.Text.Length > 100)
                        AddNew.Info = this.AINFO.Text.Substring(0, 99);
                    else AddNew.Info = this.AINFO.Text;
                    //fill R
                    NewR.Idapplicant = AddNew.idapplicant;
                    NewR2.Idapplicant= AddNew.idapplicant;
                    rr2.InsertOnSubmit(NewR2);
                    rr.InsertOnSubmit(NewR);
                    ap.InsertOnSubmit(AddNew);
                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("Резюме успешно добавлено!");
                        this.Close();
                    }
                    catch (Exception exx)
                    {
                        MessageBox.Show(exx.Message);
                        db.SubmitChanges();
                        this.ASALARY.Text = "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //else MessageBox.Show("Гости не могут добавлять резюме. Пожалуйста, залогиньтесь.");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }
}
