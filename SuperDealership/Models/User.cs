using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SuperDealership.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        [Key]
        public int UserID { get; set; }
    }
}