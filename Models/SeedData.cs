using System;
using System.Collections.Generic;
using System.Linq;
using RazorPagesCar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace RazorPagesCar.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesCarContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesCarContext>>()))
            {
                // Look for any movies.
                if (context.Car.Any())
                {
                    return;   // DB has been seeded
                }

                context.Car.AddRange(
                    
                    new Car
                    {
                        ID=1,
                        carName = "Mercedes-Benz A-Class",
                        ManufactureDate = DateTime.Parse("2018-2-12"),
                        Type = "Car",
                        Price = 150M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 2,
                        carName = "Chevrolet Silverado 1500",
                        ManufactureDate = DateTime.Parse("2016-3-13"),
                        Type = "Truck",
                        Price = 135M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 3,
                        carName = "Tesla Model S",
                        ManufactureDate = DateTime.Parse("2021-2-23"),
                        Type = "Car",
                        Price = 225M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 4,
                        carName = "Audi A1",
                        ManufactureDate = DateTime.Parse("2019-4-15"),
                        Type = "Car",
                        Price = 145M,
                        Availability = " "
                    },




                    new Car
                    {
                        ID = 5,
                        carName = "Toyota Avalon",
                        ManufactureDate = DateTime.Parse("2018-8-21"),
                        Type = "Car",
                        Price = 125M,
                        Availability = " "
                    },


                    new Car
                    {
                        ID = 6,
                        carName = "GR Supra",
                        ManufactureDate = DateTime.Parse("2009-08-14"),
                        Type = "Car",
                        Price = 120M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 7,
                        carName = "Toyota Prius",
                        ManufactureDate = DateTime.Parse("2011-03-20"),
                        Type = "Car",
                        Price = 90M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 8,
                        carName = "Corolla Altis",
                        ManufactureDate = DateTime.Parse("2014-01-19"),
                        Type = "Car",
                        Price = 95M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 9,
                        carName = "Nissan GTR",
                        ManufactureDate = DateTime.Parse("2015-07-11"),
                        Type = "Car",
                        Price = 140M,
                        Availability = " "
                    },
                    
                    new Car
                    {
                        ID = 10,
                        carName = "Nissan Sylphy",
                        ManufactureDate = DateTime.Parse("2006-05-09"),
                        Type = "Car",
                        Price = 100M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 11,
                        carName = "Honda Accord",
                        ManufactureDate = DateTime.Parse("2017-12-30"),
                        Type = "Car",
                        Price = 110M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 12,
                        carName = "Honda CR-V",
                        ManufactureDate = DateTime.Parse("2018-08-21"),
                        Type = "SUV",
                        Price = 125M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 13,
                        carName = "Honda Avancier",
                        ManufactureDate = DateTime.Parse("2017-08-25"),
                        Type = "Wagon",
                        Price = 115M,
                        Availability = " "
                    },
                    new Car
                    {
                        ID = 14,
                        carName = "Honda NSX",
                        ManufactureDate = DateTime.Parse("2018-02-11"),
                        Type = "Coupe",
                        Price = 105M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 15,
                        carName = "Nissan Patrol",
                        ManufactureDate = DateTime.Parse("2018-05-22"),
                        Type = "Car",
                        Price = 105M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 16,
                        carName = "Nissan Altima",
                        ManufactureDate = DateTime.Parse("2016-03-26"),
                        Type = "Car",
                        Price = 135M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 17,
                        carName = "Nissan Grand Livina",
                        ManufactureDate = DateTime.Parse("2017-01-28"),
                        Type = "MPV",
                        Price = 115M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 18,
                        carName = "Honda Civic",
                        ManufactureDate = DateTime.Parse("1991-07-02"),
                        Type = "Car",
                        Price = 70M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 19,
                        carName = "Mazda RX-7",
                        ManufactureDate = DateTime.Parse("2000-01-19"),
                        Type = "Car",
                        Price = 120M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID =20,
                        carName = "Toyota HIACE",
                        ManufactureDate = DateTime.Parse("2016-05-30"),
                        Type = "Car",
                        Price = 90M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 21,
                        carName = "Nissan Skyline",
                        ManufactureDate = DateTime.Parse("'1998-04-10"),
                        Type = "Car",
                        Price = 95M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 22,
                        carName = "Mitsubishi Lancer EVO VI",
                        ManufactureDate = DateTime.Parse("2005-09-16"),
                        Type = "Car",
                        Price = 130M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 23,
                        carName = "Nissan Silvia",
                        ManufactureDate = DateTime.Parse("2002-08-21"),
                        Type = "Car",
                        Price = 100M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 24,
                        carName = "Ssangyong Korando",
                        ManufactureDate = DateTime.Parse("2017-06-12"),
                        Type = "SUV",
                        Price = 125M,
                        Availability = " "
                    },
                    new Car
                    {
                        ID = 25,
                        carName = "Ssangyong Tivoli",
                        ManufactureDate = DateTime.Parse("2008-03-09"),
                        Type = "SUV",
                        Price = 115M,
                        Availability = " "
                    },
                    new Car
                    {
                        ID = 26,
                        carName = "Subaru Outback",
                        ManufactureDate = DateTime.Parse("2013-10-28"),
                        Type = "SUV",
                        Price = 130M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 27,
                        carName = "Chevrolet Corvette",
                        ManufactureDate = DateTime.Parse("2015-03-07"),
                        Type = "Car",
                        Price = 130M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 28,
                        carName = "Ferrari 488 GTB",
                        ManufactureDate = DateTime.Parse("2015-06-11"),
                        Type = "Car",
                        Price = 600M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 29,
                        carName = "Volkswagen Scirocco",
                        ManufactureDate = DateTime.Parse("2011-08-14"),
                        Type = "Car",
                        Price = 85M,
                        Availability = " "
                    },

                    new Car
                    {
                        ID = 30,
                        carName = "Lambroghini Aventador",
                        ManufactureDate = DateTime.Parse("2017-10-06"),
                        Type = "Car",
                        Price = 700M,
                        Availability = " "
                    }

                   
                );
                context.SaveChanges();
            }
        }
    }
}
