namespace PracticalTasks.Receiver
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }

        public Car(string brand, string model, double price)
        {
            Brand = brand;
            Model = model;
            Price = price;
        }
    }
}
