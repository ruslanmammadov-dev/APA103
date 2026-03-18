using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AbstractClassPolymorphismForEach.Models
{
    public class Truck : Vehicle
    {
        public double CargoCapacity { get; set; }
        public int AxleCount { get; set; }
        public double CurrentLoad { get; set; }
        public int MaxSpeed { get; set; }

        public Truck(string brand, string model, int year, string plateNumber, double capacity, int axles, double currentLoad, int maxSpeed) : base(brand, model, year, plateNumber)
        {
            this.CargoCapacity = capacity;
            this.AxleCount = axles;
            this.CurrentLoad = currentLoad;
            this.MaxSpeed = maxSpeed;
        }

        public void ShowTruckInfo()
        {
            Console.WriteLine($"[TRUCK] {GetVehicleInfo()}  Axles: {AxleCount}, Load: {CurrentLoad}/{CargoCapacity} ton, Max Speed: {MaxSpeed} km/h");
        }

        public void LoadCargo(double weight)
        {
            if (CurrentLoad + weight <= CargoCapacity)
            {
                CurrentLoad += weight;
                Console.WriteLine($"{weight} ton yuk elave edildi. Cari yuk: {CurrentLoad} ton.");
            }
            else
            {
                Console.WriteLine("XETA: Yuk tutumu asildi!");
            }
        }

        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * (25 + CurrentLoad * 2) * 1.80;
        }
    }
}
