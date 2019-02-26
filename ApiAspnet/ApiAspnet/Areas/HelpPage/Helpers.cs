using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiAspnet.Areas.HelpPage
{
    public static class Helpers
    {

        public static String DateToStr(this DateTime valor)
        {
            return Convert.ToDateTime(valor).ToString("dd/MM/yyyy");
        }
        public static String DateToStr(this DateTime? valor)
        {
            if (valor == null)
            {
                return String.Empty;
            }
            else
            {
                return Convert.ToDateTime(valor).ToString("dd/MM/yyyy");
            }

        }
    }
}