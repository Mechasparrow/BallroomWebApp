using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BallroomWebApp.Data;
using System;
using System.Diagnostics;
using System.Linq;

namespace BallroomWebApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context =
                new MvcDanceContext(serviceProvider.GetRequiredService<DbContextOptions<MvcDanceContext>>());
            if (context.Dance.Any())
            {
                return;
            }
            
            context.Dance.AddRange(
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
                );
            
        }
    }
}