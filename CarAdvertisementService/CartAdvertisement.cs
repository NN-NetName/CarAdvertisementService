using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdvertisementService
{
    public class CarAdvertisement
    {
        public int Price { get; }

        public CarAdvertisement(int price)
        {
            Price = price;
        }
    }
}
