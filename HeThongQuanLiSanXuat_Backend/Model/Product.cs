using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLiSanXuat_Backend.Model;

[Table("products")]
[Index("ProductCode", Name = "products_product_code_key", IsUnique = true)]
public partial class Product
{
    [Key]
    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("product_code")]
    [StringLength(50)]
    public string ProductCode { get; set; } = null!;

    [Column("product_name")]
    [StringLength(255)]
    public string ProductName { get; set; } = null!;

    [Column("unit")]
    [StringLength(50)]
    public string Unit { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [InverseProperty("ProductCodeNavigation")]
    [JsonIgnore]
    public virtual ICollection<ProductionOrder> ProductionOrders { get; set; } = new List<ProductionOrder>();
}
