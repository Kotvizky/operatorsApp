using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ProjectsReport
{
    class TMPLEngine
    {
        public string Template = string.Empty;
        public DataTable Values;
        public string Html 
        {
            get
            {
                if ((Template == string.Empty) || (Values == null) || (Values.Rows.Count == 0))
                {
                    return string.Empty;
                }
                string result = string.Empty;
                foreach (DataColumn column in Values.Columns)
                {
                    result = result.Replace("{{" + column.ColumnName + "}}",
                        Values.Rows[0][column.ColumnName].ToString());
                }
                return result;
            }
        }

        public void initTable(int ContactId)
        {
            //TODO Add SQL to get contact data
        }
    }
}
