using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tournament.Models
{
    public class PrizeModel
    {
        [Key]
        public int PrizeModelId { get; set; }
        public int PlaceNumber { get; set; }
        public string PlaceName { get; set; }
        public decimal PrizeAmount { get; set; }
        public double PrizePercentage { get; set; }

        public int TournamentId { get; set; }

        [ForeignKey("TournamentId")]
        public TournamentModel Tournament { get; set; }
    }
}