using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            

            // Test of EfCarDal
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("--------------------------");

            foreach (var car in carManager.GetCarsByColorId(4))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("--------------------------");

            foreach (var car in carManager.GetCarsByBrandId(5))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("---------------------------");

            Car addcar = new Car()
            {
                BrandId=2,
                ColorId = 7,
                DailyPrice = 12500,
                ModelYear ="2018",
                Description = "Sprinter"
            };
            carManager.Add(addcar);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("------------------------------");
            
            addcar.Description = "GLA";
            carManager.Update(addcar);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("------------------------------");

            carManager.Delete(addcar);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }

    }
}
