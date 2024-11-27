using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Cases
    {
        [StringLength(15)]
        public string Title { get; set; }

        //[Required]
        [StringLength(15)]
        public string Cid { get; set; }

        
        public string Pid { get; set; }

        //[Required]
        [StringLength(200)]
        public string description { get; set; }
    }
}