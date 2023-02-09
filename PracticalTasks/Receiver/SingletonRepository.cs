namespace PracticalTasks.Receiver
{
    public class SingletonRepository
    {
        private List<Car> cars;

        private SingletonRepository()
        {
            cars = new List<Car>();
        }       

        public void AddCar(Car newCar)
        {
            cars.Add(newCar);
        }

        public List<Car> GetCarsListInfo()
        {
            return cars;
        }

        private static readonly Lazy<SingletonRepository> instance =
            new Lazy<SingletonRepository>(() => new SingletonRepository());

        public static SingletonRepository Instance => instance.Value;
    }
}
