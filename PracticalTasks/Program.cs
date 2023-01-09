using PracticalTasks.VehicleParts;

namespace PracticalTasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            var vehicleList = VehicleList.Instance;
            var menu = new MenuOptions(vehicleList);
            vehicleList.ReloadData();  

            GetBackToMenu(menu);
        }

        

        public static void GetBackToMenu(MenuOptions menu)
        {
            Console.WriteLine("1. ADD VEHICLE\n2. EDIT VEHICLE\n3. DELETE VEHICLE\n4. FILTER LIST BY PARAMETER");

            uint action;
            while (!uint.TryParse(Console.ReadLine(), out action) || action == 0 || action > 4)
            {
                Console.WriteLine("Please choose the further action by typing a number from 1 to 3.");
            }

            switch (action)
            {
                case 1:
                    menu.CollectDataForVehicle();
                    menu.CreateNewVehicle();
                    break;
                case 2:
                    menu.UpdateVehicle();
                    break;
                case 3:
                    menu.RemoveVehicle();
                    break;
                default:
                    menu.FilterList();
                    break;
            }

            GetBackToMenu(menu);
        }                    
    }
}
