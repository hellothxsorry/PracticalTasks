using PracticalTasks.Commands;
using PracticalTasks.Receiver;

namespace PracticalTasks
{
    public class MenuOptions
    {
        private ICommand getBrandsNumberCommand;
        private ICommand getTotalCarNumberCommand;
        private ICommand displayAverageBrandPriceCommand;
        private ICommand displayAverageCarPriceCommand;
        private SingletonRepository carsRepository;

        public MenuOptions(ICommand getBrandsNumber, ICommand getTotalCarNumber, ICommand displayAverageBrandPrice, ICommand displayAverageCarPrice, 
            SingletonRepository carsRepository)
        {
            getBrandsNumberCommand = getBrandsNumber;
            getTotalCarNumberCommand = getTotalCarNumber;
            displayAverageBrandPriceCommand = displayAverageBrandPrice;
            displayAverageCarPriceCommand = displayAverageCarPrice;
            this.carsRepository = carsRepository;
        }

        public void ChooseBrandsNumber() => getBrandsNumberCommand.Execute();
        public void ChooseTotalCarNumber() => getTotalCarNumberCommand.Execute();
        public void ChooseAverageBrandPrice() => displayAverageBrandPriceCommand.Execute();
        public void ChooseAverageCarPrice() => displayAverageCarPriceCommand.Execute();

        public void DisplayAll()
        {
            if (carsRepository.GetCarsListInfo().Count == 0)
            {
                Console.WriteLine("Current list of cars is empty. Let's add the first car.\n");
            }
            else
            {
                Console.WriteLine("Current list of all cars:\n");

                int i = 1;
                foreach (var carInfo in carsRepository.GetCarsListInfo())
                {
                    Console.Write($"{i}. Brand: {carInfo.Brand} | Model: {carInfo.Model} | Price: {carInfo.Price}\n");
                    i++;
                }
                Console.WriteLine("----- ----- ----- ----- ----- ----- ----- ----- ----- -----");
            }            
        }

        public void ChooseCreateNewCar()
        {
            string bufferCarBrand;
            string bufferCarModel;
            uint bufferCarQuantity;
            double bufferCarPrice;

            do
            {
                Console.WriteLine("Please enter a brand name for new car(s):");
                bufferCarBrand = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(bufferCarBrand));

            do
            {
                Console.WriteLine("Please enter a model of the new car(s):");
                bufferCarModel = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(bufferCarModel));

            Console.WriteLine($"Please enter a quantity of this car model you would like to add to the list:");
            while (!UInt32.TryParse(Console.ReadLine(), out bufferCarQuantity) || bufferCarQuantity < 1)
            {
                Console.WriteLine($"Please make sure that you add at least 1 car of this model.");
            }

            Console.WriteLine($"Please enter a price of this model:");
            while (!double.TryParse(Console.ReadLine(), out bufferCarPrice) || bufferCarPrice < 1)
            {
                Console.WriteLine($"Price cannot equal to negative value or zero.");
            }

            for (int i = 0; i < bufferCarQuantity; i++)
            {
                var newCar = new Car(bufferCarBrand, bufferCarModel, bufferCarPrice);
                carsRepository.AddCar(newCar);
            }

            Console.Clear();
            Console.WriteLine($"x{bufferCarQuantity} {bufferCarModel} successfully added to the list!\n");
        }

        public void ChooseExitConsoleApp()
        {
            Environment.Exit(0);
        }        
    }
}
