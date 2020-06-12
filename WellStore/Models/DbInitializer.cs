﻿using DataLayer.EfClasses;
using DataLayer.EfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WellStore.Models
{
    public static class DbInitializer
    {
        public static void Initialize(EfCoreContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }


            var s1 = new Supplier { Name = "Weatherford", City = "San Jose", State = "CA" };

                var s2 = new Supplier { Name = "Lufkin Sam", City = "Chicago", State = "IL" };

                var s3 = new Supplier { Name = "Shneider Electric", City = "Houston", State = "TX" };


                context.Products.AddRange(

                    new Product
                    {


                        Name = "MatrikonOPC Desktop Historian",
                        Description = "MatrikonOPC Desktop Historian",
                        Category = "Gas Lift",
                        Price = 275,
                        Supplier = s1,

                        Ratings = new List<Rating> { new Rating { Stars = 4 }, new Rating { Stars = 3 } }
                    },

                    new Product
                    {
                        Name = "MatrikonOPC Server for APACS Direct",
                        Description = "MatrikonOPC Server for APACS Direct",
                        Category = "Rod Lift",
                        Price = 275,
                        Supplier = s2,

                        Ratings = new List<Rating> { new Rating { Stars = 4 }, new Rating { Stars = 3 } }
                    },

                    new Product
                    {
                        Name = "MatrikonOPC Event Transfer Module (Buffer Edition)",
                        Description = "MatrikonOPC Event Transfer Module ",
                        Category = "ESP",
                        Price = 275,
                        Supplier = s1,

                        Ratings = new List<Rating> { new Rating { Stars = 4 }, new Rating { Stars = 3 } }
                    },

                    new Product
                    {
                        Name = "MatrikonOPC Server for SCADA CAC",
                        Description = "MatrikonOPC Server for SCADA CAC",
                        Category = "Gas Lift",
                        Price = 275,
                        Supplier = s2,

                        Ratings = new List<Rating> { new Rating { Stars = 4 }, new Rating { Stars = 3 } }
                    },

                    new Product
                    {
                        Name = "Universal Historian Connector",
                        Description = "Universal Historian Connector",
                        Category = "Rod Lift",
                        Price = 275,
                        Supplier = s3,

                        Ratings = new List<Rating> { new Rating { Stars = 4 }, new Rating { Stars = 3 } }
                    },

                    new Product
                    {
                        Name = "MatrikonOPC IT Health Monitor",
                        Description = "MatrikonOPC IT Health Monitor",
                        Category = "ESP",
                        Price = 275,
                        Supplier = s1,

                        Ratings = new List<Rating> { new Rating { Stars = 4 }, new Rating { Stars = 3 } }
                    },

                    new Product
                    {
                        Name = "MatrikonOPC Archestra UCS Server",
                        Description = "MatrikonOPC Archestra UCS Server",
                        Category = "Gas Lift",
                        Price = 275,
                        Supplier = s2,

                        Ratings = new List<Rating> { new Rating { Stars = 4 }, new Rating { Stars = 3 } }
                    },

                    new Product
                    {
                        Name = "MatrikonOPC Classic DA Plug-In",
                        Description = "MatrikonOPC Classic DA Plug-In",
                        Category = "Rod Lift",
                        Price = 275,
                        Supplier = s3,

                        Ratings = new List<Rating> { new Rating { Stars = 4 }, new Rating { Stars = 3 } }
                    },

                    new Product
                    {
                        Name = "MatrikonOPC Client for BSAP",
                        Description = "MatrikonOPC Client for BSAP",
                        Category = "ESP",
                        Price = 275,
                        Supplier = s1,

                        Ratings = new List<Rating> { new Rating { Stars = 4 }, new Rating { Stars = 3 } }
                    }



                    ); context.SaveChanges();

            }







        



    }

}
