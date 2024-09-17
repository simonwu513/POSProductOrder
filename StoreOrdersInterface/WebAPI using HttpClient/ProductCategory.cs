using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace WebAPI_using_HttpClient
{
    public class ProductCategory
    {
        public int CategoryId { get; set; }

        public int StoreId { get; set; }

        public string CategoryName { get; set; }

        public bool CategoryOnDelete { get; set; }

    }
}
