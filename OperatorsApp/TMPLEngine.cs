using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ProjectsReport
{
    static class TmplEngine
    {
        static string Template = string.Empty;
        static DataTable Values = new DataTable();
        public static string Html 
        {
            get
            {
                if ((Template == string.Empty) || (Values == null) || (Values.Rows.Count == 0))
                {
                    return string.Empty;
                }
                string result = Template;
                foreach (DataColumn column in Values.Columns)
                {
                    result = result.Replace("{{" + column.ColumnName + "}}",
                        Values.Rows[0][column.ColumnName].ToString());
                }
                return result;
            }
        }

        static long ContactId;

        public static string getContent(long contactId, string template)
        {
            Template = template;
            if  (ContactId != contactId)
            {
                ContactId = contactId;
                Values.Clear();
                SqlFunctions.fillContactInfoTable(Values, ContactId);
            }
            return Html;
        }
    }
}
