using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AbstractClassPolymorphismForEach.Models
{
    public class Car : Vehicle
    {
        public int DoorsCount { get; set; }
        public int TrunkCapacity { get; set; }
        public bool IsAutomatic { get; set; }
        public int MaxSpeed { get; set; }

        public Car(string brand, string model, int year, string plateNumber, int doors, int trunk, bool isAuto, int maxSpeed) : base(brand, model, year, plateNumber)
        {
            this.DoorsCount = doors;
            this.TrunkCapacity = trunk;
            this.IsAutomatic = isAuto;
            this.MaxSpeed = maxSpeed;
        }

        public void ShowCarInfo()
        {
            Console.WriteLine($"[CAR] {GetVehicleInfo()}  Doors: {DoorsCount}, Trunk: {TrunkCapacity}L, Auto: {IsAutomatic}, Max Speed: {MaxSpeed} km/h");
        }

        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * 8 * 1.50;
        }
    }
}
