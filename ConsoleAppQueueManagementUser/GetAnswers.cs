using ConsoleAppQueueManagementAgent;
using ConsoleAppQueueManagementUser;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppQueueManagementAgent
{
    internal class GetAnswers:Page
    {
        public GetAnswers(Page previous)
        {
            PageName = "Get Answers Page";
            PreviousPage = previous;
        }
        public override void Menu()
        {
            GetAns();
        }
        public void GetAns()
        {
            Console.Clear();
            List<Info> infoList = new List<Info>();
            string Tokenno = consolereader.getstring("Please Enter Token no :- ");
            using(HttpClient client = new HttpClient())
            {
                infoList = client.GetFromJsonAsync<List<Info>>($"https://localhost:44372/Api/agent?tokenno={Tokenno}").Result;
            }
            if (infoList.Count == 0)
            {
                Console.WriteLine("Enter a correct Token ID");
                Thread.Sleep(2000);
                GetAns();
            }
            else {
                foreach (var item in infoList)
                {
                    Console.WriteLine("User ID: " + item.userid);
                    Console.WriteLine("Token Date: " + item.Tokendate);
                    Console.WriteLine("Status Name: " + item.StatusName);
                    Console.WriteLine("Counter ID: " + item.CounterId);
                    Console.WriteLine("Branch Name: " + item.BranchName);
                    Console.WriteLine("Company Name: " + item.CompanyName);

                    Console.WriteLine("Press Enter to Proceed.");
                    Console.ReadLine();
                }
            }            
        }
        //GetAnswer 'm-20'
    }
}
