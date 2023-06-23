using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using ConsoleAppQueueManagementUser;
using System.Net.Http;
using System.Net.Http.Json;

namespace ConsoleAppQueueManagementAgent
{
    internal class MainMenu : Page
    {
        public MainMenu(Page previous)
        {
            PageName = "MainMenu";
            PreviousPage = this;
            //pageList = new List<Page>();

            pageList.Add(new GetAnswers(this));
            pageList.Add(new ServingStatus(this));
            pageList.Add(new ExitPage(this));
        }
       
       
    }
}

