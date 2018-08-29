using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace ProjectsReport
{
    static class testData
    {

        static string TMPL = "tmpl.json";
        static string VALUE = "values.json";

        public static string Tmpl
        {
            get
            {
                return readJson(TMPL);
            }
        }

        public static string Values
        {
            get
            {
                return readJson(VALUE);
            }
        }

        static string readJson(string fileName)
        {
            string filePath = $@"{Application.StartupPath}\{fileName}";
            return File.ReadAllText(filePath);
        }

        public static void fillProjects(DataTable _projects)
        {

            _projects.Clear();
            _projects.Columns.Clear();
            _projects.AcceptChanges();

            string[] columns = new string[] {
                    "ContractNum", "ExecuteDate" ,
                    "contractDesc ","RepordDesc", "operatorDesc" ,
                    "Login", "ContractId", "ActivityId" ,
                    "report","ContactWithId"
            };

            foreach (string name in columns)
            {
                if (name.Contains("Id"))
                {
                    _projects.Columns.Add(name, typeof(int));
                }
                else if (name == "report")
                {
                    _projects.Columns.Add(name, typeof(bool));
                }
                else
                {
                    _projects.Columns.Add(name, typeof(string));
                }
            }

            _projects.Rows.Add(new object[]{
                "Р99.204.70904","2018-07-26 08:53:41.610","Доступен ДС : 1. Сума сплати (для клієнта) – 2 274,77 ; 2. Сума оплати для 3-ї особи (поручителя) – 3 101,31 ; 3. Дисконт 5 (для клієнта) – 568,6",
                "{\"Дата\": \"28.08.2018\", \"Сума\": \"1500,10\", \"Отделение\": \"Первое отделение\"}",null,"SKharchenko",48448969,222871955,true,6
            });

            _projects.Rows.Add(new object[]{
                "P32.198.71862","2018-07-26 12:56:51.007",
                "Доступен ДС : 1. Сума сплати (для клієнта) – 1 897,61 ; 2. Сума оплати для 3-ї особи (поручителя) – 2 587,11 ; 3. Дисконт 5 (для клієнта) – 474,4",
                "","бывший муж саша ","DIefimchuk",48445159,222961868,0,6
            });

            _projects.Rows.Add(new object[]{
                "Л69.188.30314","2018-07-26 13:00:21.557","Доступен ДС : 1. Сума сплати (для клієнта) – 7 501,04 ; 2. Сума оплати для 3-ї особи (поручителя) – 10 226,57 ; 3. Дисконт 5 (для клієнта) – 1 875,2",
                "{\"Дата\": \"28.08.2018\", \"Сума\": \"1800,10\", \"Отделение\": \"Первое отделение\"}","бывший муж Антон 0953294553","DIefimchuk",48492773,222963954,0,6
            });

            _projects.Rows.Add(new object[]{
                "Z37.546.70024","2018-07-26 17:22:21.863","Доступен ДС : 1. Сума сплати (для клієнта) – 8 828,83 ; 2. Сума оплати для 3-ї особи (поручителя) – 12 036,82 ; 3. Дисконт 5 (для клієнта) – 2 207,2",
                "","не общ","DVolkova",48891690,223094133,0,6
            });

            _projects.Rows.Add(new object[]{
                "P25.030.74775","2018-07-26 17:26:15.037","Доступен ДС : 1. Сума сплати (для клієнта) – 25 691,14 ; 2. Сума оплати для 3-ї особи (поручителя) – 35 026,11 ; 3. Дисконт 5 (для клієнта) – 6 422,7",
                "",null,"DVolkova",48744510,223095770,0,6
            });
        }



        static public string ContractInfoInit = @"
<html>
    <head>
    </head>
    <body>
    <h1>Number</h1>
    <h1>FIO</h1>
    </body>
</html>
";

    }
}
