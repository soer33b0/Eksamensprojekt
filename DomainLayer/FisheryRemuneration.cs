using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class FisheryRemuneration
    {
        public double FishPrice
        {
            get;set;
        }
        public string FishType
        {
            get; set;
        }
        public double FishWeight
        {
            get; set;
        }
        public DateTime SaleDate
        {
            get; set;
        }
        public int CustomerID
        {
            get; set;
        }
    }
}
