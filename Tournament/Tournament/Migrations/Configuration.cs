namespace Tournament.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tournament.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Tournament.Models.TournamentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Tournament.Models.TournamentContext context)
        {

            var Team1 = new TeamModel() { TeamId = 1, TeamName = "Manhatan", TeamMembers = new List<PersonModel>() };
            var Team2 = new TeamModel() { TeamId = 2, TeamName = "VP", TeamMembers = new List<PersonModel>() };
            var Team3 = new TeamModel() { TeamId = 3, TeamName = "Faze", TeamMembers = new List<PersonModel>() };
            var Team4 = new TeamModel() { TeamId = 4, TeamName = "123", TeamMembers = new List<PersonModel>() };
            var Team5 = new TeamModel() { TeamId = 5, TeamName = "432", TeamMembers = new List<PersonModel>() };
            var Team6 = new TeamModel() { TeamId = 6, TeamName = "asd", TeamMembers = new List<PersonModel>() };
            var Team7 = new TeamModel() { TeamId = 7, TeamName = "qwe", TeamMembers = new List<PersonModel>() };
            var Team8 = new TeamModel() { TeamId = 8, TeamName = "wer", TeamMembers = new List<PersonModel>() };
            var Person = new PersonModel() { PersonId = 1, Email = "123", NickName = "Raf", FirstName = "raffa", LastName = "daddo" };
            var Person2 = new PersonModel() { PersonId = 2, Email = "123", NickName = "Raf2", FirstName = "raffa", LastName = "daddo" };
            var Person3 = new PersonModel() { PersonId = 3, Email = "123", NickName = "baran2", FirstName = "raffa", LastName = "daddo" };
            var Person4 = new PersonModel() { PersonId = 4, Email = "123", NickName = "baran3", FirstName = "raffa", LastName = "daddo" };
            var Person5 = new PersonModel() { PersonId = 5, Email = "123", NickName = "qwe", FirstName = "raffa", LastName = "daddo" };
            var Person6 = new PersonModel() { PersonId = 6, Email = "123", NickName = "qwe2", FirstName = "raffa", LastName = "daddo" };
            var Person7 = new PersonModel() { PersonId = 7, Email = "123", NickName = "asd", FirstName = "raffa", LastName = "daddo" };
            var Person8 = new PersonModel() { PersonId = 8, Email = "123", NickName = "asd2", FirstName = "raffa", LastName = "daddo" };
            var Person9 = new PersonModel() { PersonId = 9, Email = "123", NickName = "zxc", FirstName = "raffa", LastName = "daddo" };
            var Person10 = new PersonModel() { PersonId = 10, Email = "123", NickName = "zcx2", FirstName = "raffa", LastName = "daddo" };
            var Person11 = new PersonModel() { PersonId = 11, Email = "123", NickName = "tyu2", FirstName = "raffa", LastName = "daddo" };
            var Person12 = new PersonModel() { PersonId = 12, Email = "123", NickName = "tyu", FirstName = "raffa", LastName = "daddo" };
            var Person13 = new PersonModel() { PersonId = 13, Email = "123", NickName = "iop", FirstName = "raffa", LastName = "daddo" };
            var Person14 = new PersonModel() { PersonId = 14, Email = "123", NickName = "iop2", FirstName = "raffa", LastName = "daddo" };
            var Person15 = new PersonModel() { PersonId = 15, Email = "123", NickName = "jkl", FirstName = "raffa", LastName = "daddo" };
            var Person16 = new PersonModel() { PersonId = 16, Email = "123", NickName = "jkl2", FirstName = "raffa", LastName = "daddo" };
            context.TournamentModels.Add(Person);
            context.TournamentModels.Add(Person2);
            context.TournamentModels.Add(Person3);
            context.TournamentModels.Add(Person4);
            context.TournamentModels.Add(Person5);
            context.TournamentModels.Add(Person6);
            context.TournamentModels.Add(Person7);
            context.TournamentModels.Add(Person8);
            context.TournamentModels.Add(Person9);
            context.TournamentModels.Add(Person10);
            context.TournamentModels.Add(Person11);
            context.TournamentModels.Add(Person12);
            context.TournamentModels.Add(Person13);
            context.TournamentModels.Add(Person14);
            context.TournamentModels.Add(Person15);
            context.TournamentModels.Add(Person16);

            context.Teams.Add(Team1);
            context.Teams.Add(Team2);
            context.Teams.Add(Team3);
            context.Teams.Add(Team4);
            context.Teams.Add(Team5);
            context.Teams.Add(Team6);
            context.Teams.Add(Team7);
            context.Teams.Add(Team8);

            Team1.TeamMembers.Add(Person);
            Team1.TeamMembers.Add(Person2);
            Team2.TeamMembers.Add(Person3);
            Team2.TeamMembers.Add(Person4);
            Team3.TeamMembers.Add(Person5);
            Team3.TeamMembers.Add(Person6);
            Team4.TeamMembers.Add(Person7);
            Team4.TeamMembers.Add(Person8);
            Team5.TeamMembers.Add(Person9);
            Team5.TeamMembers.Add(Person10);
            Team6.TeamMembers.Add(Person11);
            Team6.TeamMembers.Add(Person12);
            Team7.TeamMembers.Add(Person13);
            Team7.TeamMembers.Add(Person14);
            Team8.TeamMembers.Add(Person15);
            Team8.TeamMembers.Add(Person16);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}