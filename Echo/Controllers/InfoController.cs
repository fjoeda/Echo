using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Timers;
using Echo.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage.Auth;
using System.Diagnostics;

namespace Echo.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        //Informationlnkl info = new Informationlnkl();
        List<Aircraft> daftarPesawat = new List<Aircraft>();
        List<Passenger> daftarPenumpang = new List<Passenger>();

        Aircraft pesawat = new Aircraft()
        {
            Nama = "Garuda Indonesia Airways",
            FlightNumber = "GA-201",
            Model = "B737-800",
            Asal = "Yogyakarta (JOG)",
            Tujuan = "Jakarta (CGK)",
            Latitude = -5.670402f,
            Longitude = 108.176275f,
            Status = "Contact Lost 15 Minutes Ago"

        };

        

        public async Task<ActionResult> UpdateListPassenger()
        {
            daftarPenumpang.Clear();

            try
            {
                String accountName = "echoiotstorage";
                String accountKey = "iK+YbzvkYKxpn1fwoQOCyIiMjFwjtklq/4gIJCj64MqHt1IPhtw9Wb5101gzpUd+7/FT9vyWDNEOdRDF1CDXLQ==";

                StorageCredentials creds = new StorageCredentials(accountName, accountKey);
                CloudStorageAccount storageAccount = new CloudStorageAccount(creds, useHttps: true);

                // Create the table client.
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

                // Get a reference to a table named "EchoRecords"
                CloudTable echoTable = tableClient.GetTableReference("EchoRecords");
                Debug.WriteLine("Connection Succes!");

                /*
                // Construct the query operation for all customer entities where PartitionKey="Smith".
                var query = new TableQuery().Take(1);
                var result = echoTable.ExecuteQuery(query).ToList();
                if (result != null && result.Count > 0)
                {
                    var dynamicTableEntity = result[0];
                    foreach (var property in dynamicTableEntity.Properties)
                    {
                        Debug.WriteLine(property.Key + " = " + property.Value.PropertyType);
                    }
                }
                
                */
                
                // Construct the query operation for all customer entities where PartitionKey="Smith".
                TableQuery<EchoRecords> query = new TableQuery<EchoRecords>();

                // Print the fields for each customer.
                TableContinuationToken token = null;
                do
                {
                    TableQuerySegment<EchoRecords> resultSegment = await echoTable.ExecuteQuerySegmentedAsync(query, token);
                    token = resultSegment.ContinuationToken;
                    int i = 0;
                    foreach (EchoRecords entity in resultSegment.Results)
                    {
                        Debug.WriteLine("{0}, {1}\t{2}\t{3}\t{4}\t{5}", entity.PartitionKey, entity.RowKey,
                        entity.heartbeat.ToString(), entity.temperature.ToString(), entity.latitude.ToString(), entity.longitude.ToString());
                        daftarPenumpang.Add(new Passenger()
                        {
                            name = "Passenger " + i,
                            id = i,
                            heartrate = int.Parse(entity.heartbeat.ToString()),
                            temperature = int.Parse(entity.temperature.ToString()),
                            latitude = -6.2223623f,
                            longitude = 106.8052861f,
                            condition = "Alive"
                        });
                        i++;
                    }
                } while (token != null);
              
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            daftarPenumpang.Add(new Passenger()
            {
                name = "Victima",
                id = 1,
                heartrate = 87,
                temperature = 26,
                latitude = -6.2223623f,
                longitude = 106.8052861f,
                condition = "Alive"
            });


            return Json(daftarPenumpang, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowPassengerInfo(int _id, string _name, int _heartrate, float _temperature,
            float _latitude, float _longitude, string _condition)
        {
            var JsonList = new List<Passenger>()
            {
                new Passenger()
                {
                    id = _id,
                    name = _name,
                    heartrate = _heartrate,
                    temperature = _temperature,
                    latitude = _latitude,
                    longitude = _longitude,
                    condition = _condition,
                }
            };

            return Json(JsonList, JsonRequestBehavior.AllowGet);
        }


        public ActionResult MapAircraft()
        {
            
            var JsonList = new List<Aircraft>()
            {
                pesawat
            };

            //ShowAircraft(pesawat);
            return Json(JsonList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowAircraft()
        {
            
            return PartialView("_Information", pesawat);
        }

        
    }
}