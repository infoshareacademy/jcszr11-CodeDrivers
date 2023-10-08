using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers.Models
{
    internal class Car
    {
        // zrobię - Janek
        public int Id { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Segment { get; set; }
        public string GearTransmission { get; set; }
        public bool IsAvailable { get; set; }
    }
}
