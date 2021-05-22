using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbyssAzul.Models
{
    public class Helper
    {
        private static string ConnectionString { get; } =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Source\AbyssAzul\App_Data\AbyssAzulDB.mdf;Integrated Security=True";

        public static string GetConnectionString()
        {
            return ConnectionString;
        }
    }

   
}