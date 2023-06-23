using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Data;
using System.Net.Http;
using System.Net.Http.Json;
using ConsoleAppQueueManagementUser;
using System.Threading;

namespace ConsoleAppQueueManagementAgent
{
    internal class Page
    {
        //public SqlConnection con = new SqlConnection(@"Data Source=PC-227\SQL2016EXPRESS;Initial Catalog=Northwind;Persist Security Info=True;User ID=sagar;Password=aa");
        public string PageName { get; set; }
        public Page PreviousPage { get; set; }
        public int menuid { get; set; }
        public static int Service_Branch_id { get; set; }
        public List<Page> pageList = new List<Page>();

        public virtual void Menu()
        {
            bool login = false;
            ShowMenu(login);
        }
        public void ShowPageName() { Console.WriteLine("This is " + PageName + " page."); }
        public void ShowMenu(bool login)
        {
            login = LoginPage();
            //ShowPageName();
            if (login == true)
            {
                Options();
            }
            else
            {
                Console.WriteLine("Incorrect Credentials.");
                Thread.Sleep(2000);
                Title();
                ShowMenu(login);
            }
        }

        public void Options()
        {
            Console.WriteLine("Login Successful.\nPress Enter to Proceed.");
            Console.ReadLine();
            //Console.Clear();
            if (pageList.Count > 0)
            {
                Console.WriteLine(Messge.ChoiceMsg);
                foreach (Page p in pageList)
                {
                    Console.WriteLine((pageList.IndexOf(p) + 1) + "." + p.PageName);
                }
                Console.WriteLine((pageList.Count + 1) + "." + PreviousPage.PageName + "(Previous Page)");

                int choice = consolereader.getint("");
                if (choice > 0 && choice <= pageList.Count)
                {
                    pageList[choice - 1].Menu();
                    ShowMenu(true);

                }
                else if (choice == pageList.Count + 1)
                {
                    PreviousPage.ShowPageName();
                    PreviousPage.Menu();
                }
                else
                {
                    Console.WriteLine("Try Again..");
                    ShowMenu(true);
                }
            }
        }
        string filepath;
        public bool LoginPage()
        {
           // Console.Clear();
            bool success = false;
            OutResponse<List<bool>> res = new OutResponse<List<bool>>();
            Agent agent = new Agent();
            agent.Username = consolereader.getstring("Enter UserName");
            agent.Password = consolereader.getstring("Enter Password");
            //Console.WriteLine("Enter UserName");
            //agent.Username = Console.ReadLine();

            //Console.WriteLine("Enter Password");
            //agent.Password = Console.ReadLine();

            using (HttpClient client = new HttpClient())
            {
               var response =  client.PostAsJsonAsync("https://localhost:44372/Api/Agent",agent)
                    .Result.Content.ReadFromJsonAsync<OutResponse<bool>>().Result;
                success = response.ResData;
            }
            return success;
        }
//        {
//  "Username": "Owais",
//  "Password": "123456"
//}

    public void Title()
        {
            string s = "";
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Ajay_ServicePin.txt";
            if (File.Exists(filepath))
            {
                s = File.ReadAllText(filepath);
            }
            if (s != "" || s != null)
            {
                string[] sarray = s.Split('=');
                Service_Branch_id = Convert.ToInt32(sarray[1]);
                using (HttpClient client = new HttpClient())
                {
                    OutResponse<List<ServiceBranchId>> res = client.GetFromJsonAsync<OutResponse<List<ServiceBranchId>>>("https://localhost:44372/Api/ServiceProvider/" + Service_Branch_id).Result;
                    foreach (ServiceBranchId item in res.ResData)
                    {
                        Console.WriteLine("Welcome To Agent Login For " + item.CompanyName + " Of " + item.BranchName + " Branch");

                    }
                }
            }
        }


    }
}
