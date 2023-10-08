using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CodeDrivers
{
    internal class CarInventoryEditor : ICarEditor
    {
        private List<Car> CarInventory; 

        public CarInventoryEditor(List<Car> carInventory) 
        { 
          CarInventory = carInventory;
        } 

        private Car FindById(int id, out string message)
        {
            Car result = CarInventory.Find(car => car.Id == id);

            if(result != null)
            {
                message = $"Product with {id} was found";
            }
            else
            {
                message = $"Product with {id} was not found";
            }

            return CarInventory.Find(car => car.Id == id);
        }

        public bool EditBrand(int id, string brand)
        {
            Car sarchResult = FindById(id);

            if (sarchResult != null) { 
                // ustawianie marki
                return true;
            }
            return false;
        }

        public bool EditCategory(int id, string category)
        {
            throw new NotImplementedException();
        }

        public bool EditFuelType(int id, string fuelType)
        {
            throw new NotImplementedException();
        }

        public bool EditGearType(int id, GearType newGearType, out string errorMessage)
        {
            
            Car sarchResult = FindById(id,out errorMessage);

            if (sarchResult != null)
            {
                // ustawianie typu skrzyni 
                return true;
            }
            return false;

        }

        public bool EditModel(int id, string model)
        {
            throw new NotImplementedException();
        }

        public bool EditMotorPower(int id, int newMotorPower, out string errorMessage)
        {
            Car sarchResult = FindById(id, out errorMessage);

            if (sarchResult != null && newMotorPower > 0)
            {
                
                return true;
            }
            if(newMotorPower <=0)
            {
                errorMessage = "Motor power has to be greater than 0"; 
            }
            return false;
        }

        public bool EditMotorType(int id, MotorType newMotorType, out string errorMessage)
        {
            Car existingCar = FindById(id, out errorMessage);

            if (existingCar != null)
            {
                // ustawianie typu silnika 
                return true;
            }
            return false;

        }

        public bool EditPrice(int id, decimal newPrice)
        {
            throw new NotImplementedException();
        }
    }
}
