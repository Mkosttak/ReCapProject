﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal; // Veri erişim yöntemlerinin her birini tutabilecek referans
        public CarManager(ICarDal iCarDal)
        { // Oluşturma anında bir veri erişim yöntemi istiyor.
            _carDal = iCarDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("The car description must contain at least two characters!\n" +
                                  "The daily price of the car must be greater than zero!");
            }

        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(c => c.CarId == carId);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
            }
            else
            {
                Console.WriteLine("The car description must contain at least two characters!/n" +
                                  "The daily price of the car must be greater than zero!");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }
    }
}
