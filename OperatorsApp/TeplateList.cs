using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectsReport
{
    class TeplateList: Dictionary<int,string>
    {
        public string getTmpl(int i)
        {
            if (this.ContainsKey(i))
            {
                return this[i];
            }
            else
            {
                return initTmpl(i);
            }
        }

        string initTmpl(int i)
        {
            string tmpl = testData.Tmpl; // TODO describe method
            this.Add(i, tmpl);
            return tmpl;
        }
    }
}
