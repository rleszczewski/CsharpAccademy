using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Tournament.Models
{
    public class TournamentContext :DbContext
    {
        public TournamentContext() : base("Tournament")
        {
            Database.SetInitializer<TournamentContext>(new CreateDatabaseIfNotExists<TournamentContext>());
            //Database.SetInitializer<TournamentContext>(new DropCreateDatabaseIfModelChanges<TournamentContext>());

        }
        public DbSet<MatchUpModel> MatchUps { get; set; }
        public DbSet<MatchUpEntryModel> MatchUpEntries { get; set; }

        public DbSet<PrizeModel> Prizes { get; set; }
        public DbSet<TeamModel> Teams { get; set; }
        public DbSet<TournamentModel> Tournamets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<TournamentContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<Tournament.Models.PersonModel> TournamentModels { get; set; }
    }
}