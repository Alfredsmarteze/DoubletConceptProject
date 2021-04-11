using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoubletConceptProject.Models
{
    public class YourMessage
    {
        public int Id { get; set; }
        [DataType(DataType.Text), Required, DisplayName("First Name"), MaxLength(20, ErrorMessage = "Name cannot be more than 20 character")]
        public string FirstName { get; set; }
        [DataType(DataType.Text), Required, DisplayName("Last Name"), MaxLength(20, ErrorMessage = "Name cannot be more than 20 character")]
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber), Display(Name = "Phone Number"), MaxLength(14, ErrorMessage = "Your Phone Number cannot exceed 11 digits"), Required]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress), Display(Name ="Email Address"), Required]
        public string Email { get; set; }
        //[Required]
        //public string OurService { get; set; }
        [DataType(DataType.MultilineText), Display(Name ="Your Message"), Required]
        public string Message { get; set; }
        [Required, /*DisplayFormat(DataFormatString ="{0:dd/mm/year}"),*/ DataType(DataType.Date)]
        public DateTime Date { get; set; }
       

     }
}
