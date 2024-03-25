using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP.NetCore_Test.Entities;

[Table("Employee")]
public partial class Employee
{
    [Key]
    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [StringLength(256)]
    public string? EmployeeName { get; set; }

    [StringLength(256)]
    public string? CompanyName { get; set; }

    [StringLength(256)]
    public string? Deparment { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }
}
