using PracticalTasks.Receiver;

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

            int i = 1;
            foreach(var brand in brandsListWithoutDuplicate)
            {
                Console.WriteLine($"{i}. {brand.Brand}\n");
                i++;
            }
            Console.WriteLine($"Total number of brands: {brandsNumber}\n" +
                $"----- ----- ----- ----- ----- ----- ----- ----- ----- -----\n");            
        }
    }
}
