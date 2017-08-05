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

        [Key]
        public int MatchUpModelId { get; set; }

        public int MatchupRound { get; set; }

        public virtual ICollection<MatchUpEntryModel> Entries { get; set; }

        public int? WinnerId { get; set; }

        [ForeignKey("WinnerId")]
        public virtual TeamModel Winner { get; set; }

        public int TournamentId { get; set; }

        [ForeignKey("TournamentId")]
        public virtual TournamentModel Tournament { get; set; }
    }
}