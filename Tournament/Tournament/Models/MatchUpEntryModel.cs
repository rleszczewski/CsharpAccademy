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
        [Key]
        public int MatchUpEntryModelId { get; set; }

        public int TeamCompetingId { get; set; }

        [ForeignKey("TeamCompetingId")]
        public virtual TeamModel TeamCompeting { get; set; }

        public int Score { get; set; }

        public int ParentMatchupId { get; set; }

        [ForeignKey("ParentMatchupId")]
        public virtual MatchUpModel ParentMatchup { get; set; }
    }
}