using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Analytics.Models
{
    public class WebClientNT : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            HttpWebRequest w = (HttpWebRequest)base.GetWebRequest(uri);
            w.Timeout = 30 * 60 * 2000;
            w.KeepAlive = false;
            return w;

        }
    }
}