using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLiSanXuat_Backend.Model;

[Table("departments")]
[Index("DepartmentCode", Name = "departments_department_code_key", IsUnique = true)]
public partial class Department
{
    [Key]
    [Column("department_id")]
    public int DepartmentId { get; set; }

    [Column("department_code")]
    [StringLength(50)]
    public string DepartmentCode { get; set; } = null!;

    [Column("department_name")]
    [StringLength(255)]
    public string DepartmentName { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [InverseProperty("Department")]
    [JsonIgnore]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
