using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Web.Script.Serialization;


namespace ProjectsReport
{
    class Parameters : List<Paramerer>
    {
        public Parameters(string paramTemplate, string paramValue)
        {
            var serializer = new JavaScriptSerializer();
            dynamic tpml = serializer.DeserializeObject(paramTemplate);
            if (tpml["fields"] is object[])
            {
                foreach (object values in (object[])tpml["fields"])
                {
                    Dictionary<string, object> valueSet = (Dictionary<string, object>)values;
                    this.Add(new Paramerer() {
                        ShortName = valueSet["ShortName"].ToString(),
                        Value =  valueSet["Value"].ToString(),
                        Type = valueSet["Type"].ToString(),
                        Mask = valueSet["Mask"].ToString()
                    }
                    );
                }
            }
            /*
                this.Add(new Paramerer() { ShortName = "Дата", Value = "28.08.2018", Type = "DateTime", Mask = "00/00/0000" });
                this.Add(new Paramerer() { ShortName = "Сума", Value = "1500,00" , Type = "Decimal", Mask = @"$# ### ##0.00" });
                this.Add(new Paramerer() { ShortName = "Отделение", Value = "Первое отделение", Type = "String" });
            */
            Table.Rows.Add();
            foreach (Paramerer curParameter in this)
            {
                Type curType = Type.GetType($"System.{curParameter.Type}");
                Table.Columns.Add(curParameter.ShortName, curType);
                Table.Rows[0][curParameter.ShortName] = Convert.ChangeType(curParameter.Value, curType);
            }
        }

        public DataTable Table { get; private set; } = new DataTable();
    }
}

//TODO initialize parameters properties in a loop
//TODO set param values


