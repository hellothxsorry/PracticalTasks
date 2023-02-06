using PracticalTasks.Model;
using PracticalTasks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PracticalTasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServerInstance server = ServerCreator.WithSetupFromProperty();
            Console.WriteLine(server.NumberOfGpu);
        }
    }
}
