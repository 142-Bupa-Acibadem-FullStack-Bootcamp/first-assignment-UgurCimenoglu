using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.Entity.Dto
{
    public partial class DtoSalesTotalsByAmount
    {
        public decimal? SaleAmount { get; set; }
        public int OrderId { get; set; }
        public string CompanyName { get; set; }
        public DateTime? ShippedDate { get; set; }
    }
}
