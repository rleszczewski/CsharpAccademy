using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tournament.Models
{
    public class MatchUpModel
    {
        public MatchUpModel()
        {
            Entries = new List<MatchUpEntryModel>();

        }
        [Key, ForeignKey("Winner")]
        public int MatchUpModelId { get; set; }
        public int MatchupRound { get; set; }

        public virtual ICollection<MatchUpEntryModel> Entries { get; set; }

        public virtual TeamModel Winner { get; set; }

        public virtual TournamentModel Tournament { get; set; }
    }
}