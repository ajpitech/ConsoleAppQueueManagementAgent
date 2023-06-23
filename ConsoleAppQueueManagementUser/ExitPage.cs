using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppQueueManagementAgent
{
    internal class ExitPage:Page
    {
        public ExitPage(Page previous)
        {
            PageName = "Exit Page";
            PreviousPage = previous;
        }
        public override void Menu()
        {
           Environment.Exit(0);
        }
    }
}
