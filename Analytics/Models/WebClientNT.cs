using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Analytics.Models
{
    public class WebClientNT: WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = 10 * 60 * 1000;
            return w;
        }
    }
}