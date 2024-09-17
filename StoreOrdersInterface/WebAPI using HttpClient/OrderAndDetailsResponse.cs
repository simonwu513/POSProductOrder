using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_using_HttpClient
{

        public partial class OrderAndDetailsResponse
        {
            public OrderView OrderView { get; set; }
            public List<OrderDetailView> OrderDetails { get; set; }
        }

        public partial class OrderView
        {
            public int OrderId { get; set; }

            public int CustomerId { get; set; }

            public int StoreId { get; set; }

            public DateTime OrderTime { get; set; }

            public bool OrderDeliveryVia { get; set; }

            public string OrderPhoneNumber { get; set; }

            public string OrderStoreMemo { get; set; }

            public byte OrderUniformInvoiceVia { get; set; }

            public string OrderEinvoiceNumber { get; set; }

            public bool OrderPayment { get; set; }

            public byte CustomerOrderStatus { get; set; }

            public int OrderTotalAmount { get; set; }

        }

        public partial class OrderDetailView
        {

            public int OrderId { get; set; }

            public int ProductId { get; set; }

            public decimal UnitPrice { get; set; }

            public short Quantity { get; set; }

        }
    }

