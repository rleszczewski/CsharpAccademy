using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tournament.Models
{
    public class TournamentModel
    {
        [Key]
        public int TournamentModelId { get; set; }

        [Display(Name = "Tournament Name")]
        public string TournamentName { get; set; }

        [Display(Name = "Entry Fee")]
        public decimal EntryFee { get; set; }

        public virtual ICollection<TeamModel> EnteredTeams { get; set; }

        public virtual ICollection<PrizeModel> Prizes { get; set; }

        public virtual ICollection<MatchUpModel> Rounds { get; set; }

        public TournamentModel()
        {
            this.EnteredTeams = new HashSet<TeamModel>();
            Rounds = new List<MatchUpModel>();
        }
    }
}