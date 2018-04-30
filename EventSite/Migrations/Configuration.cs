namespace EventSite.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using EventSite.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<EventSite.Context.EventContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EventSite.Context.EventContext context)
        {
            var newCity = new City
            {
                CityName = "PROburg",
                Zip = "33594",
                State = "Florida",
            };

            context.Cities.AddOrUpdate(c => c.CityName, newCity);

            context.SaveChanges();


            var firstUser = new User
            {
                FullName = "Walter White",
                Email = "blueMagick@hotmail.com",
                Age = 56,

            };

            var users = new List<User>
            {
                firstUser,
                new User {FullName = "Doctor Strange", Email = "lookAtMyMagicHands@gmail.com.", Age = 25 }
            };

            users.ForEach(@user =>
            {
                context.Users.AddOrUpdate(f => f.FullName, @user);
            });

            context.SaveChanges();

            var firstEvent = new Event
            {
                Title = "PROburg Painters",
                Tagline = "We love to paint.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Date = new DateTime(2019, 7, 9),
                Price = "",
                AgeGroup = AgeGroup.EVERYONE,
                KeyWord = "painting, paint, painter, art",
                City = newCity,
                Organizer = firstUser

            };

            var events = new List<Event>
            {
                firstEvent,
                new Event {Title = "PROberg Wrestlers", Tagline = "We are men.", Description = "Not much to say, men wresting.", Date = new DateTime(2019, 7, 9), Price = "", AgeGroup = AgeGroup.DRINKINGADULT, KeyWord = "wrestling, men", City = newCity }
            };

            events.ForEach(@event =>
            {
                context.Events.AddOrUpdate(a => a.Title, @event);
            });

            context.SaveChanges();

            

        }
    }
}
