using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace StoreDatabaseAPI.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int StoreId { get; set; }

    public string ProductName { get; set; } = null!;

    public int CategoryId { get; set; }

    public decimal ProductUnitPrice { get; set; }

    public short ProductUnitsInStock { get; set; }

    public bool ProductOnSell { get; set; }

    public string? ProductImage { get; set; }

    public virtual ProductCategory Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

    public virtual Store Store { get; set; } = null!;

    public static implicit operator Product(ActionResult<Product> v)
    {
        throw new NotImplementedException();
    }
}
