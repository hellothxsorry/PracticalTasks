using PracticalTasks.Receiver;

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

            int i = 1;
            foreach (var brand in brandListWithMean)
            {
                Console.WriteLine($"{i}. {brand.Brand} is: ${brand.Avg}\n");
                i++;
            }
            Console.WriteLine($"----- ----- ----- ----- ----- ----- ----- ----- ----- -----\n");
        }
    }
}
