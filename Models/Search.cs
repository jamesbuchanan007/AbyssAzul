using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using WebGrease.Css.Extensions;

namespace AbyssAzul.Models
{
    public class Search
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string OtherName { get; set; } = string.Empty;
        public string LatinName { get; set; } = string.Empty;
        public string CommonName { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public IEnumerable<CommonNames> CommonNames { get; set; } = new List<CommonNames>();
        public string ImgFileName { get; set; } = string.Empty;

        public List<Search> Results { get; set; } = new List<Search>();

        public Search() { }

        public void Find(string searchItem)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                var result = conn.Query<Search>(sql: "SearchGet",
                    commandType: CommandType.StoredProcedure, param: new
                    {
                        SearchParameter = searchItem
                    }).ToList();

                result.ForEach(x=> Results.Add(
                    new Search()
                    {
                        ProductId = x.ProductId,
                        Name = x.Name, 
                        OtherName = x.OtherName, 
                        LatinName = x.LatinName, 
                        Region = x.Region,
                        Origin = x.Origin,
                        ImgFileName = x.ImgFileName
                    }));
            }

            GetCommonNames();
        }

        public void GetCommonNames()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                foreach (var result in Results)
                {
                    var commonNames = conn.Query<CommonNames>(sql: "CommonNames_GetList",
                        commandType: CommandType.StoredProcedure, param: new
                        {
                            ProductId = result.ProductId
                        });
                   result.CommonName = FormatCommonNames(commonNames);
                }
               
            }
        }

        private string FormatCommonNames(IEnumerable<CommonNames> commonNames)
        {
            var cmFormat = commonNames.Aggregate(string.Empty, (current, item) => current + (item.Name + " / "));

            return cmFormat.Substring(0, cmFormat.Length - 2);
        }
    }
}