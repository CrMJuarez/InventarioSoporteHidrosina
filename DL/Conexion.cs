using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DL
{
    public class Conexion
    {
       

        public static string GetConnectionString(string connectionString)
        {
            IConfigurationRoot Configuration;
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true,reloadOnChange:false );
            try
            {
                Configuration = builder.Build();
                return Configuration.GetSection(connectionString).Value;
            }
            finally
            {
                builder = null;
                Configuration = null;
            }
        }
    }
}
