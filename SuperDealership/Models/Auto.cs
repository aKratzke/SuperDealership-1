using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;

namespace SuperDealership.Models
{
    public class Auto
    {
          [Key]  
        public int UserID { get; set; }
        public string Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime Year { get; set; }
        public int MPGLow { get; set; }
        public int MPGHigh { get; set; }
        public string Color { get; set; }
        public double MSRP { get; set; }
        public double Mileage { get; set; }
        //public Image CarImg { get; set; }
    
        public int VIN { get; set; }
    }

       
}  