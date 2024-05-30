using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MWDotNetCore.PizzaApi;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWDotNetCore.PizzaApi.Db;

internal class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
    }
    public DbSet<PizzaModel> Pizzas { get; set; }
    public DbSet<PizzaExtraModel> PizzaExtra { get; set; }
    public DbSet<PizzaOrderModel> PizzaOrder { get; set; }
    public DbSet<PizzaOrderDetailModel> PizzaOrderDetail { get; set; }
}

[Table("Tbl_Pizza")]
public class PizzaModel
{
    [Key]

    [Column("PizzaId")]
    public int Id { get; set; }

    [Column("Pizza")]
    public string Name { get; set; }

    [Column("Price")]
    public decimal Price { get; set; }
}

[Table("Tbl_PizzaExtra")]
public class PizzaExtraModel
{
    [Key]

    [Column("PizzaExtraId")]
    public int Id { get; set; }

    [Column("PizzaExtraName")]
    public string Name { get; set; }

    [Column("Price")]
    public decimal Price { get; set; }
    [NotMapped]
    public string PizzaStr { get { return "$" + Price; } }
}

public class OrderRequest
{
    public int PizzaId { get; set; }
    public int[] Extras { get; set; }
  }

public class OrderResponse
{
    public string Message { get; set; }
    public string InvoiceNo { get; set; }
    public decimal TotalAmount { get; set; }
}

[Table("Tbl_PizzaOrder")]
public class PizzaOrderModel
{
    [Key]
    [Column("PizzaOrderId")]
    public int PizzaOrderId { get; set; }
    [Column("PizzaOrderInvoiceNo")]
    public string PizzaOrderInvoiceNo { get; set; }
    [Column("PizzaId")]
    public int PizzaId { get; set; }
    [Column("TotalAmount")]
    public decimal TotalAmount { get; set; }
}

[Table("Tbl_PizzaOrderDetail")]
public class PizzaOrderDetailModel
{
    [Key]
    [Column("PizzaOrderDetailId")]
    public int PizzaOrderDetailId { get; set; }
    [Column("PizzaOrderInvoiceNo")]
    public string PizzaOrderInvoiceNo { get; set; }
    [Column("PizzaExtraId")]
    public int PizzaExtraId { get; set; }
}

public class PizzaOrderInvoiceHeadModel
{
    [Key]
    [Column("PizzaOrderId")]
    public int PizzaOrderId { get; set; }
    [Column("PizzaOrderInvoiceNo")]
    public string PizzaOrderInvoiceNo { get; set; }
    [Column("PizzaId")]
    public int PizzaId { get; set; }
    [Column("Pizza")]
    public string Pizza { get; set; }
    [Column("Price")]
    public decimal Price { get; set; }
    [Column("TotalAmount")]
    public decimal TotalAmount { get; set; }

}

public class PizzaOrderDetailInvoiceModel
{
    [Key]
    [Column("PizzaOrderDetailId")]
    public int PizzaOrderDetailId { get; set; }
    [Column("PizzaOrderInvoiceNo")]
    public string PizzaOrderInvoiceNo { get; set; }
    [Column("PizzaExtraId")]
    public int PizzaExtraId { get; set; }
    [Column("PizzaExtraName")]
    public string PizzaExtraName { get; set; }
    [Column("Price")]
    public decimal Price { get; set; }

}

public class PizzaOrderInvoiceResponse
{
    public PizzaOrderInvoiceHeadModel Order { get; set; }
    public List<PizzaOrderDetailInvoiceModel> OrderDetails { get; set; }
}
