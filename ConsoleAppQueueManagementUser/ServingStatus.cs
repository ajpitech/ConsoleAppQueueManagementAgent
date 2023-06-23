using ConsoleAppQueueManagementAgent;
using ConsoleAppQueueManagementUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppQueueManagementAgent    
{
    internal class ServingStatus:Page
    {
        public ServingStatus(Page previous)
        {
            PageName = "Serving Status Page";
            PreviousPage = previous;
        }
        public override void Menu()
        {
            Status status = new Status();
            String responseStr = "";
            status.Tokenno = consolereader.getstring("Please Enter Token no :");
            status.CounterId = consolereader.getint("Please Enter Counter no :");
            status.statusid = consolereader.getint("Please Enter Status Id:");
            using (HttpClient client = new HttpClient())
            {
                var response = client.PutAsJsonAsync($"https://localhost:44372/Api/agent", status).Result.Content.ReadFromJsonAsync<OutResponse<string>>();
                responseStr = response.Result.ResData;
            }
            Console.WriteLine(responseStr);
            Console.ReadLine();
        }
    }
}
