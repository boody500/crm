using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Product
    {
        [StringLength(15)]
        public string Name { get; set; }

        //[Required]
        [StringLength(15)]
        public string Id { get; set; }

        
        //public Guid Pid { get; set; }


    }
}