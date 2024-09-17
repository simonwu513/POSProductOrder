using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_using_HttpClient
{
    public partial class Store
    {
        public int StoreId { get; set; }

        public string StoreName { get; set; }

        public string StoreAddressCity { get; set; } 

        public string StoreAddressDistrict { get; set; }

        public string StoreAddressDetails { get; set; } 

        public string StoreAddressMemo { get; set; }

        public string StorePhoneNumber { get; set; } 

        public string StoreImage { get; set; } 

        public bool StoreUniformInvoiceVia { get; set; }

        public string StoreAccountNumber { get; set; } 

        public string StorePassword { get; set; }

        public DateTime StoreSetTime { get; set; }

        public byte StoreOrderStatus { get; set; }

        public byte StoreOnService { get; set; }

        public DateTime? StoreEndServiceTime { get; set; }

        public bool StoreLinePay { get; set; }

       
    }
}
