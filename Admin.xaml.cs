using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using System.Data.Linq;

namespace kurscachWPF
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private DataContext db;
        private Table<final> final;
        private Table<org> org;
        private Table<vacancies> vacs;
        private Table<applicant> app;
        public Admin()
        {
            InitializeComponent();
            WindowStyle = System.Windows.WindowStyle.None;
            AllowsTransparency = true;
            MouseDown += Window_MouseDown;
            Connect();
            UpdateFin();
            UpdateOrg();
            UpdateVacs();
            UpdateApp();

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        private void UpdateApp()
        {
            try
            {
                
                var res =
                from a in app where a.hired==false
                select new {a.FIO,a.position,a.hired };
                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add(
                    new DataColumn()
                    {
                        DataType = System.Type.GetType("System.String"),
                        ColumnName = "ФИО"
                    }
                );
                MyDataTable.Columns.Add(
                    new DataColumn()
                    {
                        DataType = System.Type.GetType("System.String"),
                        ColumnName = "Позиция"
                    }
                );
                

                foreach (var element in res)
                {
                    var row = MyDataTable.NewRow();
                    row["ФИО"] = element.FIO;
                    row["Позиция"] = element.position;
                    MyDataTable.Rows.Add(row);
                }
                APP.ItemsSource = MyDataTable.DefaultView;
            }
            catch (Exception ad)
            { MessageBox.Show(ad.Message); }
        }

        private void UpdateVacs()
        {
            try
            {
                var res =
                from v in vacs
                select new {v.position, v.salary};
                this.VACS.ItemsSource = res;
                DataTable MyDataTable1 = new DataTable();
                MyDataTable1.Columns.Add(
                    new DataColumn()
                    {
                        DataType = System.Type.GetType("System.String"),
                        ColumnName = "Позиция"
                    }
                );
                MyDataTable1.Columns.Add(
                    new DataColumn()
                    {
                        DataType = System.Type.GetType("System.String"),
                        ColumnName = "Оклад"
                    }
                );
                foreach (var element in res)
                {
                    var row = MyDataTable1.NewRow();
                    row["Позиция"] = element.position;
                    row["Оклад"] = element.salary;
                    MyDataTable1.Rows.Add(row);
                }
                VACS.ItemsSource = MyDataTable1.DefaultView;
            }
            catch (Exception ad)
            { MessageBox.Show(ad.Message); }
        }

        private void UpdateOrg()
        {
            try
            {
                
                var res =
                from o in org
                select o.orgname;
                //a = res.CopyToDataTable();
                //this.ORG.Columns[0] = a;
                DataTable MyDataTable = new DataTable();
                MyDataTable.Columns.Add(
                    new DataColumn()
                    {
                        DataType = System.Type.GetType("System.String"),ColumnName = "Компания" }
                );

                foreach (var element in res)
                {
                    var row = MyDataTable.NewRow();
                    row["Компания"] = element;
                    MyDataTable.Rows.Add(row);
                }
                ORG.ItemsSource = MyDataTable.DefaultView;
                //
            }
            catch (Exception ad)
            { MessageBox.Show(ad.Message); }
        }

        private void Connect()
        {

            try
            {
                db = new DataContext(entities.connectionString);
                final = db.GetTable<final>();
                org = db.GetTable<org>();
                vacs = db.GetTable<vacancies>();
                app = db.GetTable<applicant>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Не удалось подключиться к базе данных!");
            }
        }
        private void UpdateFin()
        {
            try
            {
                FINAL.AutoGenerateColumns = false;
                var res =
                from f in final
                select f;
                this.FINAL.ItemsSource = res;
            }
            catch (Exception ad)
            { MessageBox.Show(ad.Message); }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ARe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ADe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DELETEALL_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Удалить все", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            {
                try
                {
                    db.ExecuteCommand("DELETE FROM applicant");
                    db.ExecuteCommand("DELETE FROM vacancies");
                    db.ExecuteCommand("DELETE FROM R");
                    db.ExecuteCommand("DELETE FROM R1");
                    db.ExecuteCommand("DELETE FROM R2");
                    db.ExecuteCommand("DELETE FROM final");
                    db.ExecuteCommand("DELETE FROM org");
                    db.ExecuteCommand("DELETE FROM REG");
                    UpdateFin();
                    UpdateOrg();
                    UpdateVacs();
                    UpdateApp();
                    MessageBox.Show("Все данные удалены", "Чисто!");
                }
                catch (Exception abc)
                {
                    MessageBox.Show("Удаление не было произведено", "Ошибка!");
                }

            }
        }

        private void VACS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ORG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //strorg = ORG
            //strorg =strorg.Split(' ')[0];
            //MessageBox.Show(strorg);
            //UpdateVacs();
            //UpdateApp();
        }
        private string strorg="";
        private string strvac="";
    }
}
