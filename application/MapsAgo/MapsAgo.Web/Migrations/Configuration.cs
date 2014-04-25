namespace MapsAgo.Web.Migrations
{
    using MapsAgo.Common;
    using MapsAgo.Model;
    using MapsAgo.Web.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<MapsAgo.Model.MapsAgoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MapsAgo.Model.MapsAgoDbContext context)
        {
            var EventTypes = new List<EventType> {
                new EventType { Name = "Battles" },
                new EventType { Name = "Default" }
            };

            var MediaList = new List<Resource> {
                new Resource {
                    Name = "Wikipedia",
                    Type = ResourceType.Link,
                    Url = "http://en.wikipedia.org/wiki/index.html?curid=1033164",
                    Description = "Wikipedia Link"
                },
                new Resource {
                    Name = "Punitive-truck-train",
                    Type = ResourceType.Image,
                    Url = "http://upload.wikimedia.org/wikipedia/en/9/9f/Punitive-truck-train.png",
                    Description = "Punitive-truck-train"
                }
            };

            var LocList = new List<Location> {
                new Location 
                { 
                    Name = "Stockholm", 
                    Alias = "sthlm", 
                    Coordinates = DbGeography.FromText("POINT(18.068611 59.329444)"),
                    Events = new List<Event>
                    {
                        new Event {
                            Name = "Stockholm Bloodbath",
                            Excerpt = "The Stockholm Bloodbath, or the Stockholm Massacre, took place as the result of a successful...",
                            Description = "The Stockholm Bloodbath, or the Stockholm Massacre, took place as the result of a successful invasion of Sweden by Danish forces under the command of King Christian II. The bloodbath itself was a series of events taking place between November 7 and November 9 in 1520, climaxing on the 8th, when around 80-90 people were executed, despite a promise by King Christian for general amnesty.",
                            Source = "http://www.freebase.com/m/076j3",
                            StartDate = DateTime.Parse("07-11-1520"),
                            EndDate = DateTime.Parse("10-11-1520"),
                            DateCreated = DateTime.Parse("2013-1-12"),
                            Type = EventTypes.ElementAt(0)
                        }
                    }
                },
                new Location 
                {
                    Name = "Mexico",
                    Alias = "Estados Unidos Mexicanos",
                    Coordinates = DbGeography.FromText("POINT(-102.366667 19)"),
                    Events = new List<Event>
                    {
                        new Event
                        {
                            Name = "Mexican War of Independence",
                            Excerpt = "The Mexican War of Independence was an armed conflict result of a political and social process...",
                            Description = "The Mexican War of Independence was an armed conflict result of a political and social process which ended the rule of Spain in the territory of New Spain. The war had it antecedent in the French invasion of Spain in 1808 and extended from the Grito de Dolores on September 16 of 1810, to the entrance of the Army of the Three Guarantees to Mexico City on September 27 of 1821.\nThe movement was caused in part by the Age of Enlightenment and the liberal revolutions of the last part of the 18th century. By that time the educated elite of the current Mexico began to reflect about the relations between Spain and its colonial kingdoms. Changes in the social and political structure caused by Bourbon reforms and a deep economic crisis in New Spain, caused discomfort mainly in the Creole population.\nIn 1808 the king Charles IV and Ferdinand VII abdicated to Napoleon Bonaparte, who left the crown of Spain to his brother Joseph Bonaparte. The same year, the ayuntamiento of Mexico city, supported by viceroy José de Iturrigaray, claimed sovereignty in the absence of the legitimate king, the reaction led to a coup against the viceroy and led the leaders of the movement to jail.\nDespite the defeat in Mexico City, small groups of conspirators met in other cities of New Spain in order to follow the steps of Mexico City. In 1810, after being discovered, Queretaro conspirators chose to take up arms on September 16 in the company of peasants and indigenous inhabitants of the town of Dolores, called by the priest Miguel Hidalgo y Costilla.",
                            Source = "http://www.freebase.com/m/03c5kn",
                            StartDate = DateTime.Parse("16-9-1810"),
                            EndDate = DateTime.Parse("1821-1-1"),
                            DateCreated = DateTime.Parse("10-1-2014"),
                            Type = EventTypes.ElementAt(1)
                        },
                        new Event
                        {
                            Name = "Pancho Villa Expedition",
                            Excerpt = "The Pancho Villa Expedition—officially known in the United States as the Mexican Expedition and...",
                            Description = "The Pancho Villa Expedition—officially known in the United States as the Mexican Expedition and sometimes colloquially referred to as the Punitive Expedition—was a military operation conducted by the United States Army against the paramilitary forces of Mexican revolutionary Francisco \"Pancho\" Villa from 1916 to 1917 during the Mexican Revolution. The expedition was launched in retaliation for Villa's attack on the town of Columbus, New Mexico, and was the most remembered event of the Border War. The expeditions had one objective: to capture Villa dead or alive and put a stop to any future forays by his paramilitary forces on American soil. The official beginning and ending dates of the Mexican Expedition are March 14, 1916, and February 7, 1917.",
                            Source = "http://www.freebase.com/m/0401ff",
                            StartDate = DateTime.Parse("14-3-1916"),
                            EndDate = DateTime.Parse("7-2-1917"),
                            DateCreated = DateTime.Parse("1-2-2014"),             
                            Resources = MediaList,
                            Type = EventTypes.ElementAt(1)
                        }
                    }
                }
            };

            // TODO: not sure how this works really
            LocList.ForEach(loc => context.Locations.AddOrUpdate(loc));
            //SaveChanges(context);

        }
    }
}
