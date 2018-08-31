using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ProjectsReport
{
    class TeplateList
    {

        const string TMPL_PARAMS = "TmplParams";
        const string TMPL_HTML = "TmplHtml";
        

        public string[] getTmpl(int i)
        {
            if ( i == id)
            {
                return getTmplFromRow();
            }

            if ((Projects == null) || ((Project = Projects.Rows.Find(i)) == null))
            {
                initTmpl(i);
            }

            return getTmplFromRow();
        }

        string[] getTmplFromRow()
        {
            if (Project == null)
            {
                return null;
            }
            return new string[] { Project[TMPL_PARAMS].ToString(), Project[TMPL_HTML].ToString() };
        }


        int id;

        void initTmpl(int i)
        {
            id = i;
            bool setKey = (Projects == null);
            SqlFunctions.fillProjectsTable(Projects, id);
            if (setKey)
            {
                // TODO set primary key in the projects table
            }
            Project = Projects.Rows.Find(id);
        }

        DataTable Projects;

        DataRow Project;

    }


}
