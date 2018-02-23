using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

using System.Configuration;

namespace HHApi.Service
{
    public static class AzureTableHelper
    {

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["AzureStorageTable"].ConnectionString;
        }
        
        private static CloudTableClient GetTableClient()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(GetConnectionString());

            return storageAccount.CreateCloudTableClient();
        }

        public static CloudTable GetCloudTable(string tablename)
        {
            var table = GetTableClient().GetTableReference(tablename);
            table.CreateIfNotExists();

            return table;
        }

    }
}