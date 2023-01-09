using PracticalTasks.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks.Commands
{
    public class DisplayAverageCarPriceCommand : ICommand
    {
        private SingletonRepository carsRepository;

        public DisplayAverageCarPriceCommand(SingletonRepository carsRepository)
        {
            this.carsRepository = carsRepository;
        }

        public void Execute()
        {
            var currentList = carsRepository.GetCarsListInfo();
            try
            {
                var averagePrice = currentList.Average(x => x.Price);

                Console.Clear();

                Console.WriteLine($"The average cost of the car: ${averagePrice}\n" +
                    $"\n----- ----- ----- ----- ----- ----- ----- ----- ----- -----\n");
            }
            catch
            {
                Console.WriteLine("The list is empty. Please add some cars before proceeding with any of commands.");
                return;
            }
        }
    }
}