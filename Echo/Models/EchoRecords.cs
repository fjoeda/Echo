using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echo.Models
{
    public class EchoRecords : TableEntity
    {
        public EchoRecords()
        {
        }

        public EchoRecords(string partitionKey, string rowKey)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;
        }

        public Int64 heartbeat { get; set; }

        public Int64 temperature { get; set; }

        public String condition { get; set; }

        public Double longitude { get; set; }

        public Double latitude { get; set; }
    }
}