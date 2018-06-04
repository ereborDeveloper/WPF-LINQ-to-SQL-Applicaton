using System;
using System.Windows.Documents;
using System.Data.Linq.Mapping;

namespace kurscachWPF
{
    class entities
    {
        public static string connectionString = @"Data Source=1-ПК;Initial Catalog=BuyvolovKR;Integrated Security=True";

        [Table(Name = "vacancies")]
        public class vacancies
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int Idvacant { get; set; }
            [Column(Name = "position")]
            public string position { get; set; }
            [Column]
            public int salary { get; set; }
            [Column]
            public DateTime dateopen { get; set; }
            [Column]
            public DateTime dateclose { get; set; }
        }
        [Table(Name = "applicant")]
        public class applicant
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int Idapplicant { get; set; }
            [Column(Name = "FIO")]
            public string FIO { get; set; }
            [Column(Name = "position")]
            public string position { get; set; }
            [Column]
            public int salary { get; set; }
            [Column(Name = "Info")]
            public string Info { get; set; }
            [Column]
            public bool hired { get; set; }
        }
        [Table(Name = "final")]
        public class final
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int id { get; set; }
            [Column]
            public DateTime dateopen { get; set; }
            [Column]
            public DateTime dateclose { get; set; }
            [Column(Name = "orgname")]
            public string orgname { get; set; }
            [Column]
            public int salary { get; set; }
            [Column(Name = "position")]
            public string position { get; set; }
            [Column(Name = "FIO")]
            public string FIO { get; set; }
            [Column(Name = "accepted")]
            public string accepted { get; set; }
        }
        [Table(Name = "org")]
        public class org
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int Idorg { get; set; }
            [Column]
            public string orgname { get; set; }
        }
        [Table(Name = "R")]
        public class R
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "Idvacant")]
            public int Idvacant { get; set; }

            [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "Idapplicant")]
            public int Idapplicant { get; set; }
        }
        [Table(Name = "R1")]
        public class R1
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "Idvacant")]
            public int Idvacant { get; set; }

            [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "Idorg")]
            public int Idorg { get; set; }
        }
        [Table(Name = "R2")]
        public class R2
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "Idapplicant")]
            public int Idapplicant { get; set; }

            [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "Idorg")]
            public int Idorg { get; set; }
        }
        [Table(Name = "REG")]
        public class REG
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "Login")]
            public string Login { get; set; }

            [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "Password")]
            public string Password { get; set; }
        }
    }
}
