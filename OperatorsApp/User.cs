using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectsReport
{
    class User
    {
        public User()
        {
            Login = Environment.UserName;
            FullName = SqlFunctions.getFullUserName(Login);
            IsProjectManager = SqlFunctions.isProjectManager(Login);
        }

        public string FullName { get; private set; }
        public string Login { get; private set; }
        public bool IsProjectManager { get; private set; }
        public string Title {
            get
            {
                return ((FullName != string.Empty) ? FullName : Login )
                       + " -- " + ((IsProjectManager) ? "ПМ" : "Оператор");
            }
        }

    }
}
