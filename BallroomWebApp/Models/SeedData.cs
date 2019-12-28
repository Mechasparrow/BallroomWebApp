using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BallroomWebApp.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BallroomWebApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =
                new MvcDanceContext(serviceProvider.GetRequiredService<DbContextOptions<MvcDanceContext>>()))
            {
                if (context.Dance.Any())
                {
                    return;
                }

                var dances = new List<Dance>()
                {
                    new Dance
                    {
                        Name = "Rumba",
                        Speed = "Rhythm"
                    },
                    new Dance()
                    {
                        Name = "Tango",
                        Speed = "Smooth"
                    },
                    new Dance()
                    {
                        Name = "Foxtrot",
                        Speed = "Smooth"
                    },
                    new Dance()
                    {
                        Name = "Cha-Cha",
                        Speed = "Rhythm"
                    }
                };

                //Create the dances
                dances.ForEach(d => context.Dance.Add(d));
                context.SaveChanges();
                
                //Create the syllabus
                var syllabi = new List<Syllabus>();

                foreach (Dance dance in dances)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        syllabi.Add(
                            new Syllabus
                            {
                                Level = i,
                                DanceId    = dance.DanceId
                            }
                        );
                    }
                }
                
                syllabi.ForEach(s => context.Syllabus.Add(s));
                context.SaveChanges();

                //TODO dance moves
                //TODO dance videos

            };
            
        }
    }
}