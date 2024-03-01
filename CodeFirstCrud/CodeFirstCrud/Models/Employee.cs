using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace CodeFirstCrud.Models
{
    public class Employee
    {
        [Key]
        public int EMP_ID { get; set; }
        public string EMP_NAME { get; set; }
        public string EMP_EMAIL { get; set; }
        public long EMP_PHONE { get; set; }
        public string EMP_DEPARTMENT { get; set; }
        public string EMP_GENDER { get; set; }
        public DateTime EMP_DOB { get; set; }
        public double EMP_SALARY { get; set; }
    }
}