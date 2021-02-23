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
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,ReCapDbContext>,ICustomerDal
    {
        public List<CustomerRentalDetailDto> GetCustomerDetails()
        {
            using (ReCapDbContext context=new ReCapDbContext())
            {
                var result = from c in context.Customers
                    join u in context.Users
                        on c.UserId equals u.UserId
                    join r in context.Rentals
                        on c.CustomerId equals r.CustomerId
                    select new CustomerRentalDetailDto
                    {
                        CustomerId = c.CustomerId,
                        UserId = u.UserId,
                        RentalId = r.RentalId,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate
                    };
                return result.ToList();
            }
        }
    }
}
