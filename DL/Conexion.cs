using System;
using System.Collections.Generic;
using System.Text;

namespace DL
{
    public class Conexion
    {
        public static string GetConnection()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["InventarioSoporteHidrosina"].ConnectionString;
        }
    }
}
