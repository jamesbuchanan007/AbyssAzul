using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using Dapper;

namespace AbyssAzul.Models
{
    public class Regions
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; } = string.Empty;
        public string RegionNameView { get; set; } = string.Empty;
        public string ImgURL { get; set; } = string.Empty;
        public Regions Region { get; set; }
        public Regions() { }

        public Regions(string regionId)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                this.Region = conn.Query<Regions>(sql: "Region_Get",
                    commandType: CommandType.StoredProcedure, param: new
                    {
                        RegionId = regionId
                    }).FirstOrDefault();
            }
        }

        public Regions GetRegion()
        {
            return Region;
        }
    }
}