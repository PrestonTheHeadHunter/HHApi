using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HHApi.Models;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;

namespace HHApi.Service
{
    public class AzureTableRetrieve : IRetrieveProduct
    {

        private string azureTableName { get; set; }

        public AzureTableRetrieve()
        {
            azureTableName = ConfigurationManager.AppSettings["AzureTableName"].ToString();
        }
        
        public IProduct Get()
        {
            return new Product() { Description = "t", Price = 0.00m, Id = -1 };
        }

        public IEnumerable<IProduct> GetAll()
        {

            var retList = new List<Product>();
            
            var table = AzureTableHelper.GetCloudTable(azureTableName);
            
            TableQuery<ProductDTO> query = new TableQuery<ProductDTO>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.NotEqual, ""));

            foreach (ProductDTO entity in table.ExecuteQuery(query))
                retList.Add(new Product() { Description = entity.Description, Id = entity.ProdId, Price = Convert.ToDecimal(entity.Price) });
            
            return retList;
        }
    }
}