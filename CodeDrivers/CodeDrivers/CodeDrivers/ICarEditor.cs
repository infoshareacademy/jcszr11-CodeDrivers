using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers
{
    internal interface ICarEditor
    {
        public bool EditBrand(int id, string brand);
        public bool EditModel(int id, string model);
        public bool EditCategory(int id, string category);
        public bool EditFuelType(int id, string fuelType);
        public bool EditPrice(int id, decimal newPrice);
        public bool EditMotorPower(int id, int newMotorPower);
        public bool EditGearTYpe(int id, string newGearType);
        public bool EditMotorType(int id, string newMotorType);

    }
}
