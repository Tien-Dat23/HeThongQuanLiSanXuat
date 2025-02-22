using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLiSanXuat_Backend.Model;

[Table("production_orders")]
[Index("OrderCode", Name = "production_orders_order_code_key", IsUnique = true)]
public partial class ProductionOrder
{
    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("order_code")]
    [StringLength(50)]
    public string OrderCode { get; set; } = null!;

    [Column("order_name")]
    [StringLength(255)]
    public string OrderName { get; set; } = null!;

    [Column("product_code")]
    [StringLength(50)]
    public string? ProductCode { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("start_date")]
    public DateOnly StartDate { get; set; }

    [Column("end_date")]
    public DateOnly EndDate { get; set; }

    [JsonIgnore]
    [ForeignKey("ProductCode")]
    [InverseProperty("ProductionOrders")]
    public virtual Product? ProductCodeNavigation { get; set; }
}
