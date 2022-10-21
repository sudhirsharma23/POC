using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IISLog.Common
{
    public class ApplicationInfo
    {
        public string Name;
        public string Username;

        public ApplicationInfo(string name, string Username)
        {
            this.Name = name;
            this.Username = Username;
        }
    }
}
