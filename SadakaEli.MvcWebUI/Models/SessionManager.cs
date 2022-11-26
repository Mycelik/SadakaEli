using SadakaEli.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SadakaEli.MvcWebUI.Models
{
    public static class SessionManager
    {
        public static Admin ActiveAdmin
        {
            get
            {
                return HttpContext.Current.Session["ActiveAdmin"] as Admin;
            }
            set
            {
                HttpContext.Current.Session.Add("ActiveAdmin", value);
            }
        }
    }
}