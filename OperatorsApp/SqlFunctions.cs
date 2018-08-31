using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ProjectsReport
{
    static class SqlFunctions
    {
        static public SqlConnection conn { get; private set; } =
            new SqlConnection(Properties.Settings.Default.collect);

        public static string field_Marked = "Marked";
        public static string field_Report = "Report";
        public static string field_Surname = "Surname";


        public static string[] invisibleColumns = new string[]
            {"ProjectId","id"};

        static SqlDataAdapter projectListAdapter = new SqlDataAdapter(@"
        select * from pr_contactList(@DateActivity, null)                
                ",
            conn);

        static SqlDataAdapter projectsAdapter = new SqlDataAdapter(@"
            select * from pr_projects where id = @id
                ",
            conn);


        //static SqlCommandBuilder projectsBuider = new SqlCommandBuilder(getProgects);

        static SqlFunctions()
        {
            projectListAdapter.SelectCommand.Parameters.Add("@DateActivity", SqlDbType.DateTime); ;
        }

        //string sqlGetProgects = "";

        static public void fillProjectListTable(DataTable table, DateTime date)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            projectListAdapter.SelectCommand.Parameters[0].Value = date;
            table.Clear();
            projectListAdapter.Fill(table);
            conn.Close();
        }

        static public void fillProjectsTable(DataTable table, int id)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            projectsAdapter.SelectCommand.Parameters[0].Value = id;
            projectListAdapter.Fill(table);
            conn.Close();
        }


    }
}
