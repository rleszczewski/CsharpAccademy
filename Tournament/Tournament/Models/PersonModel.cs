using System;
using System.Collections.Generic;
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

        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int? TeamRefId { get; set; }

        [ForeignKey("TeamRefId")]
        public virtual TeamModel TeamModel { get; set; }
    }
}