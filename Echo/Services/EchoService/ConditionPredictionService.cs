using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

/*
 * Follow this instruction with simple modified
 * https://developer.telerik.com/topics/machine-learning/consuming-azure-machine-learning-asp-net-core/
 */

namespace Echo.Services.EchoService
{

    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }

    public class ConditionPredictionService
    {

        public async Task<string> InvokeRequestResponseService(int hr, int temp)
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"Temperature", "HeartBeat", "Condition"},
                                Values = new string[,] {  { temp.ToString(), hr.ToString(), "0" } }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "OUVgxhlQkvMVIM+w6iqdFkhieAjEaaOhvOVl9K7CXYrWm0pmQs0O9jPcNgE68/+B/UnmddP0wXruw1+XubHG8w=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/d7f69392cc524005b3f42286579107ea/services/239b746ee3bd4e8687b7d56a7af15db6/execute?api-version=2.0&details=true");

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)


                //HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                HttpResponseMessage response = await client
                    .PostAsync("", new StringContent(JsonConvert.SerializeObject(scoreRequest), Encoding.UTF8, "application/json"))
                    .ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    return string.Format("The request failed with status code: {0}", response.StatusCode);
                }
            }
        }

    }

}
