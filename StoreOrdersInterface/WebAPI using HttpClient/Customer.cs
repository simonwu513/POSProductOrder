using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_using_HttpClient
{
    public  class Customer
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerCellPhone { get; set; }

        public string CustomerLocalPhone { get; set; }

        public string CustomerAddressCity { get; set; }

        public string CustomerAddressDistrict { get; set; }

        public string CustomerAddressDetails { get; set; }

        public string CustomerAddressMemo { get; set; }

        public string CustomerEinvoiceNumber { get; set; }


    }
}
