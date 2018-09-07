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
        public static string field_ProjectName = "Name";
        public static string field_Surname = "Surname";
        public static string field_contractId = "Id";           // fn_pr_contactList
        public static string field_projecttId = "ProjectId";    // fn_pr_contactList
        public static string sql_shema = @"[CORP\IKotvytskyi].";


        public static string[] invisibleColumns = new string[]
            {"ProjectId","id"};

        static SqlDataAdapter contactsAdapter = new SqlDataAdapter(
            $@" select * from {sql_shema}fn_contactList(@DateActivity, null)",
            conn);

        static SqlDataAdapter projectsAdapter = new SqlDataAdapter(
            $@" select * from {sql_shema}projects where id = @id",
            conn);

        static SqlDataAdapter contactInfoAdapter = new SqlDataAdapter(
            $@" select* from {sql_shema}fn_ContactInto(@ContactId)",
            conn);

        static SqlCommand ContactUpdCmd = new SqlCommand(
            $"update {sql_shema}contacts set Marked = @Marked, Report = @Report  where id = @Id", 
            conn);


        //static SqlCommandBuilder projectsBuider = new SqlCommandBuilder(getProgects);

        static SqlFunctions()
        {
            contactsAdapter.SelectCommand.Parameters.Add("@DateActivity", SqlDbType.DateTime); ;

            ContactUpdCmd.Parameters.Add("@Marked",SqlDbType.Bit);
            ContactUpdCmd.Parameters.Add("@Report",SqlDbType.VarChar);
            ContactUpdCmd.Parameters.Add("@Id",SqlDbType.BigInt);
            string[] paramsName = new string[] { "Marked", "Report", "Id" };
            foreach ( string name in paramsName)
            {
                ContactUpdCmd.Parameters[$"@{name}"].SourceVersion = DataRowVersion.Current;
                ContactUpdCmd.Parameters[$"@{name}"].SourceColumn = name;
            }
            contactsAdapter.UpdateCommand = ContactUpdCmd;
            projectsAdapter.SelectCommand.Parameters.Add("@id", SqlDbType.BigInt); ;
            contactInfoAdapter.SelectCommand.Parameters.Add("@ContactId", SqlDbType.BigInt); ;

        }

        static public void fillContactsTable(DataTable table, DateTime date)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            contactsAdapter.SelectCommand.Parameters[0].Value = date;
            table.Clear();
            contactsAdapter.Fill(table);
            conn.Close();
        }

        static public void fillProjectsTable(DataTable table, long id)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            projectsAdapter.SelectCommand.Parameters[0].Value = id;
            projectsAdapter.Fill(table);
            conn.Close();
        }

        static public void fillContactInfoTable(DataTable table, long ContactId)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            contactInfoAdapter.SelectCommand.Parameters[0].Value = ContactId;
            contactInfoAdapter.Fill(table);
            conn.Close();
        }

        static public void updContacts(DataTable table)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            contactsAdapter.Update(table);
            conn.Close();
        }
    }
}
