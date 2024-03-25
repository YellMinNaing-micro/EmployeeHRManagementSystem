using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASP.NetCore_Test.Entities;

[Table("Attendance")]
public partial class Attendance
{
    [Key]
    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [Column("CompanyID")]
    public int? CompanyId { get; set; }

    [Column("Sign_intime")]
    public TimeOnly? SignIntime { get; set; }

    [Column("Sign_outtime")]
    public TimeOnly? SignOuttime { get; set; }

    public DateOnly? Date { get; set; }
}
