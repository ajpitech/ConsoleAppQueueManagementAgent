using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppQueueManagementAgent
{
    internal  class consolereader
    {
       public static DateTime getdate(string s)
        {
            do
            {
                Console.WriteLine(s);
                string date = Console.ReadLine();
                bool isdate = DateTime.TryParse(date, out DateTime n);
                if (isdate)
                {
                    return n;
                }
                else
                {
                    Console.WriteLine("Please valid date.Try again");
                }
            } while (true);
        }
        public static int getint(string s)
        {
            do
            {
                Console.WriteLine(s);
                string number = Console.ReadLine();
                bool isnumber = int.TryParse(number, out int n);
                if (isnumber)
                {
                    return n;
                }
                else
                {
                    Console.WriteLine("Invalid number.");
                }
            } while (true);
        }
        public static float getfloat(string s)
        {
            do
            {
                Console.WriteLine(s);
                string number = Console.ReadLine();
                bool isnumber = float.TryParse(number, out float n);
                if (isnumber)
                {
                    return n;
                }
                else
                {
                    Console.WriteLine("Invalid number.");
                }
            } while (true);
        }

        public static string  getstring(string s)
        {
            do
            {
                Console.WriteLine(s);
                string str= Console.ReadLine();
                if (!string.IsNullOrEmpty(str.ToString()))
                {

                    return str;

                }
                else
                {
                    Console.WriteLine("Invalid contain.");
                }
            } while (true);
        }


        public static bool getbool(string s)
        {
            do
            {
                Console.WriteLine(s);
                string str = Console.ReadLine();
                if (!string.IsNullOrEmpty(str.ToString()))
                {
                    str = str.ToUpper();
                    if (str == "Y")
                    {
                        return true;
                    }
                    else if (str == "N")
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid contain.");
                }
            } while (true);
        }

        public static bool exitmethod()
        {
            do
            {
                Console.Write("Do You Want To Continue? Y/N ");
                string res = Console.ReadLine();

                if (!string.IsNullOrEmpty(res.ToString()))
                {
                    if (res.Length == 1)
                    {
                        res = res.ToUpper();
                        if (res == "Y")
                        {
                            return true;
                        }
                        else if (res == "N")
                        {
                            return false;
                        }
                        else
                        {
                            Console.Write("Plese enter respone in Y or N. ");
                            Console.ReadLine();
                        }


                    }
                    else
                    {
                        Console.Write("Plese enter respone in Y or N. any one charater only. ");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.Write("Plese enter proper respone in Y or N. ");
                    Console.ReadLine();
                }

            } while (true);


        }
        public static String suffics(int n)
        {
            int i = n % 10;
            int j = n % 100;
            if (i == 1 && j != 11)
            {
                return "st";
            }
            else if (i == 2 && j != 12)
            {
                return "nd";
            }
            else if (i == 3 && j != 13)
            {
                return "rd";
            }
            else
            {
                return "th";
            }
        }
    }
}
