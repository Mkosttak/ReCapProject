using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:ICarDal
    {
        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
                //DbSet Car sınıfını yani Cars Tablosunu seç, predicate ifadeyi uygula gelen kaydı(record) döndür.
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                return filter == null // filtre null mı?
                    ? context.Set<Car>().ToList() // null ise DbSet Car sınıfını yani Cars Tablosunu seç, liste olarak döndür
                    : context.Set<Car>().Where(filter).ToList(); // null değil ise DbSet Car sınıfını yani Cars Tablosunu seç,
                // filtreyi yani predicate, lamda ifadesini koşulunu sağlayanları seç(Where), listede topla ve döndür

            }
        }

        public void Add(Car entity)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var addedCar = context.Entry(entity); // Referansı bul
                addedCar.State = EntityState.Added; // İşlemi ayarla
                context.SaveChanges(); // Kaydet
            }
        }

        public void Update(Car entity)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var updatedCar = context.Entry(entity); // Referansı bul
                updatedCar.State = EntityState.Modified; // İşlemi ayarla
                context.SaveChanges(); // Kaydet
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var deletedCar = context.Entry(entity);
                deletedCar.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
