using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace AbyssAzul.Models
{
    public class Regions
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public Regions(){}

        public static Regions GetRegions(string regionId)
        {
            var isNum = int.TryParse(regionId, out var intRegionId);
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                return conn.Query<Regions>(sql: "Region_Get",
                    commandType: CommandType.StoredProcedure, param: new
                    {
                        RegionId = intRegionId
                    }).FirstOrDefault();
            }
        }
    }
}