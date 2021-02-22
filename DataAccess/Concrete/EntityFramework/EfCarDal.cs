using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,ReCapDbContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDbContext context=new ReCapDbContext())
            {
                var result = from c in context.Cars // Cars tablosunu seç
                    join b in context.Brands // Brands tablosu ile birleştir, ilişkisel verileri varsa
                        on c.BrandId equals b.BrandId
                    join d in context.Colors // Colors tablosu ile birleştir, ilişkisel verileri varsa
                        on c.ColorId equals d.ColorId
                    select new CarDetailDto() // Aracın özelliklerini göstermek için oluşturularn veri aktarım objesine hangi tablonun hangi kısmı kullanılacaksa ata
                    {
                        Description = c.Description,
                        BrandName = b.BrandName,
                        ColorName = d.ColorName,
                        DailyPrice = c.DailyPrice
                    };

                return result.ToList(); 
            }
        }
    }
}
