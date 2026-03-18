using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AbstractClassPolymorphismForEach.Models
{
    public class Motorcycle : Vehicle
    {
        public int EngineCapacity { get; set; }
        public bool HasSidecar { get; set; }
        public int MaxSpeed { get; set; }
        public string Type { get; set; }

        public Motorcycle(string brand, string model, int year, string plateNumber, int engine, bool sidecar, int maxSpeed, string type) : base(brand, model, year, plateNumber)
        {
            this.EngineCapacity = engine;
            this.HasSidecar = sidecar;
            this.MaxSpeed = maxSpeed;
            this.Type = type;
        }

        public void ShowMotorcycleInfo()
        {
            Console.WriteLine($"[MOTO] {GetVehicleInfo()}  Type: {Type}, Engine: {EngineCapacity}cc, Sidecar: {HasSidecar}, Max Speed: {MaxSpeed} km/h");
        }

        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * 4 * 1.50;
        }
    }
}
