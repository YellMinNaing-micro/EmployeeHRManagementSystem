using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP.NetCore_Test.Entities;

[Table("Company")]
public partial class Company
{
    [Key]
    [Column("CompanyID")]
    public int CompanyId { get; set; }

    [StringLength(256)]
    public string? CompanyName { get; set; }

    public string? Address { get; set; }

    [StringLength(256)]
    public string? Phone { get; set; }

    [StringLength(256)]
    public string? Email { get; set; }
}
