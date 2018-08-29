using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ProjectsReport
{
    class Props
    {
        public Props(string name)
        {
            ShortName = name;
        }


        public Props(string name, Dictionary<string,object> properties)
            :this(name)
        {
            IList<PropertyInfo> propsList = new List<PropertyInfo>(typeof(Props).GetProperties(BindingFlags.Public | BindingFlags.Instance));

            foreach (PropertyInfo prop in propsList)
            {
                if (!prop.CanWrite)
                {
                    continue;
                }
                if (properties.ContainsKey(prop.Name))
                {
                    prop.SetValue(this, properties[prop.Name],null);
                }
            }
        }

        public string ShortName { get; private set; }
        public string LongName { get; set; }
        public string Value { get; set; }
        public string Comment;
        public string Type { get; set; }
        public string Mask { get; set; }

        public static string ValueProperty = "Value";

    }
}
