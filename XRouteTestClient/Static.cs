using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace XRouteTestClient
{
    public static class Static
    {
        public  static NetworkCredential credentials = new NetworkCredential(Properties.Settings.Default.xServerUserName, Properties.Settings.Default.xServerPassword);
    }
}
