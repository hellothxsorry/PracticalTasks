using PracticalTasks.Commands;
using PracticalTasks.Receiver;

namespace PracticalTasks
{
    public class Program
    {
        private static MenuOptions menu;

        static void Main(string[] args)
        {
            var carsRepository = SingletonRepository.Instance;
            ICommand countBrandsCommand = new CountBrandsCommand(carsRepository);
            ICommand countCarNumberCommand = new CountTotalCarNumberCommand(carsRepository);
            ICommand displayAverageBrandPriceCommand = new DisplayAverageCarPriceByBrandCommand(carsRepository);
            ICommand displayAverageCarPriceCommand = new DisplayAverageCarPriceCommand(carsRepository);

            menu = new MenuOptions(countBrandsCommand, countCarNumberCommand, displayAverageBrandPriceCommand,
                displayAverageCarPriceCommand, carsRepository);

            Console.WriteLine($"Currently the list of cars is empty. Please add some cars first by following the steps below.\n");
            ShowMenuOptions();    
        }

        private static void ShowMenuOptions()
        {
            uint getUserInput;

            Console.WriteLine("1. ADD CAR\n2. SHOW NUMBER OF BRANDS\n3. SHOW TOTAL NUMBER OF ALL CARS" +
                "\n4. SHOW AVERAGE COST OF EACH BRAND\n5. SHOW AVERAGE COST OF CAR\n6. CLOSE CONSOLE");
            while (!UInt32.TryParse(Console.ReadLine(), out getUserInput) || getUserInput < 1 || getUserInput > 6)
            {
                Console.WriteLine($"Please enter a number from 1 to 6 to choose an option from the menu.");
            }

            Console.Clear();
            menu.DisplayAll();
            switch (getUserInput)
            {
                case 1:
                    menu.ChooseCreateNewCar();
                    break;
                case 2:
                    menu.ChooseBrandsNumber();
                    break;
                case 3:
                    menu.ChooseTotalCarNumber();
                    break;
                case 4:
                    menu.ChooseAverageBrandPrice();
                    break;
                case 5:
                    menu.ChooseAverageCarPrice();
                    break;
                default:
                    menu.ChooseExitConsoleApp();
                    break;
            }
            ShowMenuOptions();
        }
    }
}
