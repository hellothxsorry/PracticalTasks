using PracticalTasks.Receiver;

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

            int i = 1;
            foreach(var car in currentList)
            {
                Console.WriteLine($"{i}. {car.Model}\n");
                i++;
            }
            Console.WriteLine($"Total number of all cars: {totalCarNumber}\n" +
                $"----- ----- ----- ----- ----- ----- ----- ----- ----- -----\n");
        }
    }
}
