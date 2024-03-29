namespace MapsAgo.Web.Migrations
{
    using MapsAgo.Common;
    using MapsAgo.Model;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;

    internal sealed class Configuration : DbMigrationsConfiguration<MapsAgo.Model.MapsAgoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        private ApplicationUser[] InitializeUserData(MapsAgoDbContext context)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Add user roles types, uses AuthTypes enum            
            string adminRole = RoleType.Admin.ToString();
            string authRole = RoleType.Authorized.ToString();
            string defaultRole = RoleType.Default.ToString();

            // Create the roles
            foreach (var role in Enum.GetNames(typeof(RoleType)))
            {
                if (!RoleManager.RoleExists(role))
                {
                    RoleManager.Create(new IdentityRole(role));
                }
            }

            // Set default Admin details
            string adminName = "Admin";
            string adminPassword = "123456";
            // Actually create Admin user
            var user = new ApplicationUser();
            user.UserName = adminName;
            var adminResult = UserManager.Create(user, adminPassword);
            // Add Admin to Admin role
            if (adminResult.Succeeded)
            {
                UserManager.AddToRole(user.Id, adminRole);
            }

            // Add some extra users
            var user1 = new ApplicationUser();
            user1.UserName = "Joe";
            user1.Email = "joe@example.com";
            var adduser = UserManager.Create(user1, "abc123");
            if (adduser.Succeeded)
            {
                UserManager.AddToRole(user1.Id, authRole);
            }

            var user2 = new ApplicationUser();
            user2.UserName = "Sally";
            user2.Email = "sally@example.com";
            adduser = UserManager.Create(user2, "abc123");
            if (adduser.Succeeded)
            {
                UserManager.AddToRole(user2.Id, defaultRole);
            }

            var user3 = new ApplicationUser();
            user3.UserName = "Chris";
            user3.Email = "chris@example.com";
            adduser = UserManager.Create(user3, "abc123");
            if (adduser.Succeeded)
            {
                UserManager.AddToRole(user3.Id, authRole);
            }

            var user4 = new ApplicationUser();
            user4.UserName = "Linda";
            adduser = UserManager.Create(user4, "abc123");
            if (adduser.Succeeded)
            {
                UserManager.AddToRole(user4.Id, authRole);
            }

            // return users to assign it to seed events
            return new ApplicationUser[] { user1, user2, user3, user4 };
        }


        protected override void Seed(MapsAgo.Model.MapsAgoDbContext context)
        {
            var users = InitializeUserData(context);

            var EventTypes = new List<EventType> {
                new EventType { Id = 1, Name = "Unknown" },
                new EventType { Id = 2, Name = "Battles" }
            };

            var Resources = new List<Resource> {
                new Resource {
                    Id = 1,
                    Name = "Wikipedia",
                    Type = ResourceType.Link,
                    Url = "http://en.wikipedia.org/wiki/index.html?curid=1033164",
                    Description = "Wikipedia Link"
                },
                new Resource {
                    Id = 2,
                    Name = "Punitive-truck-train",
                    Type = ResourceType.Image,
                    Url = "http://upload.wikimedia.org/wikipedia/en/9/9f/Punitive-truck-train.png",
                    Description = "Punitive-truck-train"
                }
            };

            var Locations = new List<Location> {
                new Location 
                { 
                    Id = 1,
                    Name = "Stockholm", 
                    Alias = "sthlm", 
                    Coordinates = DbGeography.FromText("POINT(18.068611 59.329444)"),
                },
                new Location 
                {
                    Id = 2,
                    Name = "Mexico",
                    Alias = "Estados Unidos Mexicanos",
                    Coordinates = DbGeography.FromText("POINT(-102.366667 19)"),
                }
            };

            var Events = new List<Event>
            {
                new Event {
                    Name = "Stockholm Bloodbath",
                    Excerpt = "The Stockholm Bloodbath, or the Stockholm Massacre, took place as the result of a successful...",
                    Description = "The Stockholm Bloodbath, or the Stockholm Massacre, took place as the result of a successful invasion of Sweden by Danish forces under the command of King Christian II. The bloodbath itself was a series of events taking place between November 7 and November 9 in 1520, climaxing on the 8th, when around 80-90 people were executed, despite a promise by King Christian for general amnesty.",
                    Source = "http://www.freebase.com/m/076j3",
                    StartDate = new DateTime(1520, 11, 7),
                    EndDate = new DateTime(1520, 11, 10),
                    DateCreated = new DateTime(2013, 2, 1),
                    LastModified = new DateTime(2013, 2, 1),
                    Resources = new List<Resource> {Resources[1]},
                    EventTypeId = 2,
                    LocationId = 1,
                    Flagged = false,
                    User = users[0]
                },
                new Event
                {
                    Name = "Mexican War of Independence",
                    Excerpt = "The Mexican War of Independence was an armed conflict result of a political and social process...",
                    Description = "The Mexican War of Independence was an armed conflict result of a political and social process which ended the rule of Spain in the territory of New Spain. The war had it antecedent in the French invasion of Spain in 1808 and extended from the Grito de Dolores on September 16 of 1810, to the entrance of the Army of the Three Guarantees to Mexico City on September 27 of 1821.\nThe movement was caused in part by the Age of Enlightenment and the liberal revolutions of the last part of the 18th century. By that time the educated elite of the current Mexico began to reflect about the relations between Spain and its colonial kingdoms. Changes in the social and political structure caused by Bourbon reforms and a deep economic crisis in New Spain, caused discomfort mainly in the Creole population.\nIn 1808 the king Charles IV and Ferdinand VII abdicated to Napoleon Bonaparte, who left the crown of Spain to his brother Joseph Bonaparte. The same year, the ayuntamiento of Mexico city, supported by viceroy Jos� de Iturrigaray, claimed sovereignty in the absence of the legitimate king, the reaction led to a coup against the viceroy and led the leaders of the movement to jail.\nDespite the defeat in Mexico City, small groups of conspirators met in other cities of New Spain in order to follow the steps of Mexico City. In 1810, after being discovered, Queretaro conspirators chose to take up arms on September 16 in the company of peasants and indigenous inhabitants of the town of Dolores, called by the priest Miguel Hidalgo y Costilla.",
                    Source = "http://www.freebase.com/m/03c5kn",
                    StartDate = new DateTime(1810, 9, 16),
                    EndDate = new DateTime(1821,1, 2),
                    DateCreated = new DateTime(2014, 1, 10),
                    LastModified = new DateTime(2014, 1, 10),
                    Resources = new[] {Resources[0]},
                    EventTypeId = 2,
                    LocationId = 2,
                    Flagged = true,
                    User = users[2]
                },
                new Event
                {
                    Name = "Pancho Villa Expedition",
                    Excerpt = "The Pancho Villa Expedition�officially known in the United States as the Mexican Expedition and...",
                    Description = "The Pancho Villa Expedition�officially known in the United States as the Mexican Expedition and sometimes colloquially referred to as the Punitive Expedition�was a military operation conducted by the United States Army against the paramilitary forces of Mexican revolutionary Francisco \"Pancho\" Villa from 1916 to 1917 during the Mexican Revolution. The expedition was launched in retaliation for Villa's attack on the town of Columbus, New Mexico, and was the most remembered event of the Border War. The expeditions had one objective: to capture Villa dead or alive and put a stop to any future forays by his paramilitary forces on American soil. The official beginning and ending dates of the Mexican Expedition are March 14, 1916, and February 7, 1917.",
                    Source = "http://www.freebase.com/m/0401ff",
                    StartDate = new DateTime(1916, 3, 14),
                    EndDate = new DateTime(1917, 2, 7),
                    DateCreated = new DateTime(2014, 2, 1),             
                    LastModified = new DateTime(2014, 2, 1),             
                    Resources = Resources,
                    EventTypeId = 1,
                    LocationId = 2,
                    Flagged = false,
                    User = users[0]
                }
            };

            context.EventTypes.AddOrUpdate(r => r.Name, EventTypes.ToArray());
            context.Locations.AddOrUpdate(r => r.Name, Locations.ToArray());
            context.Resources.AddOrUpdate(r => r.Name, Resources.ToArray());
            context.Events.AddOrUpdate(r => r.Name, Events.ToArray());
        }

    }

}