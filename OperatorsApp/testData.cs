using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ProjectsReport
{
    static class testData
    {

        static string TMPL = "tmpl.json";
        static string VALUE = "value.json";

        public static string Tmpl
        {
            get
            {
                return readJson(TMPL);
            }
        }

        public static string Values
        {
            get
            {
                return readJson(VALUE);
            }
        }

        static string readJson(string fileName)
        {
            string filePath = $@"{Application.StartupPath}\{fileName}";
            return File.ReadAllText(filePath);
        }



    }
}
