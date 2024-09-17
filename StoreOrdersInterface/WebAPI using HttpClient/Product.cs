using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace WebAPI_using_HttpClient
{
    public class Product
    {
        public int ProductId { get; set; }

        public int StoreId { get; set; }

        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public decimal ProductUnitPrice { get; set; }

        public short ProductUnitsInStock { get; set; }

        public bool ProductOnSell { get; set; }

        public string ProductImage { get; set; }

    }
}
