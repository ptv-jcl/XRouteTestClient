using System;
using System.Net;

namespace Static
{
    public static class StaticClass
    {
        public static NetworkCredential credentials = new NetworkCredential(XRouteTestClient.Properties.Settings.Default.xServerUserName, XRouteTestClient.Properties.Settings.Default.xServerPassword);
    }
}