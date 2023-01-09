using PracticalTasks.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks.Commands
{
    public class CountTotalCarNumberCommand : ICommand
    {
        private SingletonRepository carsRepository;

        public CountTotalCarNumberCommand(SingletonRepository carsRepository)
        {
            this.carsRepository = carsRepository;
        }

        public void Execute()
        {
            var currentList = carsRepository.GetCarsListInfo();
            var totalCarNumber = currentList.Count();

            Console.Clear();

            for (int i = 0; i < totalCarNumber; i++)
            {
                Console.WriteLine($"{i + 1}. {currentList[i].Model}\n");
            }
            Console.WriteLine($"Total number of all cars: {totalCarNumber}\n" +
                $"----- ----- ----- ----- ----- ----- ----- ----- ----- -----\n");
        }
    }
}
