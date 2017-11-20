using System;

namespace HouseKeeper2.Controllers.Api
{
    public class ServiceBillDto
    {
        public int ServiceId { get; set; }
        public int TariffId { get; set; }
        public DateTime Period { get; set; }
        public int Measurement { get; set; }

    }
}