using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_assignment
{
    //public interface ILogger
    //{
    //    void Log(string message);
    //    void Log(IEnumerable<string> messages);
    //}

    public static class Logger
    {
        public static void Log(string message)
        {
           Console.WriteLine(message);
        }

        public static void Log(IEnumerable<string> messages)
        {
            foreach (var message in messages)
            {
                Console.WriteLine(message);
            }
        }
    }
}
