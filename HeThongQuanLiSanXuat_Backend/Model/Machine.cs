using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLiSanXuat_Backend.Model;

[Table("machines")]
public partial class Machine
{
    [Key]
    [Column("machine_id")]
    public int MachineId { get; set; }

    [Column("machine_code")]
    [StringLength(50)]
    public string MachineCode { get; set; } = null!;

    [Column("machine_name")]
    [StringLength(255)]
    public string MachineName { get; set; } = null!;

    [Column("serial_number")]
    [StringLength(100)]
    public string? SerialNumber { get; set; }

    [Column("capacity")]
    public int Capacity { get; set; }

    [Column("description")]
    public string? Description { get; set; }
}
