using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,ReCapDbContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapDbContext context=new ReCapDbContext())
            {
                var result = from r in context.Rentals
                    join c in context.Cars on r.CarId equals c.CarId
                    join cu in context.Customers on r.CustomerId equals cu.CustomerId
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join u in context.Users on cu.UserId equals u.UserId 
                    select new RentalDetailDto
                    {
                        RentalId = r.RentalId,
                        BrandName = b.BrandName,
                        CustomerName=u.FirstName,
                        CustomerLastName = u.LastName,
                        CompanyName = cu.CompanyName,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate
                    };
                return result.ToList();
            }
        }
    }
}
