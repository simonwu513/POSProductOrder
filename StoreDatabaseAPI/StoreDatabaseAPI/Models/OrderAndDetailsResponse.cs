using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDatabaseAPI.Models
{
    public partial class OrderAndDetailsResponse
    {
        public OrderView? OrderView { get; set; }
        public List<OrderDetailView>? OrderDetails { get; set; }
    }

    public partial class OrderView
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int StoreId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime OrderTime { get; set; }

        public bool OrderDeliveryVia { get; set; }

        public string? OrderPhoneNumber { get; set; } = null!;

        public string? OrderStoreMemo { get; set; }

        public byte? OrderUniformInvoiceVia { get; set; }

        public string? OrderEinvoiceNumber { get; set; }

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
