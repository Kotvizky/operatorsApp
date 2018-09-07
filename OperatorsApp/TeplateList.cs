using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ProjectsReport
{
    class TeplateList
    {

        const string TMPL_HTML = "TmplHtml";
        const string TMPL_PARAMS = "TmplParams";
        const string PRIMARY_KEY = "Id";

        long ProjectId;

        void initTmpl(long projectId)
        {
            if (ProjectId == projectId)
            {
                return;
            }
            ProjectId = projectId;
            SqlFunctions.fillProjectsTable(Projects, ProjectId);
            if (Projects.PrimaryKey.Length == 0)
            {
                Projects.PrimaryKey = new DataColumn[] { Projects.Columns[PRIMARY_KEY] };
            }
            Project = Projects.Rows.Find(ProjectId);
        }

        public string GetHtmpTmpl(long projectId)
        {
            return getTmpl(projectId, TMPL_HTML);
        }

        public string GetParamTmpl(long projectId)
        {
            return getTmpl(projectId, TMPL_PARAMS);
        }

        string getTmpl(long projectId, string tmplName)
        {
            initTmpl(projectId);
            string result = string.Empty;
            if (Project != null)
            {
                result = Project[tmplName].ToString();
            }
            return result;
        }

        DataTable Projects = new DataTable();

        DataRow Project;
    }
}

