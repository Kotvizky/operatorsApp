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


//        static private SqlCommand getProgects = new SqlCommand();

        static SqlDataAdapter projectsAdapter = new SqlDataAdapter(@"
                select 

	                ContractNum , ExecuteDate ,
	                contractDesc  , operatorDesc ,
	                Login , ContractId , ActivityId ,
	                report
	                ,t0.ContactWithId 
                from fn_reportNFS(@DateActivity) t0
                --where t0.ActivityId = 218998706
                order by t0.ExecuteDate
                ",
            conn);

        //static SqlCommandBuilder projectsBuider = new SqlCommandBuilder(getProgects);

        static SqlFunctions()
        {
            projectsAdapter.SelectCommand.Parameters.Add("@DateActivity", SqlDbType.DateTime); ;
        }

        //string sqlGetProgects = "";

        static public void fillProjectsTable(DataTable table, DateTime date)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            projectsAdapter.SelectCommand.Parameters[0].Value = date;
            projectsAdapter.Fill(table);
            conn.Close();
        }

    }
}
