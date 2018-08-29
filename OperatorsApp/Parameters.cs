using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Reflection;

namespace ProjectsReport
{
    class Parameters : List<Props>
    {

        public Parameters(string paramTemplate, string paramValue)
        {
            var serializer = new JavaScriptSerializer();
            var tmpl = serializer.DeserializeObject(paramTemplate);
            dynamic values = serializer.DeserializeObject(paramValue);

            if (tmpl is Dictionary<string,object>)
            {
                initProps((Dictionary<string, object>)tmpl,(Dictionary<string, object>)values);
            }
        }

        void initProps(Dictionary<string,object> propsJson, Dictionary<string, object> valuesJson)
        {

            foreach (KeyValuePair<string, object> entry in propsJson)
            {
                Dictionary<string, object> values = (Dictionary<string, object>)entry.Value;
                if (valuesJson.ContainsKey(entry.Key))
                {
                    values.Add(Props.ValueProperty, valuesJson[entry.Key]);
                }
                Props props = new Props(entry.Key, values);
                this.Add(props);
            }
        }

        public string JsonValues
        {
            get
            {
                string result = string.Empty;
                Dictionary<string, string> valuesList = new Dictionary<string, string>();
                foreach (Props prop in this)
                {
                    valuesList.Add(prop.ShortName,prop.Value);
                }
                return (new
                    JavaScriptSerializer()).Serialize(valuesList);
            }
        }
    }
}


