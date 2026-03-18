using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AbstractClassPolymorphismForEach.Models
{
    public class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string PlateNumber { get; set; }
        public double FuelLevel { get; set; }

        public Vehicle(string brand, string model, int year, string plateNumber)
        {
            this.Brand = brand;
            this.Model = model;
            this.Year = year;
            this.PlateNumber = plateNumber;
            this.FuelLevel = 100;
        }

        public string GetVehicleInfo()
        {
            return $"{Year} {Brand} {Model} (Plate: {PlateNumber})";
        }

        public void ShowBasicInfo()
        {
            Console.WriteLine($"Vehicle: {GetVehicleInfo()}, Fuel: {FuelLevel}%");
        }
    }
}
