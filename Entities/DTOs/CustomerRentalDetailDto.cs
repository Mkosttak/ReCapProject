using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CustomerRentalDetailDto:IDto
    {
        public int CustomerId { get; set; }
        public int RentalId { get; set; }
        public int UserId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }

}
