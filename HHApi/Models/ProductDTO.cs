using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

using Microsoft.WindowsAzure;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

using Microsoft.WindowsAzure.Storage.Shared;

namespace HHApi.Models
{
    public class ProductDTO : TableEntity
    {
        public ProductDTO()
        {

        }

        public ProductDTO(string partitionKey, string rowKey)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

        public void SetProduct(IProduct prod)
        {

            //ProdId = prod.Id.ToString();
            ProdId = Convert.ToDouble(prod.Id);
            Description = prod.Description;
            Price = prod.Price.ToString();
        }

        public Double ProdId { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }
    }


    
}