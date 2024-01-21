﻿using CodeDrivers.Models;
using CodeDrivers.Models.Car;
using CodeDriversMVC.Models;
using CodeDrivers.Repository;

namespace CodeDriversMVC.Services
{
    public class CarService
    {
        static int id = 3;
        public static List<Car> cars { get; set; } =
            new List<Car>
            {
                new() {Id=1},
                new() {Id=2},
               
            };
        public List<Car> GetAll()
        {
            return cars;
        }
        public static int SetId()
        {
            return id++;
        }
        public void Update(Car car)
        {
            Car allCars =GetById(car.Id);
            allCars.Brand=car.Brand;
            allCars.Model=car.Model;
            allCars.Segment=car.Segment;
            allCars.GearTransmission=car.GearTransmission;
            allCars.PricePerDay=car.PricePerDay;
            allCars.IsAvailable=true;

        }
        public Car GetById(int id)
        {
            return cars.FirstOrDefault(m => m.Id == id);
        }
        public List<Car> GetByBrand(CarBrand brand)
        {
            return cars.Where(m => m.Brand == brand).ToList();
        }
        public void Create(Car nextCar)
        {
            nextCar.Id = SetId();
            cars.Add(nextCar);
        }
        public void Delete(Car nextCar)
        {
            cars.Remove(nextCar);
        }
        public void RemoveCar(int id)
        {
            for (int i = 0; i < GetAll().Count; i++)
            {
                if (id == GetAll()[i].Id)
                {
                    GetAll().Remove(GetAll()[i]);
                }
            }
        }
    };
}
