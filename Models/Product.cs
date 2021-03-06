using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using Dapper;
using WebGrease.Css.Extensions;

namespace AbyssAzul.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public string LatinName { get; set; }
        public string Size { get; set; }
        public string Presentation { get; set; }
        public string ProcessPacking { get; set; }
        public string Origin { get; set; }
        public string Region { get; set; }
        public int RegionId { get; set; }
        public string CommonNamesFormatted { get; set; }
        public string URLName { get; set; }
        public string FileName { get; set; }
        public IEnumerable<CommonNames> CommonNames { get; set; } = new List<CommonNames>();
        public IEnumerable<Images> Images { get; set; } = new List<Images>();

        public Product()
        {
        }

        public Product(string productId)
        {
          
            var isNum = int.TryParse(productId, out var intProductId);
            if (productId.Length > 50 || !isNum)
            {
                throw new Exception("Invalid Product ID");
            }

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                var product = conn.Query<Product>(sql: "Product_Get",
                    commandType: CommandType.StoredProcedure, param: new
                    {
                        ProductId = intProductId
                    }).FirstOrDefault();

                var commonNames = conn.Query<CommonNames>(sql: "CommonNames_GetList",
                    commandType: CommandType.StoredProcedure, param: new
                    {
                        ProductId = product.ProductId
                    });
                var image = conn.Query<Images>(sql: "Images_GetList",
                    commandType: CommandType.StoredProcedure, param: new
                    {
                        ProductId = product.ProductId
                    });
                var region = conn.Query<Regions>(sql: "Region_Get",
                    commandType: CommandType.StoredProcedure, param: new
                    {
                        RegionId = product.Region
                    }).FirstOrDefault();

                Name = product.Name;
                OtherName = product.OtherName;
                LatinName = product.LatinName;
                Size = product.Size;
                Presentation = product.Presentation;
                ProcessPacking = product.ProcessPacking;
                Origin = product.Origin;
                Region = region.RegionName;
                CommonNames = commonNames;
                Images = image;
                URLName = region.RegionNameView;
                FormatCommonNames(commonNames);
                RegionId = region.RegionId;
            }
        }

        private void FormatCommonNames(IEnumerable<CommonNames> commonNames)
        {
            var cmFormat = commonNames.Aggregate(string.Empty, (current, item) => current + (item.Name + " / "));

            CommonNamesFormatted = cmFormat.Substring(0, cmFormat.Length - 2);
        }

        public IEnumerable<Product> GetProductsByRegion(string regionId)
        {
            var isNum = int.TryParse(regionId, out var intRegionId);
            if(regionId.Length > 50 || !isNum) throw new Exception("Invalid Region ID");
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                var products = conn.Query<Product>(sql: "Product_GetByRegion",
                    commandType: CommandType.StoredProcedure, param: new
                    {
                        RegionId = intRegionId
                    }).OrderBy(x=>x.Name);

                foreach (var product in products)
                {
                    var image = conn.Query<Images>(sql: "Images_GetList",
                        commandType: CommandType.StoredProcedure, param: new
                        {
                            ProductId = product.ProductId
                        }).FirstOrDefault()
                        ?.FileName;
                    product.FileName = image;
                }
                return products;
            }
        }
    }
}