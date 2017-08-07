using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tournament.Models
{
    public class PersonModel
    {
        [Key]
        public int PersonId { get; set; }
        [DisplayName("Nick Name")]
        [Required(ErrorMessage ="Nick Name is required")]
        public string NickName { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public int? TeamRefId { get; set; }

        [ForeignKey("TeamRefId")]
        public virtual TeamModel TeamModel { get; set; }
    }
}