using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tournament.Models
{
    public class TeamModel
    {
        public TeamModel()
        {
            TeamMembers = new List<PersonModel>();
            this.Tournaments = new HashSet<TournamentModel>();
        }
        [Key]
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public virtual ICollection<PersonModel> TeamMembers { get; set; }

        public virtual ICollection<TournamentModel> Tournaments { get; set; }

        public virtual MatchUpEntryModel MatchupEntry { get; set; }

        public virtual MatchUpModel Matchup { get; set; }
    }
}