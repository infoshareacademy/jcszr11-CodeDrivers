using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers
{
    internal class CarInventoryEditor : ICarEditor
    {
        private List<Car> CarInventory; 

        public CarInventoryEditor(List<Car> carInventory) { 
          CarInventory = carInventory;
        } 


        public bool EditBrand(int id, string brand)
        {
            throw new NotImplementedException();
        }

        public bool EditCategory(int id, string category)
        {
            throw new NotImplementedException();
        }

        public bool EditFuelType(int id, string fuelType)
        {
            throw new NotImplementedException();
        }

        public bool EditGearTYpe(int id, string newGearType)
        {
            throw new NotImplementedException();
        }

        public bool EditModel(int id, string model)
        {
            throw new NotImplementedException();
        }

        public bool EditMotorPower(int id, int newMotorPower)
        {
            throw new NotImplementedException();
        }

        public bool EditMotorType(int id, string newMotorType)
        {
            throw new NotImplementedException();
        }

        public bool EditPrice(int id, decimal newPrice)
        {
            throw new NotImplementedException();
        }
    }
}
