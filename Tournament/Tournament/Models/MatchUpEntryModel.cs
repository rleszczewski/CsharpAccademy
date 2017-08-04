using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tournament.Models
{
    public class MatchUpEntryModel
    {
        [Key, ForeignKey("TeamCompeting")]
        public int MatchUpEntryModelId { get; set; }

        public virtual TeamModel TeamCompeting { get; set; }
        public double Score { get; set; }
        public virtual MatchUpModel ParentMatchup { get; set; }
    }
}