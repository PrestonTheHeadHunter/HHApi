using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace HHApi.Models
{
    public class UnstructuredTable : TableEntity
    {
       
        public UnstructuredTable()
        {

        }

        public UnstructuredTable(string part, string row)
        {
            PartitionKey = part;
            RowKey = row;
        }

        public string RawData { get; set; }
    }
}