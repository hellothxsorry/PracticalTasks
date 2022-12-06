using System;
using System.Diagnostics;

namespace PracticalTasks
{
    public class PassengerCar: Vehicle
    {
        private int _distributorCode;
        private double _maxSpeed;
        private string _supplier;

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

        public PassengerCar(string name, int distributorCode, string supplier, 
            double maxSpeed, Engine engine, Chassis chassis, Transmission transmission) 
        {
            _name = name;
            _distributorCode = distributorCode;
            _supplier = supplier;
            _maxSpeed = maxSpeed;
            _engine = engine;
            _chassis = chassis;
            _transmission = transmission;
        }

        public override void InformationOutput()
        {
            Debug.Assert(_distributorCode > 0, "Distributor code cannot have a negative number nor zero.");
            Debug.Assert(_maxSpeed > 60, "Maximum speed cannot be less than sixty km per hour.");
            Debug.Assert(_engine.Power > 0, "Engine power cannot be negative nor being equal to zero.");
            Debug.Assert(_engine.Volume > 0, "Engine volume must be a positive number.");
            Debug.Assert(_chassis.WheelsNumber >= 4, "Bus cannot have less than four wheels.");

            Console.WriteLine($"Type of vehicle: {_name} | Distributor code: {_distributorCode} | " +
                $"Supplier: {_supplier}\nEngine power: {_engine.Power} horsepower | " +
                $"Maximum speed: {_maxSpeed} km/h | Engine volume: {_engine.Volume}L\n" +
                $"Engine type: {_engine.Type} | Engine serial number: {_engine.SerialNumber}\n" +
                $"Number of wheels: {_chassis.WheelsNumber} | The VIN (Vehicle Identification Number): " +
                $"{_chassis.VINumber} | Loading capacity: {_chassis.PermissibleLoad} kg\n" +
                $"Transmission type: {_transmission.Type} | Number of gears: {_transmission.NumberOfGears} " +
                $"| Transmission manufacturer: {_transmission.Manufacturer}\n");
        }
    }

    public enum FuelType
    {
        Gas,
        Electricity
    }
}