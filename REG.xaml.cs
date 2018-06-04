using System;
using System.Linq;
using System.Windows;
using System.Data;
using System.Data.Linq;

namespace kurscachWPF
{
    /// <summary>
    /// Логика взаимодействия для REG.xaml
    /// </summary>
    public partial class registration : Window
    {
        
        public registration()
        {
            InitializeComponent();
            Connect();
        }
        private REG reg;
        private Table<REG> Treg;
        private Table<org> org;
        private DataContext db;
        private org NewOrg;
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            LogIn a = new LogIn();
            a.Left = (this.Left) + (this.Width - a.Width) / 2;
            a.Top = (this.Top) + (this.Height - a.Height) / 2;
            a.Show();
        }
        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler ch;
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.type != 0)
            {
                if (Login.Text != "")
            {
                if (Password.Password != "" && Password.Password.Length >= 5)
                {
                    CurrentUser.name = Login.Text;
                    CurrentUser.password = Password.Password;
                    reg = new REG();
                    
                        if (CurrentUser.type == 2)
                        {
                            var r = from o in org where o.orgname == Login.Text select o.Idorg;
                            if (r.Max() == null)
                            {
                                reg.Login = Login.Text;
                                reg.Password = Password.Password;
                                Treg.InsertOnSubmit(reg);
                                NewOrg = new org();
                                NewOrg.Idorg = (from o in org select o.Idorg).Max()+1;
                                if (NewOrg.Idorg == null) NewOrg.Idorg = 1;
                                NewOrg.orgname = Login.Text;
                                org.InsertOnSubmit(NewOrg);
                                try
                                {
                                    db.SubmitChanges();
                                    MessageBox.Show("Компания зарегистрирована!\nВаш логин: " + reg.Login + "\nВаш пароль: " + reg.Password);
                                    CurrentUser.flag = false;
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Ошибка регистрации!");
                                }
                                finally
                                {
                                    ch?.Invoke(this, new EventArgs());
                                    if (CurrentUser.flag == false) this.Close();
                                    this.Close();
                                }
                            }
                            else MessageBox.Show("Компания уже зарегистрирована.");
                        }
                        if (CurrentUser.type == 1)
                        {
                            var r = from a in Treg where a.Login == Login.Text select a.Login;
                            if (r.Max() == null)
                            {
                                reg.Login = Login.Text;
                                reg.Password = Password.Password;
                                Treg.InsertOnSubmit(reg);
                                try
                                {
                                    db.SubmitChanges();
                                    MessageBox.Show("Вы успешно зарегистрированы!\nВаш логин: " + reg.Login + "\nВаш пароль: " + reg.Password);
                                    CurrentUser.flag = false;
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Ошибка регистрации!");
                                }
                                finally
                                {
                                    ch?.Invoke(this, new EventArgs());
                                    if (CurrentUser.flag == false) this.Close();
                                    this.Close();
                                }
                            }
                            else MessageBox.Show("Пользователь с таким именем уже есть.");
                        }
 
                    
                }
                else MessageBox.Show("Введите корректный пароль (не менее 5 символов)");
            }
            else MessageBox.Show("Введите логин");
            }
            else MessageBox.Show("Кто же вы?");
        }
        private void Connect()
        {
            try
            {
                db = new DataContext(entities.connectionString);
                Treg = db.GetTable<REG>();
                org = db.GetTable<org>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Не удалось подключиться к базе данных!");
            }
        }
        private void CB1_Checked(object sender, RoutedEventArgs e)
        {
            if (CB2.IsChecked == true)
                CB2.IsChecked = false;
            CurrentUser.type = 2;
        }

        private void CB2_Checked(object sender, RoutedEventArgs e)
        {
            if (CB1.IsChecked == true)
                CB1.IsChecked = false;
            CurrentUser.type = 1;
        }
    }
}
