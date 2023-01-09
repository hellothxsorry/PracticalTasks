using PracticalTasks.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks.Commands
{
    public class DisplayAverageCarPriceByBrandCommand : ICommand
    {
        private SingletonRepository carsRepository;

        public DisplayAverageCarPriceByBrandCommand(SingletonRepository carsRepository)
        {
            this.carsRepository = carsRepository;
        }

        public void Execute()
        {
            var currentList = carsRepository.GetCarsListInfo();
            var brandListWithMean = currentList.GroupBy(x => x.Brand).Select(y => new { Brand = y.Key, Avg = y.Average(s => s.Price) }).ToList();

            Console.Clear();

            for (int i = 0; i < brandListWithMean.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. The average cost of {brandListWithMean[i].Brand} is: ${brandListWithMean[i].Avg}\n");
            }
            Console.WriteLine($"----- ----- ----- ----- ----- ----- ----- ----- ----- -----\n");
        }
    }
}
