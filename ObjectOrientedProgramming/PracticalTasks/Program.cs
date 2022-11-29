namespace PracticalTasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Passenger Car
            Engine passengerCarEngine = new Engine(power: 300, volume: 3.5, type: "V6", serial: "D100928E01");
            Chassis passengerCarChassis = new Chassis(wheelsNumber:4, vINumber:"JT152EEA100302159", permissibleLoad:420);                       
            Transmission passengerCarTransmission = new Transmission(type: "Automatic", numberOfGears:6, manufacturer: "Aisin-Warner");

            Vehicle passengerCar = new Vehicle("Passenger Car", passengerCarEngine, passengerCarChassis, passengerCarTransmission);
            #endregion

            #region Truck
            Engine truckEngine = new Engine(power: 450, volume: 5, type: "V8", serial: "580307R155355");
            Chassis truckChassis = new Chassis(wheelsNumber: 4, vINumber: "JN3MS37A9PW202929", permissibleLoad: 1500);                     
            Transmission truckTransmission = new Transmission(type:"Automatic", numberOfGears:10, manufacturer: "Ford Motor Company");

            Vehicle truck = new Vehicle("Truck", truckEngine, truckChassis, truckTransmission);
            #endregion

            #region Bus
            Engine busEngine = new Engine(power: 240, volume: 6.7, type: "Diesel", serial: "719179A333791");
            Chassis busChassis = new Chassis(wheelsNumber: 4, vINumber: "CA5RT51R7OS313571", permissibleLoad: 16000);                        
            Transmission busTransmission = new Transmission(type:"Automatic", numberOfGears:4, manufacturer:"Jasper");

            Vehicle bus = new Vehicle("Bus", busEngine, busChassis, busTransmission);
            #endregion

            #region Scooter
            Engine scooterEngine = new Engine(power: 10, volume: 1.5, type: "4-stroke", serial: "005101AA03577");
            Chassis scooterChassis = new Chassis(wheelsNumber: 2, vINumber: "BB9ZQ00C91Y257233", permissibleLoad: 100);                       
            Transmission scooterTransmission = new Transmission(type:"CVT", numberOfGears:0, manufacturer: "Aeon");

            List<Vehicle> vehicles = new List<Vehicle>
            {
                new PassengerCar("Ford", VehicleTypes.PassengerCar, new Engine(300, 3.5, "V6", "D100928E01"),
                    new Chassis(4, "JT152EEA100302159", 420), new Transmission("Automatic", 6, "Aisin-Warner")),
                new Bus("Ford", VehicleTypes.PassengerCar, new Engine(300, 3.5, "V6", "D100928E01"),
                    new Chassis(4, "JT152EEA100302159", 420), new Transmission("Automatic", 6, "Aisin-Warner")),
                new Truck("Ford", VehicleTypes.PassengerCar, new Engine(300, 3.5, "V6", "D100928E01"),
                    new Chassis(4, "JT152EEA100302159", 420), new Transmission("Automatic", 6, "Aisin-Warner")),
                new Scooter("Ford", VehicleTypes.PassengerCar, new Engine(300, 3.5, "V6", "D100928E01"),
                    new Chassis(4, "JT152EEA100302159", 420), new Transmission("Automatic", 6, "Aisin-Warner"))
            }

            foreach(v in vehicles)
            {
                v.InformationOutput();
            }
        }
    }
}