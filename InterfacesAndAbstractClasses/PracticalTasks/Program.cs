namespace PracticalTasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            CalculateFlightTime();            
        }        

        static void CalculateFlightTime()
        {
            Bird bird = new Bird();
            Airplane airplane = new Airplane();
            Drone drone = new Drone();
            uint getFlyingObjID;

            IFlyable[] flyObjects = { bird, airplane, drone };
            string[] flyObjsNames = { "Bird", "Airplane", "Drone" };

            Console.WriteLine($"Please choose a flying object from the list below by typing a corresponding number from 1 to 3:" +
            $"\n1. {flyObjsNames[0]}\n2. {flyObjsNames[1]}\n3. {flyObjsNames[2]}");

            while (!UInt32.TryParse(Console.ReadLine(), out getFlyingObjID) || getFlyingObjID < 1 || getFlyingObjID > 3)
            {
                Console.WriteLine($"Must be a number from 1 to 3. Please try again.");
            }

            ProcessSpecificObject(flyObjects[getFlyingObjID - 1]);            
        }

        static void ProcessSpecificObject(IFlyable flyable)
        {
            Coordinate coordinate = new Coordinate();
            string currentPos = "";
            string wrongInputError = "N.B. only integer numbers are allowed. Please try again.";
            int speed = 0;
            bool isAnyRestriction = false;
            uint destX;
            uint destY;
            uint destZ;
            double distance = 0;
            double flightTime = 0;
            Type objType = flyable.GetType();

            coordinate.SetCurrentRandomPosition(flyable);
            currentPos = $"Current position of the {objType.Name}: x = {flyable.startPosX} | " +
                $"y = {flyable.startPosY} | z = {flyable.startPosZ}";

            Console.Clear();
            Console.WriteLine($"Please enter destination coordinates for {objType.Name} in (x, y, z) format." +
                $"\nDestination position: x = [not assignet yet] | y = [not assignet yet] | z = [not assigned yet]\nPlease enter X coordinate first:");
            while (!uint.TryParse(Console.ReadLine(), out destX))
            {
                Console.WriteLine(wrongInputError);
            }

            Console.Clear();
            Console.WriteLine($"{currentPos}\nDestination position: x = {destX} | y = [not assigned yet] | " +
                $"z = [not assigned yet]\nNow please enter Y coordinate:");
            while (!uint.TryParse(Console.ReadLine(), out destY))
            {
                Console.WriteLine(wrongInputError);
            }

            Console.Clear();
            Console.WriteLine($"{currentPos}\nDestination position: x = {destX} | y = {destY} | " +
                $"z = [not assigned yet]\nFinally please enter Z coordinate:");
            while (!uint.TryParse(Console.ReadLine(), out destZ))
            {
                Console.WriteLine(wrongInputError);
            }

            distance = flyable.FlyTo(destX, destY, destZ);

            speed = flyable.speed;
            flightTime = flyable.GetFlyTime(distance);
            isAnyRestriction = flyable.isAnyRestriction;
            
            if (isAnyRestriction)
            {
                CalculateFlightTime();
            }

            Console.Clear();
            Console.WriteLine($"{currentPos}\nDestination position: x = {destX} | y = {destY} | z = {destZ}\nDistance of the path: " +
                $"{String.Format("{0:0.0}", distance)} km\nInitial speed of the {objType.Name}: {speed} km/h");
            if (objType.Name.Equals("Airplane"))
            {
                Console.WriteLine($"Maximum speed: {flyable.speed} km/h");
            }
            Console.WriteLine($"Total flight time of the {objType.Name}: {String.Format("{0:0.0}", flightTime)} hours" +
                $"\n---------------\n");                

            CalculateFlightTime();
        }
    }
}