using PracticalTasks.Receiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks.Commands
{
    public class CountBrandsCommand : ICommand
    {
        private SingletonRepository carsRepository;

        public CountBrandsCommand(SingletonRepository carsRepository)
        {
            this.carsRepository = carsRepository;
        }

        public void Execute()
        {
            var currentList = carsRepository.GetCarsListInfo();
            var brandsListWithoutDuplicate = currentList.GroupBy(x => x.Brand).Select(y => y.First()).ToList();
            var brandsNumber = brandsListWithoutDuplicate.Count();

            Console.Clear();

            for (int i = 0; i < brandsNumber; i++)
            {
                Console.WriteLine($"{i + 1}. {brandsListWithoutDuplicate[i].Brand}\n");
            }
            Console.WriteLine($"Total number of brands: {brandsNumber}\n" +
                $"----- ----- ----- ----- ----- ----- ----- ----- ----- -----\n");
            
        }
    }
}
