using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
   
    public class User
    {

        //for details
        //[Required]
        [StringLength(200)]
        public string ID { get; set; }
        //[Required]
        [StringLength(15)]
        public string FirstName { get; set; }

        //[Required]
        [StringLength(15)]
        public string LastName { get; set; }

        //[Required]
        [StringLength(20)]
        public string JobTitle { get; set; }




        //for contact info
        //[Required]
        [StringLength(50)]
        public string Email { get; set; }

        //[Required]
        [StringLength(25)]
        public string Password { get; set; }

        //[Required]
        [StringLength(11)]
        public string MobilePhone { get; set; }

        //[Required]
        [StringLength(11)]
        public string BusinessPhone { get; set; }




        //for address
        //[Required]
        [StringLength(100)]
        public string Street { get; set; }

        //[Required]
        [StringLength(20)]
        public string City { get; set; }
        
        //[Required]
        [StringLength(5)]
        public string Zip { get; set; }
    }
}
