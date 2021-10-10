using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Models
{
    public class login
    {
        [Required(ErrorMessage = "Username can not be blank")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Password can not be blank")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}