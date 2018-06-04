using System;
using System.Linq;
using System.Windows;
using System.Data;
using System.Data.Linq;

namespace kurscachWPF
{
    public static class CurrentUser
    {
        public static string name = "Гость";
        public static string password;
        public static byte type=0;
        public static bool flag = true;
        public static int winid;
        public static System.Windows.Window hand;
        private static DataContext db;
        private static Table<applicant> ap;
        private static Table<org> orgg;
        private static Table<REG> reg;
        private static Table<final> final;
        //0-nonlog user
        //1-applicant
        //2-company
        //3-admim
        public static void setLabel(string nm, string pw)
        {
            flag = true;
            //type = 0;
            if (type == 0 || nm=="Гость")
            {
                name = "Гость";
                flag = true;
            }
            if (nm == "Admin" && pw == "Admin")
            {
                type = 3;
                flag = false;
                name = "Admin";
                Admin a = new Admin();
                double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
                double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
                double windowWidth = a.Width;
                double windowHeight = a.Height;
                a.Left = (screenWidth / 2) - (windowWidth / 2);
                a.Top = (screenHeight / 2) - (windowHeight / 2);
                a.Show();
            }
            else
            {
                if (nm != null && pw != null)
                {
                    Connect();
                    var res = from o in reg where o.Login == nm && o.Password == pw select o;
                    if (res.Count() != 0)
                    {
                        name = nm;
                        type = 1;
                        MessageBox.Show("Добро пожаловать!");
                        flag = false;
                        var res2 = from o in orgg where o.orgname == nm select o;
                        if (res2.Count() != 0) type = 2;
                        var fin = from f in final where f.FIO == name select f;
                        if (fin.Count() != 0)
                        {
                            foreach (var ff in fin)
                            {
                                if (ff.accepted.Substring(0,15) == "Не подтверждено")
                                {
                                    if (MessageBox.Show("Поздравляем, " + ff.FIO + "! Вы приняты на работу в компанию " + ff.orgname + " на позицию '"+ff.position  + "'.\nДата приема на работу: " + ff.dateclose + "\n\nХотите ли вы в ней работать?", "Удалить все", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                                    {
                                        ff.accepted = "Подтверждено";
                                        MessageBox.Show("Пойдите купите костюм. Завтра Вам на работу!\n\nТрудокоп - здесь находят работу","Наши поздравления");
                                    }
                                    else
                                    {
                                        ff.accepted = "Отказано";
                                    }
                                    try {
                                        db.SubmitChanges();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                            }
                        }

                    }
                    else MessageBox.Show("Не удалось войти");

                }
            }
        }
        private static void Connect()
        {
            try
            {
                db = new DataContext(entities.connectionString);
                ap = db.GetTable<applicant>();
                orgg = db.GetTable<org>();
                reg= db.GetTable<REG>();
                final = db.GetTable<final>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Не удалось подключиться к базе данных!");
            }
        }
       
    }
}
