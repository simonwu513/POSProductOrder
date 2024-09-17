using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreDatabaseAPI.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace StoreDatabaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly StoreManagementPlatformContext _context;
        private readonly ILogger<SalesController> _logger;

        public SalesController(StoreManagementPlatformContext context, ILogger<SalesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("ProductCategories/storeId={storeId}")]

        public async Task<List<string>> GetProductCategoryListPerStore(int storeId)
        {
            var result = _context.ProductCategories.Where(q => q.StoreId == storeId);

            if (result != null && await result.AnyAsync())
            {
                return await result.Select(q => $"{q.CategoryId}:{q.CategoryName}").ToListAsync();
            }
            else
            {
                _logger.LogWarning($"No product category found for storeId={storeId}");

                // 返回空列表
                return null;
            }
        }

        [HttpGet("Products/storeId={storeId}/categoryId={categoryId}")]

        public async Task<List<Product>> GetProductsPerProductCategory(int storeId, int categoryId)
        {
            var result = _context.Products.Where(q => q.StoreId == storeId && q.CategoryId == categoryId);

            if (result != null && await result.AnyAsync())
            {
                return await result.ToListAsync();
            }
            else
            {
                _logger.LogWarning($"No products found for product category={categoryId}");

                // 返回空列表
                return new List<Product>();
            }
        }

        [HttpGet("ProductCategory/{categoryId}")]
        public async Task<ActionResult<ProductCategory>> GetProductCategory(int categoryId)
        {
            var productCategory = await _context.ProductCategories.FindAsync(categoryId);

            if (productCategory == null)
            {
                return NotFound(); // HTTP 404
            }

            return Ok(productCategory);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product == null)
            {
                return NotFound(); // HTTP 404
            }

            return Ok(product);
        }

        // 理論上每家店應有不同客戶群，這邊假設平台共用所有客戶群
        [HttpGet("Customers/{StoreId}")]
        public async Task<ActionResult<List<Customer>>> GetCustomers(int StoreId)
        {
            var customers = await _context.Customers.ToListAsync();

            if (customers == null || customers.Count == 0)
            {
                return NotFound(); // HTTP 404

            }
            return Ok(customers);
        }

        [HttpGet("Store/{StoreId}")]
        public async Task<ActionResult<List<Customer>>> GetStoreInfo(int StoreId)
        {
            var store = await _context.Stores.Where(x => x.StoreId == StoreId).SingleOrDefaultAsync();

            if (store == null )
            {
                return NotFound(); // HTTP 404

            }
            return Ok(store);
        }

        // List<int[]>ProudctSales
        // int[]: productId, price, quantity, categoryId
        [HttpPut]
        public async Task<ActionResult<OrderAndDetailsResponse>> Orders(List<int[]> ProductSales, int customerId, int storeId, string? orderPhoneNumber, bool orderPayment, string? orderStoreMemo, byte uniformInvoiceVia, string? einvoiceNumber )
        {
            if (ProductSales == null || ProductSales.Count == 0)
            {
                return BadRequest();
            }

            foreach (int[] proudctSales in ProductSales)
            {
                int productId = proudctSales[0];
                int quantity = proudctSales[2];


                Product product = await _context.Products.FindAsync(productId);

                if (product == null)
                {
                    var errorResponse = new ErrorMessages();
                    errorResponse.Message = $"Product {productId} not found.";
                    return BadRequest(errorResponse); // HTTP 400
                }

                if (product.ProductUnitsInStock - quantity < 0)
                {
                    var errorResponse = new ErrorMessages();
                    errorResponse.Message = $"Product {product.ProductName} is out of stock.";
                    return BadRequest(errorResponse); // HTTP 400
                }
                

            }

            DateTime now = DateTime.Now;
            int orderTotalAmount = 0;
          
            Order order = new Order();
            order.OrderTime = new DateTime( now.Year,now.Month, now.Day, now.Hour,now.Minute,0);
            order.CustomerId = customerId;
            order.StoreId = storeId;
            order.OrderDeliveryVia = false; // 現場點餐，不提供送貨服務
            order.OrderPhoneNumber = orderPhoneNumber; // 客戶可不提供電話
            order.OrderPayment = orderPayment;
            order.OrderUniformInvoiceVia = uniformInvoiceVia;
            order.OrderEinvoiceNumber = einvoiceNumber ?? ""; // 電子發票號碼，若客戶未提供，則為空字串
            order.OrderStoreMemo = orderStoreMemo;
            
            order.CustomerOrderStatus = 3; // 現場點餐，視作已完成

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();


            List<OrderDetailView> odvs = new List<OrderDetailView>();
            foreach (int[] proudctSales in ProductSales)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderId = order.OrderId; // 取得新增的訂單編號
                orderDetail.ProductId = proudctSales[0];
                orderDetail.UnitPrice = proudctSales[1];
                orderDetail.Quantity = (short)proudctSales[2];
                
                orderTotalAmount += proudctSales[1] * proudctSales[2];

                _context.OrderDetails.Add(orderDetail);
                await _context.SaveChangesAsync();

                odvs.Add(new OrderDetailView
                {
                    OrderId = order.OrderId,
                    ProductId = orderDetail.ProductId,
                    UnitPrice = orderDetail.UnitPrice,
                    Quantity = orderDetail.Quantity
                });
            }


            OrderView ov = new OrderView
            {
                OrderId = order.OrderId,
                OrderTime = order.OrderTime,
                CustomerId = order.CustomerId,
                StoreId = order.StoreId,
                OrderDeliveryVia = order.OrderDeliveryVia,
                OrderPhoneNumber = order.OrderPhoneNumber,
                OrderPayment = order.OrderPayment,
                OrderStoreMemo = order.OrderStoreMemo,
                CustomerOrderStatus = order.CustomerOrderStatus,
                OrderUniformInvoiceVia = order.OrderUniformInvoiceVia,
                OrderEinvoiceNumber = order.OrderEinvoiceNumber,
                OrderTotalAmount = orderTotalAmount
                
            };

            OrderAndDetailsResponse response = new OrderAndDetailsResponse
            {
                OrderView = ov,
                OrderDetails = odvs
            };
 

            return Ok(response);

        }

    }
}
