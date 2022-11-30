using System.Diagnostics;

namespace PracticalTasks
{
    public class Bus: Vehicle
    {
        private BusTypes _busType;
        private int _numOfPassSeats;

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

        public Bus(string name, BusTypes busType, int numOfPassSeats,
            Engine engine, Chassis chassis, Transmission transmission) 
        {
            _name = name;
            _busType = busType;
            _numOfPassSeats = numOfPassSeats;
            _engine = engine;
            _chassis = chassis;
            _transmission = transmission;
        }

        public override void InformationOutput()
        {
            Debug.Assert(_engine.Power > 0, "Engine power cannot be negative nor zero.");
            Debug.Assert(_engine.Volume > 0, "Engine volume must be a positive number.");
            Debug.Assert(_chassis.WheelsNumber >= 4, "Bus cannot have less than four wheels.");
            Debug.Assert(_numOfPassSeats >= 10, "Bus cannot have less than ten seats.");

            Console.WriteLine($"Type of vehicle: {_name} | Bus type: {_busType} | " +
                $"Number of passenger seats: {_numOfPassSeats}\nEngine power: {_engine.Power} horsepower | " +
                $"Engine volume: {_engine.Volume}L | Engine type: {_engine.Type} | Engine serial number: " +
                $"{_engine.SerialNumber} \n Number of wheels: {_chassis.WheelsNumber} | " +
                $"The VIN (Vehicle Identification Number): {_chassis.VINumber} | Loading capacity: " +
                $"{_chassis.PermissibleLoad} kg \n Transmission type: {_transmission.Type} | Number of gears: " +
                $"{_transmission.NumberOfGears} | Transmission manufacturer: {_transmission.Manufacturer} \n");
        }
    }

    public enum BusTypes
    {
        School,
        Public,
        Tourist
    }
}