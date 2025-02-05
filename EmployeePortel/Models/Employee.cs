﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EmployeePortel.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [StringLength(100)]
        public string EmpFirstName { get; set; }
        [StringLength(100)]
        public string EmpLastName { get; set; }
        [StringLength(150)]
        public string EmpFullName { get; set; }
        [StringLength(50)]
        public string EmpEmail { get; set; }
        public bool? IsActive { get; set; }
    }
}
