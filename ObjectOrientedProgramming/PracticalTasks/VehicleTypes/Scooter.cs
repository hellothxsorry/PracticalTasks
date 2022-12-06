using System.Diagnostics;

namespace PracticalTasks
{
    public class Scooter: Vehicle
    {
        private FuelType _fuelType;
        private bool _hasCarriage;

        private string _name;
        private Engine _engine;
        private Chassis _chassis;
        private Transmission _transmission;      
        
        public override string VehicleName
        {
            get => _name;
            set => _name = value;
        }

        public override Engine VehicleEngine
        {
            get => _engine;
            set => _engine = value;
        }

        public override Chassis VehicleChassis
        {
            get => _chassis;
            set => _chassis = value;
        }

        public override Transmission VehicleTransmission
        {
            get => _transmission;
            set => _transmission = value;
        }        

        public Scooter(string name, bool hasCarriage, Engine engine, FuelType fuelType, 
            Chassis chassis, Transmission transmission) 
        {
            _name = name;
            _hasCarriage = hasCarriage; 
            _engine = engine;
            _fuelType = fuelType;
            _chassis = chassis;
            _transmission = transmission;
        }

        public override void InformationOutput()
        {
            Debug.Assert(_engine.Power > 0, "Engine power cannot be negative nor zero.");
            Debug.Assert(_engine.Volume > 0, "Engine volume must be a positive number.");
            Debug.Assert(_chassis.WheelsNumber >= 2, "Bus cannot have less than two wheels.");

            Console.WriteLine($"Type of vehicle: {_name} | Includes carriage: {_hasCarriage} | " +
                $"\nEngine power: {_engine.Power} horsepower | Engine volume: {_engine.Volume}L " +
                $"| Fuel type: {_fuelType}\n Engine type: {_engine.Type} " +
                $"| Engine serial number: {_engine.SerialNumber} \n Number of wheels: {_chassis.WheelsNumber} | " +
                $"The VIN (Vehicle Identification Number): {_chassis.VINumber} | Loading capacity: " +
                $"{_chassis.PermissibleLoad} kg \n Transmission type: {_transmission.Type} | Number of gears: " +
                $"{_transmission.NumberOfGears} | Transmission manufacturer: {_transmission.Manufacturer} \n");
        }
    }    
}