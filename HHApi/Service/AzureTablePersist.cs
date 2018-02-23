using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;

using HHApi.Models;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;

namespace HHApi.Service
{
    public class AzureTablePersist : IPersistProduct
    {

        private string azureTableName { get; set; }
        
        public AzureTablePersist()
        {
            azureTableName = ConfigurationManager.AppSettings["AzureTableName"].ToString();
        }

        private string GetNewUniqueKey()
        {
            return Guid.NewGuid().ToString().Replace("-","").Substring(0,10);
        }

        private string GetNewPartitionKey()
        {
            return DateTime.Now.Date.ToShortDateString().Replace(@"/","");
        }
        
        public async void Save(IProduct product)
        {

            try
            {
                
                var table = AzureTableHelper.GetCloudTable(azureTableName);
                
                ProductDTO ent = new ProductDTO(GetNewPartitionKey(), GetNewUniqueKey());
                ent.SetProduct(product);

                TableOperation ins = TableOperation.Insert(ent);

                await table.ExecuteAsync(ins);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
                        
        }
        
        public void Save(string JSONData)
        {
            try
            {

                var table = AzureTableHelper.GetCloudTable("HHIUnstructured");

                var ent = new UnstructuredTable(GetNewUniqueKey(), GetNewUniqueKey()) { RawData = JSONData };

                table.Execute(TableOperation.Insert(ent));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public void Update()
        {
        }
    }
}