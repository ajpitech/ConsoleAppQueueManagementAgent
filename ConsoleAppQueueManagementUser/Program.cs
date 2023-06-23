using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppQueueManagementAgent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Page m = new MainMenu(null);
            
            do
            {
                Console.Clear();
                m.Title();
                m.Menu();
                Console.ReadLine();
            } while (true);
        }
    }
}
